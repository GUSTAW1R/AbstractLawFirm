using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLawFirm___ServiceDAL.BindingModel
{
    [DataContract]
    public class DocumentsBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string DocumentsName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public List<DocumentBlankBindingModel> DocumentBlank { get; set; }
    }
}
