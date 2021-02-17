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
using System.Windows.Resources;

namespace Ships
{
    /// <summary>
    /// Logika interakcji dla klasy Ships___Online.xaml
    /// </summary>
    public partial class Ships___Online : Window
    {
        public Ships___Online()
        {
            InitializeComponent();
            //var watericon = new ImageBrush();
            // watericon.ImageSource = new BitmapImage(new Uri("Resources/watericon.png", UriKind.Relative));
            //  DB02.Background = watericon;
            Uri resourceUri = new Uri("Resources/watericon.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            var brush = new ImageBrush();
            brush.ImageSource = temp;

            DB02.Background = brush;

        }

        private void PlayTile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewGame()
        {

        }
    }
}
