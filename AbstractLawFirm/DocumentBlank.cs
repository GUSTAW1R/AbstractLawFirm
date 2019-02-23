using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLawFirm
{
    public class DocumentBlank
    {
        public int Id { get; set; }
        public int DocumentsId { get; set; }
        public int BlankId { get; set; }
        public int Count { get; set; }
    }
}
