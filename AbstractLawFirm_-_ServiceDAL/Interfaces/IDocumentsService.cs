using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.ViewModel;

namespace AbstractLawFirm___ServiceDAL.Interfaces
{
    public interface IDocumentsService
    {
        List<DocumentsViewModel> GetList();
        DocumentsViewModel GetElement(int id);
        void AddElement(DocumentsBindingModel model);
        void UpdElement(DocumentsBindingModel model);
        void DelElement(int id);
    }
}
