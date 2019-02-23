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
        public List<Client> Clients { get; set; }
        public List<Blank> Blank { get; set; }
        public List<Order> Orders { get; set; }
        public List<Documents> Documents { get; set; }
        public List<DocumentsComponent> DocumentsComponent { get; set; }
        private DataListSingleton()
        {
            Clients = new List<Client>();
            Blank = new List<Blank>();
            Orders = new List<Order>();
            Documents = new List<Documents>();
            DocumentsComponent = new List<DocumentsComponent>();
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
