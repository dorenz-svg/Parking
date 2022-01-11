using Autofac;
using Parking.Core;
using Parking.DataAccess.SQL;
using System;
using System.Windows.Forms;

namespace Parking.UI
{
    static class Program
    {
        public static IContainer Container { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var builder = new ContainerBuilder();
            builder.RegisterModule<CoreDependencyModule>();
            builder.RegisterModule<DataAccessDependencyModule>();
            builder.RegisterModule<UIDependencyModule>();
            Container = builder.Build();
            using (var form= Container.Resolve<Main>())
            {
                Application.Run(form);
            }
        }
    }
}
