using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;

namespace AdeptusWpf
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void AboutWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.ShowVersion();
        }

        private void ShowVersion()
        {
            AssemblyCompanyAttribute objCompany = (AssemblyCompanyAttribute)
                AssemblyCompanyAttribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
                typeof(AssemblyCompanyAttribute));
            AssemblyDescriptionAttribute objDescription = (AssemblyDescriptionAttribute)
                AssemblyDescriptionAttribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
                typeof(AssemblyDescriptionAttribute));
            AssemblyProductAttribute objProduct = (AssemblyProductAttribute)
                AssemblyProductAttribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
                typeof(AssemblyProductAttribute));
            AssemblyTitleAttribute objTitle = (AssemblyTitleAttribute)
                AssemblyTitleAttribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
                typeof(AssemblyTitleAttribute));
            /*
            AssemblyVersionAttribute objVersion = (AssemblyVersionAttribute)
                AssemblyVersionAttribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
                typeof(AssemblyVersionAttribute));
            */
            StringBuilder sb = new StringBuilder();
            sb.Append("Product: ");
            sb.AppendLine(objProduct.Product);
            sb.Append("Title: ");
            sb.AppendLine(objTitle.Title);
            sb.Append("Company: ");
            sb.AppendLine(objCompany.Company);
            sb.Append("Description: ");
            sb.AppendLine(objDescription.Description);
            sb.Append("Version: ");
            sb.AppendLine(Assembly.GetExecutingAssembly().GetName().Version.ToString());
            this.AboutText.Text = sb.ToString();
        }

        private void ShowCopyright()
        {
            StringBuilder sb = new StringBuilder();
            AssemblyCopyrightAttribute objCopyright = (AssemblyCopyrightAttribute)
                AssemblyCopyrightAttribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
                typeof(AssemblyCopyrightAttribute));
            sb.Append("Copyright: ");
            sb.AppendLine(objCopyright.Copyright);
            sb.AppendLine("© Games Workshop Limited 2011. Games Workshop, Warhammer 40,000, Warhammer 40,000 Role Play, Dark Heresy, the foregoing marks' respective logos, Rogue Trader, Dark Heresy and all associated marks, logos, places, names, creatures, races and race insignia/devices/logos/symbols, vehicles, locations, weapons, units and unit insignia, characters, products and illustrations from the Warhammer 40,000 universe and the Dark Heresy game setting are either ®, TM and/or © Games Workshop Ltd 2000–2011, variably registered in the UK and other countries around the world. This edition published under license to Fantasy Flight Publishing Inc. All Rights Reserved to their respective owners.");
            this.AboutText.Text = sb.ToString();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Copyright_Click(object sender, RoutedEventArgs e)
        {
            if (Copyright.Content.Equals("Copyright"))
            {
                this.ShowCopyright();
                this.Copyright.Content = "Version";
            }
            else
            {
                this.ShowVersion();
                this.Copyright.Content = "Copyright";
            }
        }
    }
}
