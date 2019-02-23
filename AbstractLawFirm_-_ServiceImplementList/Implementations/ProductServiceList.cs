using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractLawFirm;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.ViewModel;
using AbstractLawFirm___ServiceDAL.Interfaces;

namespace AbstractLawFirm___ServiceImplementList.Implementations
{
    public class ProductServiceList : IDocumentsService
    {
        private DataListSingleton source;
        public ProductServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<DocumentsViewModel> GetList()
        {
            List<DocumentsViewModel> result = new List<DocumentsViewModel>();
            for (int i = 0; i < source.Documents.Count; ++i)
            {

            List<DocumentsComponentViewModel> documentsComponent = new List<DocumentsComponentViewModel>();
                for (int j = 0; j < source.DocumentsComponent.Count; ++j)
                {
                    if (source.DocumentsComponent[j].ProductId == source.Documents[i].Id)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Blank.Count; ++k)
                        {
                            if (source.DocumentsComponent[j].ComponentId ==
                           source.Blank[k].Id)
                            {
                                componentName = source.Blank[k].ComponentName;
                                break;
                            }
                        }
                        documentsComponent.Add(new DocumentsComponentViewModel
                        {
                            Id = source.DocumentsComponent[j].Id,
                        ProductId = source.DocumentsComponent[j].ProductId,
                            ComponentId = source.DocumentsComponent[j].ComponentId,
                            ComponentName = componentName,
                            Count = source.DocumentsComponent[j].Count
                        });
                    }
                }
                result.Add(new DocumentsViewModel
                {
                    Id = source.Documents[i].Id,
                    ProductName = source.Documents[i].ProductName,
                    Price = source.Documents[i].Price,
                    DocumentsComponent = documentsComponent
                });
            }
            return result;
        }
        public DocumentsViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Documents.Count; ++i)
            {

            List<DocumentsComponentViewModel> documentsComponent = new List<DocumentsComponentViewModel>();
                for (int j = 0; j < source.DocumentsComponent.Count; ++j)
                {
                    if (source.DocumentsComponent[j].ProductId == source.Documents[i].Id)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Blank.Count; ++k)
                        {
                            if (source.DocumentsComponent[j].ComponentId ==
                           source.Blank[k].Id)
                            {
                                componentName = source.Blank[k].ComponentName;
                                break;
                            }
                        }
                        documentsComponent.Add(new DocumentsComponentViewModel
                        {
                            Id = source.DocumentsComponent[j].Id,
                            ProductId = source.DocumentsComponent[j].ProductId,
                            ComponentId = source.DocumentsComponent[j].ComponentId,
                            ComponentName = componentName,
                            Count = source.DocumentsComponent[j].Count
                        });
                    }
                }
                if (source.Documents[i].Id == id)
                {
                    return new DocumentsViewModel
                    {
                        Id = source.Documents[i].Id,
                        ProductName = source.Documents[i].ProductName,
                        Price = source.Documents[i].Price,
                        DocumentsComponent = documentsComponent
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(DocumentsBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Documents.Count; ++i)
            {
                if (source.Documents[i].Id > maxId)
                {
                    maxId = source.Documents[i].Id;
                }
                if (source.Documents[i].ProductName == model.ProductName)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            source.Documents.Add(new Documents
            {
                Id = maxId + 1,
                ProductName = model.ProductName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = 0;
            for (int i = 0; i < source.DocumentsComponent.Count; ++i)
            {
                if (source.DocumentsComponent[i].Id > maxPCId)
                {
                    maxPCId = source.DocumentsComponent[i].Id;
                }
            }
            // убираем дубли по компонентам
            for (int i = 0; i < model.DocumentsComponent.Count; ++i)
            {
                for (int j = 1; j < model.DocumentsComponent.Count; ++j)
                {
                    if (model.DocumentsComponent[i].ComponentId ==
                    model.DocumentsComponent[j].ComponentId)
                    {
                        model.DocumentsComponent[i].Count +=
                        model.DocumentsComponent[j].Count;
                        model.DocumentsComponent.RemoveAt(j--);
                    }
                }
            }
            // добавляем компоненты
            for (int i = 0; i < model.DocumentsComponent.Count; ++i)
            {
                source.DocumentsComponent.Add(new DocumentsComponent
                {
                    Id = ++maxPCId,
                    ProductId = maxId + 1,
                    ComponentId = model.DocumentsComponent[i].ComponentId,
                    Count = model.DocumentsComponent[i].Count
                });
            }
        }
        public void UpdElement(DocumentsBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Documents.Count; ++i)
            {
                if (source.Documents[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Documents[i].ProductName == model.ProductName &&
                source.Documents[i].Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Documents[index].ProductName = model.ProductName;
            source.Documents[index].Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.DocumentsComponent.Count; ++i)
            {
                if (source.DocumentsComponent[i].Id > maxPCId)
                {
                    maxPCId = source.DocumentsComponent[i].Id;
                }
            }
            // обновляем существуюущие компоненты
            for (int i = 0; i < source.DocumentsComponent.Count; ++i)
            {
                if (source.DocumentsComponent[i].ProductId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.DocumentsComponent.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.DocumentsComponent[i].Id ==
                       model.DocumentsComponent[j].Id)
                        {
                            source.DocumentsComponent[i].Count =
                           model.DocumentsComponent[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                        source.DocumentsComponent.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            for (int i = 0; i < model.DocumentsComponent.Count; ++i)
            {
                if (model.DocumentsComponent[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.DocumentsComponent.Count; ++j)
                    {
                        if (source.DocumentsComponent[j].ProductId == model.Id &&
                        source.DocumentsComponent[j].ComponentId ==
                       model.DocumentsComponent[i].ComponentId)
                        {
                            source.DocumentsComponent[j].Count +=
                           model.DocumentsComponent[i].Count;
                            model.DocumentsComponent[i].Id =
                           source.DocumentsComponent[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.DocumentsComponent[i].Id == 0)
                    {
                        source.DocumentsComponent.Add(new DocumentsComponent
                        {
                            Id = ++maxPCId,
                            ProductId = model.Id,
                            ComponentId = model.DocumentsComponent[i].ComponentId,
                            Count = model.DocumentsComponent[i].Count
                        });
                    }
                }
            }
        }
        public void DelElement(int id)
        {
            // удаяем записи по компонентам при удалении изделия
            for (int i = 0; i < source.DocumentsComponent.Count; ++i)
            {
                if (source.DocumentsComponent[i].ProductId == id)
                {
                    source.DocumentsComponent.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Documents.Count; ++i)
            {
                if (source.Documents[i].Id == id)
                {
                    source.Documents.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
