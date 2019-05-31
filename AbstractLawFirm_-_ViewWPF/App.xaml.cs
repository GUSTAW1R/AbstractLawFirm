using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AbstractLawFirm___ServiceDAL.Interfaces;
using AbstractLawFirm___ServiceImplementDatabase.Implements;
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
            container.RegisterType<IMainService, MainServiceDB>();
            container.RegisterType<IArchiveService, ArchiveServiceDB>();
            container.RegisterType<IBlankService, BlankServiceDB>();
            container.RegisterType<IDocumentsService, DocumentsServiceDB>();
            container.RegisterType<ICustomerService, CustomerServiceDB>();
            var mainWindow = container.Resolve<MainWindow>();
            Application.Current.MainWindow = mainWindow;
            Application.Current.MainWindow.Show();
        }
    }
}
