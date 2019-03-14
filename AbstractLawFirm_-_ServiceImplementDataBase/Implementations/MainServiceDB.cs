using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractLawFirm;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.Interfaces;
using AbstractLawFirm___ServiceDAL.ViewModel;

namespace AbstractLawFirm___ServiceImplementDataBase.Implementations
{
    public class MainServiceDB : IMainService
    {
        private AbstractLawFirmDbContext context;

        public MainServiceDB(AbstractLawFirmDbContext context)
        {
            this.context = context;
        }
        public List<OrderViewModel> GetList()
        {
            List<OrderViewModel> result = context.Orders.Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                CustomerId = rec.CustomerId,
                DocumentsId = rec.DocumentsId,
                DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
            SqlFunctions.DateName("mm", rec.DateCreate) + " " +
            SqlFunctions.DateName("yyyy", rec.DateCreate),
                DateImplement = rec.DateImplement == null ? "" :
            SqlFunctions.DateName("dd",
           rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("mm",
           rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("yyyy",
           rec.DateImplement.Value),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                CustomerFIO = rec.Customer.CustomerFIO,
                DocumentsName = rec.Documents.DocumentsName
            })
            .ToList();
            return result;
        }
        public void CreateOrder(OrderBindingModel model)
        {
            context.Orders.Add(new Order
            {
                CustomerId = model.CustomerId,
                DocumentsId = model.DocumentsId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            });
            context.SaveChanges();
        }
        public void TakeOrderInWork(OrderBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if (element.Status != OrderStatus.Принят)
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    var productComponents = context.DocumentBlanks.Include(rec => rec.Blank).Where(rec => rec.DocumentsId == element.DocumentsId);
                    // списываем
                    foreach (var productComponent in productComponents)
                    {
                        int countOnStocks = productComponent.Count * element.Count;
                        var archiveComponents = context.ArchiveComponents.Where(rec =>
                        rec.BlankId == productComponent.BlankId);
                        foreach (var stockComponent in archiveComponents)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (stockComponent.Count >= countOnStocks)
                            {
                                stockComponent.Count -= countOnStocks;
                                countOnStocks = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnStocks -= stockComponent.Count;
                                stockComponent.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnStocks > 0)
                        {
                            throw new Exception("Не достаточно компонента " + productComponent.Blank.BlankName + " требуется " + productComponent.Count + ", нехватает " + countOnStocks);
                        }
                    }
                    element.DateImplement = DateTime.Now;
                    element.Status = OrderStatus.Выполняется;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void FinishOrder(OrderBindingModel model)
        {
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = OrderStatus.Готов;
            context.SaveChanges();
        }
        public void PayOrder(OrderBindingModel model)
        {
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = OrderStatus.Оплачен;
            context.SaveChanges();
        }
        public void PutComponentsOnArchive(ArchiveComponentBindingModel model)
        {
            ArchiveComponent element = context.ArchiveComponents.FirstOrDefault(rec =>
           rec.ArchiveId == model.ArchiveId && rec.BlankId == model.BlankId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.ArchiveComponents.Add(new ArchiveComponent
                {
                    ArchiveId = model.ArchiveId,
                    BlankId = model.BlankId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }
    }
}
