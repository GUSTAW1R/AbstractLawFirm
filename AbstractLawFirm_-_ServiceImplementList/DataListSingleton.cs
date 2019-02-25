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
        public List<Customer> Customer { get; set; }
        public List<Blank> Blank { get; set; }
        public List<Order> Orders { get; set; }
        public List<Documents> Documents { get; set; }
        public List<DocumentBlank> DocumentsComponent { get; set; }
        private DataListSingleton()
        {
            Customer = new List<Customer>();
            Blank = new List<Blank>();
            Orders = new List<Order>();
            Documents = new List<Documents>();
            DocumentsComponent = new List<DocumentBlank>();
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
