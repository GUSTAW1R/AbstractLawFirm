using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbstractLawFirm___ServiceDAL.Interfaces;
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
            currentContainer.RegisterType<ICustomerService, CustomerServiceList>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IBlankService, BlankServiceList>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDocumentsService, DocumentsServiceList>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceList>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IArchiveService, ArchiveServiceList>(new
           HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
