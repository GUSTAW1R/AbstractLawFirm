using System;
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
    public class ArchiveServiceList : IArchiveService
    {
        private DataListSingleton source;

        public ArchiveServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<ArchiveViewModel> GetList()
        {
            List<ArchiveViewModel> result = source.Archives
            .Select(rec => new ArchiveViewModel
            {
                Id = rec.Id,
                ArchiveName = rec.ArchiveName,
                ArchiveComponent = source.ArchiveComponents
            .Where(recPC => recPC.ArchiveId == rec.Id)
            .Select(recPC => new ArchiveComponentViewModel
            {
                Id = recPC.Id,
                ArchiveId = recPC.ArchiveId,
                BlankId = recPC.BlankId,
                BlankName = source.Blanks
            .FirstOrDefault(recC => recC.Id == recPC.BlankId)?.BlankName,
                Count = recPC.Count
            })
            .ToList()
            })
            .ToList();
            return result;
        }
        public ArchiveViewModel GetElement(int id)

        {
            Archive element = source.Archives.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new ArchiveViewModel
                {
                    Id = element.Id,
                    ArchiveName = element.ArchiveName,
                    ArchiveComponent = source.ArchiveComponents
                .Where(recPC => recPC.ArchiveId == element.Id)
                .Select(recPC => new ArchiveComponentViewModel
                {
                    Id = recPC.Id,
                    ArchiveId = recPC.ArchiveId,
                    BlankId = recPC.BlankId,
                    BlankName = source.Blanks
                .FirstOrDefault(recC => recC.Id == recPC.BlankId)?.BlankName,
                    Count = recPC.Count
                })
                .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(ArchiveBindingModel model)
        {
            Archive element = source.Archives.FirstOrDefault(rec => rec.ArchiveName == model.ArchiveName);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            int maxId = source.Archives.Count > 0 ? source.Archives.Max(rec => rec.Id) : 0;
            source.Archives.Add(new Archive
            {
                Id = maxId + 1,
                ArchiveName = model.ArchiveName
            });
        }
        public void UpdElement(ArchiveBindingModel model)
        {
            Archive element = source.Archives.FirstOrDefault(rec =>
            rec.ArchiveName == model.ArchiveName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = source.Archives.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ArchiveName = model.ArchiveName;
        }
        public void DelElement(int id)
        {
            Archive element = source.Archives.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {

                // при удалении удаляем все записи о компонентах на удаляемом складе
                source.ArchiveComponents.RemoveAll(rec => rec.ArchiveId == id);
                source.Archives.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
