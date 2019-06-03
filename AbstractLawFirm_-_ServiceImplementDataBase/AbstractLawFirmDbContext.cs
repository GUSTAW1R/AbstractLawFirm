using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractLawFirm;

namespace AbstractLawFirm___ServiceImplementDataBase
{
    public class AbstractLawFirmDbContext : DbContext
    {
        public AbstractLawFirmDbContext() : base("Abstract_lawFirm_Database")
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied =
           System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Blank> Blanks { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<DocumentBlank> DocumentBlanks { get; set; }
        public virtual DbSet<Archive> Archives { get; set; }
        public virtual DbSet<ArchiveComponent> ArchiveComponents { get; set; }
    }
}
