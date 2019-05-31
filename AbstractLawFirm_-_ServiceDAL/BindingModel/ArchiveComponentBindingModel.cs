using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLawFirm___ServiceDAL.BindingModel
{
    public class ArchiveComponentBindingModel
    {
        public int Id { get; set; }
        public int ArchiveId { get; set; }
        public int BlankId { get; set; }
        public int Count { get; set; }
    }
}
