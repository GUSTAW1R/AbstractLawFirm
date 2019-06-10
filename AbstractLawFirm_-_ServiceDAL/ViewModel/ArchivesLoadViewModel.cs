using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLawFirm___ServiceDAL.ViewModel
{
    [DataContract]
    public class ArchivesLoadViewModel
    {
        [DataMember]
        public string ArchiveName { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
        [DataMember]
        public IEnumerable<Tuple<string, int>> Blanks { get; set; }
    }
}
