using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractLawFirm;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.Interfaces;
using AbstractLawFirm___ServiceDAL.ViewModel;

namespace AbstractLawFirm___ServiceImplementList.Implementations
{
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;
        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetList()
        {
            List<OrderViewModel> result = source.Orders
              .Select(rec => new OrderViewModel
              {
                  Id = rec.Id,
                  CustomerId = rec.CustomerId,
                  DocumentsId = rec.DocumentsId,
                  DateCreate = rec.DateCreate.ToLongDateString(),
                  DateImplement = rec.DateImplement?.ToLongDateString(),
                  Status = rec.Status.ToString(),
                  Count = rec.Count,
                  Sum = rec.Sum,
                  CustomerFIO = source.Customers.FirstOrDefault(recC => recC.Id == rec.CustomerId)?.CustomerFIO,
                  DocumentsName = source.Documents.FirstOrDefault(recP => recP.Id == rec.DocumentsId)?.DocumentsName,
              }).ToList();
            return result;
        }
        public void CreateOrder(OrderBindingModel model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
            source.Orders.Add(new Order
            {
                Id = maxId + 1,
                CustomerId = model.CustomerId,
                DocumentsId = model.DocumentsId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            });
        }
        public void TakeOrderInWork(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            // смотрим по количеству компонентов на складах
            var documentBlank = source.DocumentBlanks.Where(rec => rec.DocumentsId == element.DocumentsId);
            foreach (var productComponent in documentBlank)
            {
                int countOnStocks = source.ArchiveComponents
                .Where(rec => rec.BlankId ==
               productComponent.BlankId)
               .Sum(rec => rec.Count);
                if (countOnStocks < productComponent.Count * element.Count)
                {
                    var componentName = source.Blanks.FirstOrDefault(rec => rec.Id ==
                   productComponent.BlankId);
                    throw new Exception("Не достаточно компонента " +
                   componentName?.BlankName + " требуется " + (productComponent.Count * element.Count) +
                   ", в наличии " + countOnStocks);
                }
            }
            // списываем
            foreach (var productComponent in documentBlank)
            {
                int countOnStocks = productComponent.Count * element.Count;
                var archiveComponents = source.ArchiveComponents.Where(rec => rec.BlankId
               == productComponent.BlankId);
                foreach (var stockComponent in archiveComponents)
                {
                    // компонентов на одном слкаде может не хватать
                    if (stockComponent.Count >= countOnStocks)
                    {
                        stockComponent.Count -= countOnStocks;
                        break;
                    }
                    else
                    {
                        countOnStocks -= stockComponent.Count;
                        stockComponent.Count = 0;
                    }
                }
            }
            element.DateImplement = DateTime.Now;
            element.Status = OrderStatus.Выполняется;
        }
        public void FinishOrder(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = OrderStatus.Готов;
        }
        public void PayOrder(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = OrderStatus.Оплачен;
        }
        public void PutComponentsOnArchive(ArchiveComponentBindingModel model)
        {
            ArchiveComponent element = source.ArchiveComponents.FirstOrDefault(rec =>
           rec.ArchiveId == model.ArchiveId && rec.BlankId == model.BlankId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.ArchiveComponents.Count > 0 ?
               source.ArchiveComponents.Max(rec => rec.Id) : 0;
                source.ArchiveComponents.Add(new ArchiveComponent
                {
                    Id = ++maxId,
                    ArchiveId = model.ArchiveId,
                    BlankId = model.BlankId,
                    Count = model.Count
                });
            }
        }
    }
}
