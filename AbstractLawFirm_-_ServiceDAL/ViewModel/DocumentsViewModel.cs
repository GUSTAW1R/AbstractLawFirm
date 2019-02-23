using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractLawFirm___ServiceDAL.BindingModel;

namespace AbstractLawFirm___ServiceDAL.ViewModel
{
    public class DocumentsViewModel
    {
        public int Id { get; set; }
        public string DocumentsName { get; set; }
        public string ProductComponents { get; set; }
        public decimal Price { get; set; }
        public List<DocumentBlankViewModel> DocumentBlank { get; set; }
    }
}
