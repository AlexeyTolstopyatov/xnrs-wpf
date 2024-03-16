using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace xnrs.View
{
    /// <summary>
    /// Логика взаимодействия для BrowserWindow.xaml
    /// </summary>
    public partial class BrowserWindow : Window
    {
        public BrowserWindow(string address)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(address)) 
            {
                address = 
                    "<meta charset=\"utf-8\">" +
                    "<h1>Не удалось прочитать документ</h1>" +
                    "<p>Убедитесь в том, вы открываете документ, который был проверен указаной вами схемой определения.</p>";

                
            }

            Browser.NavigateToString(address);
        }
    }
}
