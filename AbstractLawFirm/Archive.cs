using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLawFirm
{
    public class Archive
    {
        public int Id { get; set; }
        [Required]
        public string ArchiveName { get; set; }
        [ForeignKey("ArchiveId")]
        public virtual List<ArchiveComponent> ArchiveComponents { get; set; }
    }
}
