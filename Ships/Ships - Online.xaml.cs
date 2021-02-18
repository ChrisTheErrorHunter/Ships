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
        private ClickMode clickMode = new ClickMode();
        private ImageBrush waterBrush = new ImageBrush();
        private ImageBrush fireBrush = new ImageBrush();
        private ImageBrush shipBrush = new ImageBrush();
        private ImageBrush sunkBrush = new ImageBrush();
        private ImageBrush aimBrush = new ImageBrush();
        private ImageBrush currentBrush = new ImageBrush();
        public Ships___Online()
        {
            InitializeComponent();
            InitializeBrushes();
            NewGame();

        }

        private void InitializeBrushes()
        {
            Uri resourceUri = new Uri("Resources/watericon.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            waterBrush.ImageSource = temp;
            resourceUri = new Uri("Resources/sunkicon.png", UriKind.Relative);
            streamInfo = Application.GetResourceStream(resourceUri);
            temp = BitmapFrame.Create(streamInfo.Stream);
            sunkBrush.ImageSource = temp;
            resourceUri = new Uri("Resources/fireicon.png", UriKind.Relative);
            streamInfo = Application.GetResourceStream(resourceUri);
            temp = BitmapFrame.Create(streamInfo.Stream);
            fireBrush.ImageSource = temp;
            resourceUri = new Uri("Resources/shipicon.png", UriKind.Relative);
            streamInfo = Application.GetResourceStream(resourceUri);
            temp = BitmapFrame.Create(streamInfo.Stream);
            shipBrush.ImageSource = temp;
            resourceUri = new Uri("Resources/aimicon.png", UriKind.Relative);
            streamInfo = Application.GetResourceStream(resourceUri);
            temp = BitmapFrame.Create(streamInfo.Stream);
            aimBrush.ImageSource = temp;
        }

        private void PlayTile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DisplayTile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Mouse_Enter_PlayTile(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            currentBrush = (ImageBrush)button.Background;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column + (row * 10);
            button.Background = aimBrush;
          //  button.Background = currentBrush;
        }

        private void Mouse_Exit_PlayTile(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            button.Background = currentBrush;
        }

        private void NewGame()
        {
            DisplayContainer.Children.Cast<Control>().ToList().ForEach(button =>
            {
                if(button is Button) button.Background = waterBrush;
            });
            PlayContainer.Children.Cast<Control>().ToList().ForEach(button =>
            {
                if(button is Button) button.Background = waterBrush;
            });
            /*DB02.Background = waterBrush;
            DB03.Background = sunkBrush;
            DB04.Background = fireBrush;
            DB05.Background = shipBrush;
            DB06.Background = aimBrush;*/

        }
    }
}
