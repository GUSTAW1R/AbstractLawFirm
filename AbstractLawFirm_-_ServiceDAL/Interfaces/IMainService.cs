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
    [CustomInterface("Интерфейс для работы с заказами")]
    public interface IMainService
    {
        [CustomMethod("Метод для получения списка заказов")]
        List<OrderViewModel> GetList();
        [CustomMethod("Метод для получения свободных сотрудников")]
        List<OrderViewModel> GetFreeOrders();
        [CustomMethod("Метод для создания заказов")]
        void CreateOrder(OrderBindingModel model);
        [CustomMethod("Метод для отправки заказов на обработку")]
        void TakeOrderInWork(OrderBindingModel model);
        [CustomMethod("Метод для завершения обработки заказа")]
        void FinishOrder(OrderBindingModel model);
        [CustomMethod("Метод для оплаты заказа")]
        void PayOrder(OrderBindingModel model);
        [CustomMethod("Метод для добавления бланков в архив")]
        void PutComponentsOnArchive(ArchiveComponentBindingModel model);
    }
}
