using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLawFirm___ServiceDAL.ViewModel
{
    public class ArchiveLoadViewModel
    {
        public string CustomerName { get; set; }
        public string DateCreate { get; set; }
        public string DocumentName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string Status { get; set; }
    }
}
