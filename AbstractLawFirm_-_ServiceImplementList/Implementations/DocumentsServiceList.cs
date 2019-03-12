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
    public class DocumentsServiceList : IDocumentsService
    {
        private DataListSingleton source;
        public DocumentsServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<DocumentsViewModel> GetList()
        {
            List<DocumentsViewModel> result = source.Documents.Select(rec => new DocumentsViewModel
            {
                Id = rec.Id,
                DocumentsName = rec.DocumentsName,
                Price = rec.Price,
                DocumentBlank = source.DocumentBlanks
                .Where(recPC => recPC.DocumentsId == rec.Id)
                     .Select(recPC => new DocumentBlankViewModel
                     {
                         Id = recPC.Id,
                         DocumentsId = recPC.DocumentsId,
                         BlankId = recPC.BlankId,
                         BlankName = source.Blanks.FirstOrDefault(recC => recC.Id == recPC.BlankId)?.BlankName,
                         Count = recPC.Count
                     }).ToList()
            }).ToList();
            return result;
        }
        public DocumentsViewModel GetElement(int id)
        {
            Documents element = source.Documents.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new DocumentsViewModel
                {
                    Id = element.Id,
                    DocumentsName = element.DocumentsName,
                    Price = element.Price,
                    DocumentBlank = source.DocumentBlanks
                     .Where(recPC => recPC.DocumentsId == element.Id)
                      .Select(recPC => new DocumentBlankViewModel
                      {
                         Id = recPC.Id,
                         DocumentsId = recPC.DocumentsId,
                         BlankId = recPC.BlankId,
                         BlankName = source.Blanks.FirstOrDefault(recC => recC.Id == recPC.BlankId)?.BlankName,
                         Count = recPC.Count
                }).ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(DocumentsBindingModel model)
        {
            Documents element = source.Documents.FirstOrDefault(rec => rec.DocumentsName == model.DocumentsName);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            int maxId = source.Documents.Count > 0 ? source.Documents.Max(rec => rec.Id) :0;
            source.Documents.Add(new Documents
            {
                Id = maxId + 1,
                DocumentsName = model.DocumentsName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = source.DocumentBlanks.Count > 0 ?
           source.DocumentBlanks.Max(rec => rec.Id) : 0;
            // убираем дубли по компонентам
            var groupComponents = model.DocumentBlank
            .GroupBy(rec => rec.BlankId)
           .Select(rec => new
           {
               ComponentId = rec.Key,
               Count = rec.Sum(r => r.Count)
           });
            // добавляем компоненты
            foreach (var groupComponent in groupComponents)
            {
                source.DocumentBlanks.Add(new DocumentBlank
                {
                    Id = ++maxPCId,
                    DocumentsId = maxId + 1,
                    BlankId = groupComponent.ComponentId,
                    Count = groupComponent.Count
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
            for (int i = 0; i < source.DocumentBlanks.Count; ++i)
            {
                if (source.DocumentBlanks[i].Id > maxPCId)
                {
                    maxPCId = source.DocumentBlanks[i].Id;
                }
            }
            // обновляем существуюущие компоненты
            for (int i = 0; i < source.DocumentBlanks.Count; ++i)
            {
                if (source.DocumentBlanks[i].DocumentsId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.DocumentBlank.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.DocumentBlanks[i].Id ==
                       model.DocumentBlank[j].Id)
                        {
                            source.DocumentBlanks[i].Count =
                           model.DocumentBlank[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                        source.DocumentBlanks.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            for (int i = 0; i < model.DocumentBlank.Count; ++i)
            {
                if (model.DocumentBlank[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.DocumentBlanks.Count; ++j)
                    {
                        if (source.DocumentBlanks[j].DocumentsId == model.Id &&
                        source.DocumentBlanks[j].BlankId ==
                       model.DocumentBlank[i].BlankId)
                        {
                            source.DocumentBlanks[j].Count +=
                           model.DocumentBlank[i].Count;
                            model.DocumentBlank[i].Id =
                           source.DocumentBlanks[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.DocumentBlank[i].Id == 0)
                    {
                        source.DocumentBlanks.Add(new DocumentBlank
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
            Documents element = source.Documents.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // удаяем записи по компонентам при удалении изделия
                source.DocumentBlanks.RemoveAll(rec => rec.DocumentsId == id);
                source.Documents.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}

