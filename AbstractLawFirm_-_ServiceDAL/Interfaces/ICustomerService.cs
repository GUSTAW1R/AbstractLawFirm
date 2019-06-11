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
    [CustomInterface("Интерфейс для работы с клиентами")]
    public interface ICustomerService
    {
        [CustomMethod("Метод для получения списка клиентов")]
        List<CustomerViewModel> GetList();
        [CustomMethod("Метод для получения клиента по id")]
        CustomerViewModel GetElement(int id);
        [CustomMethod("Метод для добавления клиента")]
        void AddElement(CustomerBindingModel model);
        [CustomMethod("Метод для обновления клиента")]
        void UpdElement(CustomerBindingModel model);
        [CustomMethod("Метод для удаления клиента по id")]
        void DelElement(int id);
    }
}
