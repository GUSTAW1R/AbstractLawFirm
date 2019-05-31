using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractLawFirm;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.Interfaces;
using AbstractLawFirm___ServiceDAL.ViewModel;

namespace AbstractLawFirm___ServiceImplementDatabase.Implements
{
    public class ArchiveServiceDB : IArchiveService
    {
        private AbstractLawFirmDbContext context;
        public ArchiveServiceDB(AbstractLawFirmDbContext context)
        {
            this.context = context;
        }
        public List<ArchiveViewModel> GetList()
        {
            List<ArchiveViewModel> result = context.Archives.Select(rec => new
           ArchiveViewModel
            {
                Id = rec.Id,
                ArchiveName = rec.ArchiveName,
                ArchiveComponent = context.ArchiveComponents
            .Where(recPC => recPC.ArchiveId == rec.Id)
           .Select(recPC => new ArchiveComponentViewModel
           {
               Id = recPC.Id,
               ArchiveId = recPC.ArchiveId,
               BlankId = recPC.BlankId,
               BlankName = recPC.Blank.BlankName,
               Count = recPC.Count
           })
           .ToList()
            })
            .ToList();
            return result;
        }
        public ArchiveViewModel GetElement(int id)
        {
            Archive element = context.Archives.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new ArchiveViewModel
                {
                    Id = element.Id,
                    ArchiveName = element.ArchiveName,
                    ArchiveComponent = context.ArchiveComponents
 .Where(recPC => recPC.ArchiveId == element.Id)
 .Select(recPC => new ArchiveComponentViewModel
 {
     Id = recPC.Id,
     ArchiveId = recPC.ArchiveId,
     BlankId = recPC.BlankId,
     BlankName = recPC.Blank.BlankName,
     Count = recPC.Count
 })
 .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(ArchiveBindingModel model)
        {
            Archive element = context.Archives.FirstOrDefault(rec => rec.ArchiveName ==
           model.ArchiveName);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            context.Archives.Add(new Archive
            {
                ArchiveName = model.ArchiveName
            });
            context.SaveChanges();
        }
        public void UpdElement(ArchiveBindingModel model)
        {
            Archive element = context.Archives.FirstOrDefault(rec => rec.ArchiveName ==
           model.ArchiveName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = context.Archives.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ArchiveName = model.ArchiveName;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Archive element = context.Archives.FirstOrDefault(rec => rec.Id ==
                   id);
                    if (element != null)
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.ArchiveComponents.RemoveRange(context.ArchiveComponents.Where(rec =>
                        rec.ArchiveId == id));
                        context.Archives.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
