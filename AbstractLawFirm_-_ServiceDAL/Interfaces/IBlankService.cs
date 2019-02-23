using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.ViewModel;

namespace AbstractLawFirm___ServiceDAL.Interfaces
{
    public interface IBlankService
    {
        List<BlankViewModel> GetList();
        BlankViewModel GetElement(int id);
        void AddElement(BlankBindingModel model);
        void UpdElement(BlankBindingModel model);
        void DelElement(int id);
    }
}
