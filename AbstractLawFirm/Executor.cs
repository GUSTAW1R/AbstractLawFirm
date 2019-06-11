using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLawFirm
{
    public class Executor
    {
        public int Id { get; set; }
        [Required]
        public string ExecutorFIO { get; set; }
        [ForeignKey("ImplementerId")]
        public virtual List<Order> Orders { get; set; }
    }
}
