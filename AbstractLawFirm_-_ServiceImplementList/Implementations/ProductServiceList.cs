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

            List<DocumentBlankViewModel> documentBlank = new List<DocumentBlankViewModel>();
                for (int j = 0; j < source.DocumentsComponent.Count; ++j)
                {
                    if (source.DocumentsComponent[j].DocumentsId == source.Documents[i].Id)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Blank.Count; ++k)
                        {
                            if (source.DocumentsComponent[j].BlankId ==
                           source.Blank[k].Id)
                            {
                                componentName = source.Blank[k].BlankName;
                                break;
                            }
                        }
                        documentBlank.Add(new DocumentBlankViewModel
                        {
                            Id = source.DocumentsComponent[j].Id,
                        DocumentsId = source.DocumentsComponent[j].DocumentsId,
                            BlankId = source.DocumentsComponent[j].BlankId,
                            BlankName = componentName,
                            Count = source.DocumentsComponent[j].Count
                        });
                    }
                }
                result.Add(new DocumentsViewModel
                {
                    Id = source.Documents[i].Id,
                    DocumentsName = source.Documents[i].DocumentsName,
                    Price = source.Documents[i].Price,
                    DocumentBlank = documentBlank
                });
            }
            return result;
        }
        public DocumentsViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Documents.Count; ++i)
            {

            List<DocumentBlankViewModel> documentBlank = new List<DocumentBlankViewModel>();
                for (int j = 0; j < source.DocumentsComponent.Count; ++j)
                {
                    if (source.DocumentsComponent[j].DocumentsId == source.Documents[i].Id)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Blank.Count; ++k)
                        {
                            if (source.DocumentsComponent[j].BlankId ==
                           source.Blank[k].Id)
                            {
                                componentName = source.Blank[k].BlankName;
                                break;
                            }
                        }
                        documentBlank.Add(new DocumentBlankViewModel
                        {
                            Id = source.DocumentsComponent[j].Id,
                            DocumentsId = source.DocumentsComponent[j].DocumentsId,
                            BlankId = source.DocumentsComponent[j].BlankId,
                            BlankName = componentName,
                            Count = source.DocumentsComponent[j].Count
                        });
                    }
                }
                if (source.Documents[i].Id == id)
                {
                    return new DocumentsViewModel
                    {
                        Id = source.Documents[i].Id,
                        DocumentsName = source.Documents[i].DocumentsName,
                        Price = source.Documents[i].Price,
                        DocumentBlank = documentBlank
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
                if (source.Documents[i].DocumentsName == model.DocumentsName)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            source.Documents.Add(new Documents
            {
                Id = maxId + 1,
                DocumentsName = model.DocumentsName,
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
            for (int i = 0; i < model.DocumentBlank.Count; ++i)
            {
                for (int j = 1; j < model.DocumentBlank.Count; ++j)
                {
                    if (model.DocumentBlank[i].BlankId ==
                    model.DocumentBlank[j].BlankId)
                    {
                        model.DocumentBlank[i].Count +=
                        model.DocumentBlank[j].Count;
                        model.DocumentBlank.RemoveAt(j--);
                    }
                }
            }
            // добавляем компоненты
            for (int i = 0; i < model.DocumentBlank.Count; ++i)
            {
                source.DocumentsComponent.Add(new DocumentBlank
                {
                    Id = ++maxPCId,
                    DocumentsId = maxId + 1,
                    BlankId = model.DocumentBlank[i].BlankId,
                    Count = model.DocumentBlank[i].Count
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
                if (source.Documents[i].DocumentsName == model.DocumentsName &&
                source.Documents[i].Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Documents[index].DocumentsName = model.DocumentsName;
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
                if (source.DocumentsComponent[i].DocumentsId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.DocumentBlank.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.DocumentsComponent[i].Id ==
                       model.DocumentBlank[j].Id)
                        {
                            source.DocumentsComponent[i].Count =
                           model.DocumentBlank[j].Count;
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
            for (int i = 0; i < model.DocumentBlank.Count; ++i)
            {
                if (model.DocumentBlank[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.DocumentsComponent.Count; ++j)
                    {
                        if (source.DocumentsComponent[j].DocumentsId == model.Id &&
                        source.DocumentsComponent[j].BlankId ==
                       model.DocumentBlank[i].BlankId)
                        {
                            source.DocumentsComponent[j].Count +=
                           model.DocumentBlank[i].Count;
                            model.DocumentBlank[i].Id =
                           source.DocumentsComponent[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.DocumentBlank[i].Id == 0)
                    {
                        source.DocumentsComponent.Add(new DocumentBlank
                        {
                            Id = ++maxPCId,
                            DocumentsId = model.Id,
                            BlankId = model.DocumentBlank[i].BlankId,
                            Count = model.DocumentBlank[i].Count
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
                if (source.DocumentsComponent[i].DocumentsId == id)
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
