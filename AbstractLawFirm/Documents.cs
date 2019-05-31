using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLawFirm
{
    public class Documents
    {
        public int Id { get; set; }
        [Required]
        public string DocumentsName { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("DocumentsId")]
        public virtual List<DocumentBlank> DocumentBlanks { get; set; }
        [ForeignKey("DocumentsId")]
        public virtual List<Order> Orders { get; set; }
    }
}
