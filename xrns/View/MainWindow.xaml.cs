using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

using Microsoft.Win32;

using xnrs.Core;



namespace xnrs.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        

        public MainWindow()
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(App.Path))
                return;

            Open(App.Path);
        }

        private void OpenButtonClick(object sender , RoutedEventArgs e)
        {
            // 1) создание FileDialog
            var ofd = new OpenFileDialog();

            ofd.Filter = "Пояснительная записка (*.XML) |*.xml";
            ofd.Title = "Открытие пояснительной записки";
            ofd.Multiselect = false;

            // 2) запуск FileDialog
            ofd.ShowDialog();

            if (string.IsNullOrEmpty(ofd.FileName))
                return;

            // 3) сохранение данных и остальное в Open();
            Open(ofd.FileName);
        }

        private string[] Styles 
        {
            get 
            {
                // Получаем список файлов в папке
                FileInfo[] fileInfos = new DirectoryInfo($"{AppDomain.CurrentDomain.BaseDirectory}\\def").GetFiles();

                // Извлекаем имена файлов
                string[] fileNames = fileInfos.Select(fileInfo => fileInfo.Name).ToArray();

                return fileNames;
            }
        }

        private void Open(string file)
        {
            StylesWindow window = 
                new StylesWindow(Styles);

            window.ShowDialog();

            string sheetfile = $"{AppDomain.CurrentDomain.BaseDirectory}\\def\\" + window.Sheet;

            var result = Document.Read(file, sheetfile);

            if (result == null)
                return;

            new BrowserWindow(result).Show();

        }

        
    }
}
 