﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractLawFirm;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.Interfaces;
using AbstractLawFirm___ServiceDAL.ViewModel;

namespace AbstractLawFirm___ServiceImplementList.Implementations
{
    public class CustomerServiceList : ICustomerService
    {
        private DataListSingleton source;
        public CustomerServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<CustomerViewModel> GetList()
        {
            List<CustomerViewModel> result = new List<CustomerViewModel>();
            for (int i = 0; i < source.Customer.Count; ++i)
            {
                result.Add(new CustomerViewModel
                {
                    Id = source.Customer[i].Id,
                    CustomerFIO = source.Customer[i].CustomerFIO
                });
            }
            return result;
        }
        public CustomerViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Customer.Count; ++i)
            {
                if (source.Customer[i].Id == id)
                {
                    return new CustomerViewModel
                    {
                        Id = source.Customer[i].Id,
                        CustomerFIO = source.Customer[i].CustomerFIO
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(CustomerBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Customer.Count; ++i)
            {
                if (source.Customer[i].Id > maxId)
                {
                    maxId = source.Customer[i].Id;
                }
                if (source.Customer[i].CustomerFIO == model.CustomerFIO)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            source.Customer.Add(new Customer
            {
                Id = maxId + 1,
                CustomerFIO = model.CustomerFIO
            });
        }
        public void UpdElement(CustomerBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Customer.Count; ++i)
            {
                if (source.Customer[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Customer[i].CustomerFIO == model.CustomerFIO &&
                source.Customer[i].Id != model.Id)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Customer[index].CustomerFIO = model.CustomerFIO;
        }
        public void DelElement(int id)
        {
            for (int i = 0; i < source.Customer.Count; ++i)

            {
                if (source.Customer[i].Id == id)
                {
                    source.Customer.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
