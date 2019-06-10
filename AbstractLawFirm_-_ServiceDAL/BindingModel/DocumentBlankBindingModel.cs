using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLawFirm___ServiceDAL.BindingModel
{
    [DataContract]
    public class DocumentBlankBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int DocumentsId { get; set; }
        [DataMember]
        public int BlankId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
