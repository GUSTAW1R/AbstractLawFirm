using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractLawFirm;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.Interfaces;
using AbstractLawFirm___ServiceDAL.ViewModel;

namespace AbstractLawFirm___ServiceImplementDataBase.Implementations
{
    public class ImplementerServiceDB : IImplementerService
    {
        private AbstractLawFirmDbContext context;
        public ImplementerServiceDB(AbstractLawFirmDbContext context)
        {
            this.context = context;
        }
        public List<ImplementerViewModel> GetList()
        {
            List<ImplementerViewModel> result = context.Implementers
            .Select(rec => new ImplementerViewModel
            {
                Id = rec.Id,
                ImplementerFIO = rec.ImplementerFIO
            })
            .ToList();
            return result;
        }
        public ImplementerViewModel GetElement(int id)
        {
            Implementer element = context.Implementers.FirstOrDefault(rec => rec.Id ==
           id);
            if (element != null)
            {
                return new ImplementerViewModel
                {
                    Id = element.Id,
                    ImplementerFIO = element.ImplementerFIO
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(ImplementerBindingModel model)
        {
            Implementer element = context.Implementers.FirstOrDefault(rec =>
           rec.ImplementerFIO == model.ImplementerFIO);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            context.Implementers.Add(new Implementer
            {
                ImplementerFIO = model.ImplementerFIO
            });
            context.SaveChanges();
        }
        public void UpdElement(ImplementerBindingModel model)
        {
            Implementer element = context.Implementers.FirstOrDefault(rec =>
            rec.ImplementerFIO == model.ImplementerFIO &&
           rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ImplementerFIO = model.ImplementerFIO;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Implementer element = context.Implementers.FirstOrDefault(rec => rec.Id ==
           id);
            if (element != null)
            {
                context.Implementers.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public ImplementerViewModel GetFreeWorker()
        {
            var ordersWorker = context.Implementers
            .Select(x => new
            {
                ImplId = x.Id,
                Count = context.Orders.Where(o => o.Status == OrderStatus.Выполняется
     && o.Implementer.Id == x.Id).Count()
            })
            .OrderBy(x => x.Count)
            .FirstOrDefault();
            if (ordersWorker != null)
            {
                return GetElement(ordersWorker.ImplId);
            }
            return null;
        }
    }
}
