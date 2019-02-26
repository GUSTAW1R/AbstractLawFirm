using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractLawFirm;

namespace AbstractLawFirm___ServiceImplementList
{
    class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Customer> Customers { get; set; }
        public List<Blank> Blanks { get; set; }
        public List<Order> Orders { get; set; }
        public List<Documents> Documents { get; set; }
        public List<DocumentBlank> DocumentsComponent { get; set; }
        public List<Archive> Archives { get; set; }
        public List<ArchiveComponent> ArchiveComponents { get; set; }
        private DataListSingleton()
        {
            Customers = new List<Customer>();
            Blanks = new List<Blank>();
            Orders = new List<Order>();
            Documents = new List<Documents>();
            DocumentsComponent = new List<DocumentBlank>();
            Archives = new List<Archive>();
            ArchiveComponents = new List<ArchiveComponent>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
