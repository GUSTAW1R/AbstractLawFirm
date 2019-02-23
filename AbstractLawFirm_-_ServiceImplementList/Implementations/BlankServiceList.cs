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
            for (int i = 0; i < source.Blank.Count; ++i)
            {
                result.Add(new BlankViewModel
                {
                    Id = source.Blank[i].Id,
                    ComponentName = source.Blank[i].ComponentName
                });
            }
            return result;
        }
        public BlankViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].Id == id)
                {
                    return new BlankViewModel
                    {
                        Id = source.Blank[i].Id,
                        ComponentName = source.Blank[i].ComponentName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(BlankBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Blank.Count; ++i)
            {
                if (source.Blank[i].Id > maxId)
                {
                    maxId = source.Blank[i].Id;
                }
                if (source.Blank[i].ComponentName == model.ComponentName)
                {
                    throw new Exception("Уже есть бланк с таким названием");
                }
            }
            source.Blank.Add(new Blank
            {
                Id = maxId + 1,
                ComponentName = model.ComponentName
            });
        }
        public void UpdElement(BlankBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Blank.Count; ++i)
            {
                if (source.Clients[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Clients[i].ClientFIO == model.ComponentName &&
                source.Clients[i].Id != model.Id)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Blank[index].ComponentName = model.ComponentName;
        }        public void DelElement(int id)
        {
            for (int i = 0; i < source.Blank.Count; ++i)
            {
                if (source.Blank[i].Id == id)
                {
                    source.Blank.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
