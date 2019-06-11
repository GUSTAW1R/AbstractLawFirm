using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractLawFirm___ServiceDAL.Attributes;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.ViewModel;

namespace AbstractLawFirm___ServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с бланками")]
    public interface IBlankService
    {
        [CustomMethod("Метод для получения списка бланков")]
        List<BlankViewModel> GetList();
        [CustomMethod("Метод для получения бланка по id")]
        BlankViewModel GetElement(int id);
        [CustomMethod("Метод для добавления бланка")]
        void AddElement(BlankBindingModel model);
        [CustomMethod("Метод для обновления бланка")]
        void UpdElement(BlankBindingModel model);
        [CustomMethod("Метод для удаления бланка по id")]
        void DelElement(int id);
    }
}
