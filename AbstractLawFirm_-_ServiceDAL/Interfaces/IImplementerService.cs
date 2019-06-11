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
    [CustomInterface("Интерфейс для работы с сотрудниками")]
    public interface IImplementerService
    {
        [CustomMethod("Метод для получения списка сотрудников")]
        List<ImplementerViewModel> GetList();
        [CustomMethod("Метод для добавления сотрудника по id")]
        ImplementerViewModel GetElement(int id);
        [CustomMethod("Метод для добавления сотрудника")]
        void AddElement(ImplementerBindingModel model);
        [CustomMethod("Метод для обновления сотрудника")]
        void UpdElement(ImplementerBindingModel model);
        [CustomMethod("Мететод для удаления сотрудника по id")]
        void DelElement(int id);
        [CustomMethod("Метод для получения свободного сотрудника")]
        ImplementerViewModel GetFreeWorker();
    }
}
