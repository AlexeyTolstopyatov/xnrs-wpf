using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using xnrs.View;

namespace xnrs
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string? Path { get; private set; }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            if (e.Args.Length != 0)
                Path = e.Args[0];
            

            base.OnStartup(e);
        }
    }
}
