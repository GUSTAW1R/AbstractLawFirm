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
    public class BlankServiceDB : IBlankService
    {
        private AbstractLawFirmDbContext context;

        public BlankServiceDB(AbstractLawFirmDbContext context)
        {
            this.context = context;
        }
        public List<BlankViewModel> GetList()
        {
            List<BlankViewModel> result = context.Blanks.Select(rec => new
           BlankViewModel
            {
                Id = rec.Id,
                BlankName = rec.BlankName
            })
            .ToList();
            return result;
        }
        public BlankViewModel GetElement(int id)
        {
            Blank element = context.Blanks.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new BlankViewModel
                {
                    Id = element.Id,
                    BlankName = element.BlankName
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(BlankBindingModel model)
        {
            Blank element = context.Blanks.FirstOrDefault(rec => rec.BlankName ==
           model.BlankName);
            if (element != null)
            {
                throw new Exception("Уже есть бланк с таким названием");
            }
            context.Blanks.Add(new Blank
            {
                BlankName = model.BlankName
            });
            context.SaveChanges();
        }
        public void UpdElement(BlankBindingModel model)
        {
            Blank element = context.Blanks.FirstOrDefault(rec => rec.BlankName ==
           model.BlankName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = context.Blanks.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.BlankName = model.BlankName;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Blank element = context.Blanks.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Blanks.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
