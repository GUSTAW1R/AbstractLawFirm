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
    [CustomInterface("Интерфейс для работы с сообщениями")]
    public interface IMessageInfoService
    {
        [CustomMethod("Метод для получения списка сообщений")]
        List<MessageInfoViewModel> GetList();
        [CustomMethod("Метод для получения сообщения по id")]
        MessageInfoViewModel GetElement(int id);
        [CustomMethod("Метод для добавления сообщения")]
        void AddElement(MessageInfoBindingModel model);
    }
}
