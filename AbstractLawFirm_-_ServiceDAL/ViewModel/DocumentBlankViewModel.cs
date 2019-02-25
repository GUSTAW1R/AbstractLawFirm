using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLawFirm___ServiceDAL.ViewModel
{
    public class DocumentBlankViewModel
    {
        public int Id { get; set; }
        public int DocumentsId { get; set; }
        public int BlankId { get; set; }
        public int Count { get; set; }
        public string BlankName { get; set; }
    }
}
