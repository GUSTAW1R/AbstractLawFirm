using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AbstractLawFirm___ServiceDAL.BindingModel;

namespace AbstractLawFirm___ServiceDAL.ViewModel
{
    [DataContract]
    public class DocumentsViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string DocumentsName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public List<DocumentBlankViewModel> DocumentBlank { get; set; }
    }
}
