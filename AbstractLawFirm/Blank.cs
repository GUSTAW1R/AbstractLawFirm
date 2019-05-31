using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLawFirm
{
    public class Blank //Component
    {
        public int Id { get; set; }
        [Required]
        public string BlankName { get; set; }
        [ForeignKey("BlankId")]
        public virtual List<DocumentBlank> DocumentBlanks { get; set; }
        [ForeignKey("BlankId")]
        public virtual List<ArchiveComponent> ArchiveComponents { get; set; }
    }
}
