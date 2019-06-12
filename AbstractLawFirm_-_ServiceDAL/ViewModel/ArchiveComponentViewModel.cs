using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLawFirm___ServiceDAL.ViewModel
{
    [DataContract]
    public class ArchiveComponentViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ArchiveId { get; set; }
        [DataMember]
        public int BlankId { get; set; }
        [DataMember]
        public string BlankName { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
