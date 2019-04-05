using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.ViewModel;

namespace AbstractLawFirm___ServiceDAL.Interfaces
{
    public interface IReportService
    {
        void SaveDocumentPrice(ReportBindingModel model);
        List<ArchivesLoadViewModel> GetArchivesLoad();
        void SaveArchivesLoad(ReportBindingModel model);
        List<CustomerOrdersViewModel> GetCustomerOrders(ReportBindingModel model);
        void SaveCustomerOrders(ReportBindingModel model);
    }
}
