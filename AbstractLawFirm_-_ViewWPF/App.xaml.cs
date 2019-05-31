using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AbstractLawFirm___ServiceDAL.Interfaces;
using AbstractLawFirm___ServiceImplementList.Implementations;
using Unity;

namespace AbstractLawFirm___ViewWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IMainService, MainServiceList>();
            container.RegisterType<IArchiveService, ArchiveServiceList>();
            container.RegisterType<IBlankService, BlankServiceList>();
            container.RegisterType<IDocumentsService, DocumentsServiceList>();
            container.RegisterType<ICustomerService, CustomerServiceList>();
            var mainWindow = container.Resolve<MainWindow>();
            Application.Current.MainWindow = mainWindow;
            Application.Current.MainWindow.Show();
        }
    }
}
