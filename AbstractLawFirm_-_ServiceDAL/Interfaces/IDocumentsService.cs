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
    [CustomInterface("Интерфейс для работы с документами")]
    public interface IDocumentsService
    {
        [CustomMethod("Метод для получения списка документов")]
        List<DocumentsViewModel> GetList();
        [CustomMethod("Метод для получения документа по id")]
        DocumentsViewModel GetElement(int id);
        [CustomMethod("Метод для добавления документа")]
        void AddElement(DocumentsBindingModel model);
        [CustomMethod("Метод для обновления документа")]
        void UpdElement(DocumentsBindingModel model);
        [CustomMethod("Метод для удаления документа по id")]
        void DelElement(int id);
    }
}
