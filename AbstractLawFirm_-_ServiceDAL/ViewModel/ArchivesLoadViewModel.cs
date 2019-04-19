using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLawFirm___ServiceDAL.ViewModel
{
    public class ArchivesLoadViewModel
    {
        public string ArchiveName { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<Tuple<string, int>> Blanks { get; set; }
    }
}
