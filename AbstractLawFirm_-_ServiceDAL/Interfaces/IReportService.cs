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
    [CustomInterface("Интерфейс для работы с отчетами")]
    public interface IReportService
    {
        [CustomMethod("Метод для сохранения прайс-листа")]
        void SaveDocumentPrice(ReportBindingModel model);
        [CustomMethod("Метод для получения информации о заргуженности архивов")]
        List<ArchivesLoadViewModel> GetArchivesLoad();
        [CustomMethod("Метод для сохранения информации о загруженности складов")]
        void SaveArchivesLoad(ReportBindingModel model);
        [CustomMethod("Метод для получения списка заказов клиентов")]
        List<CustomerOrdersViewModel> GetCustomerOrders(ReportBindingModel model);
        [CustomMethod("Метод для сохранения списка заказов клиента")]
        void SaveCustomerOrders(ReportBindingModel model);
    }
}
