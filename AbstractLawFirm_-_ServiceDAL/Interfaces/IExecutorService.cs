using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.ViewModel;

namespace AbstractLawFirm___ServiceDAL.Interfaces
{
    public interface IExecutorService
    {
        List<ExecutorViewModel> GetList();
        ExecutorViewModel GetElement(int id);
        void AddElement(ExecutorBindingModel model);
        void UpdElement(ExecutorBindingModel model);
        void DelElement(int id);
        ExecutorViewModel GetFreeWorker();
    }
}
