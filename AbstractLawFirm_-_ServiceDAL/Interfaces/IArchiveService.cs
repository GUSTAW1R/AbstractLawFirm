using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.ViewModel;

namespace AbstractLawFirm___ServiceDAL.Interfaces
{
    public interface IArchiveService
    {
        List<ArchiveViewModel> GetList();
        ArchiveViewModel GetElement(int id);
        void AddElement(ArchiveBindingModel model);
        void UpdElement(ArchiveBindingModel model);
        void DelElement(int id);
    }
}
