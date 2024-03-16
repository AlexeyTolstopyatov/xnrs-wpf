using System;
using System.IO;
using System.Windows;
using System.Xml;
using System.Xml.Xsl;
using Microsoft.Win32;

namespace xnrs.Core
{
    public class Document
    {

        public static string Read(string path, string sheet)
        {
            var xdoc = new XmlDocument();

            // 1) Открыть записку
            try
            {
                xdoc.Load(path);
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удается открыть файл "+path);
            }
            
            XslCompiledTransform transform = new XslCompiledTransform();
            XmlDocument xml = new XmlDocument();
            xml.Load(path);

            
            transform.Load(sheet);

            StringWriter results = new StringWriter();
            using (XmlReader reader = XmlReader.Create(path))
            {
                transform.Transform(reader , null , results);
            }
            return results.ToString();
        }

    }
}
