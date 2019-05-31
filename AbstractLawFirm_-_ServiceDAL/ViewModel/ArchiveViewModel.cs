using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLawFirm___ServiceDAL.ViewModel
{
    public class ArchiveViewModel
    {
        public int Id { get; set; }
        public string ArchiveName { get; set; }
        public List<ArchiveComponentViewModel> ArchiveComponent { get; set; }
    }
}
