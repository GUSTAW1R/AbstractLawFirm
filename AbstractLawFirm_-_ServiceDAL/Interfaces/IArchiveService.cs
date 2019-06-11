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
    [CustomInterface("Интерфейс для работы с архивами")]
    public interface IArchiveService
    {
        [CustomMethod("Метод для получения списка архивов")]
        List<ArchiveViewModel> GetList();
        [CustomMethod("Метод для получения архива по id")]
        ArchiveViewModel GetElement(int id);
        [CustomMethod("Метод для добавления архива")]
        void AddElement(ArchiveBindingModel model);
        [CustomMethod("Метод для обновления архива")]
        void UpdElement(ArchiveBindingModel model);
        [CustomMethod("Метод для удаления архива по id")]
        void DelElement(int id);
    }
}
