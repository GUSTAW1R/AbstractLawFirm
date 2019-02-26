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
    public class BlankServiceList : IBlankService
    {
        private DataListSingleton source;
        public BlankServiceList()
        {
            source = DataListSingleton.GetInstance();
        }        public List<BlankViewModel> GetList()
        {
            List<BlankViewModel> result = new List<BlankViewModel>();
            for (int i = 0; i < source.Blanks.Count; ++i)
            {
                result.Add(new BlankViewModel
                {
                    Id = source.Blanks[i].Id,
                    BlankName = source.Blanks[i].BlankName
                });
            }
            return result;
        }
        public BlankViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Customers.Count; ++i)
            {
                if (source.Customers[i].Id == id)
                {
                    return new BlankViewModel
                    {
                        Id = source.Blanks[i].Id,
                        BlankName = source.Blanks[i].BlankName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(BlankBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Blanks.Count; ++i)
            {
                if (source.Blanks[i].Id > maxId)
                {
                    maxId = source.Blanks[i].Id;
                }
                if (source.Blanks[i].BlankName == model.BlankName)
                {
                    throw new Exception("Уже есть бланк с таким названием");
                }
            }
            source.Blanks.Add(new Blank
            {
                Id = maxId + 1,
                BlankName = model.BlankName
            });
        }
        public void UpdElement(BlankBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Blanks.Count; ++i)
            {
                if (source.Customers[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Customers[i].CustomerFIO == model.BlankName &&
                source.Customers[i].Id != model.Id)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Blanks[index].BlankName = model.BlankName;
        }        public void DelElement(int id)
        {
            for (int i = 0; i < source.Blanks.Count; ++i)
            {
                if (source.Blanks[i].Id == id)
                {
                    source.Blanks.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
