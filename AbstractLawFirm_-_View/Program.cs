using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbstractLawFirm___ServiceDAL.Interfaces;
using AbstractLawFirm___ServiceImplementDataBase;
using AbstractLawFirm___ServiceImplementDataBase.Implementations;
using AbstractLawFirm___ServiceImplementList.Implementations;
using Unity;
using Unity.Lifetime;

namespace AbstractLawFirm___View
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, AbstractLawFirmDbContext>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICustomerService, CustomerServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IBlankService, BlankServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDocumentsService, DocumentsServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IArchiveService, ArchiveServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportService, ReportServiceDB>(new
           HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
