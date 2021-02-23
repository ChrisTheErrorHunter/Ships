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
        private TileState[] displayState = new TileState[100];
        private TileState[] playState = new TileState[100];
        private int setterCounter = 0;
        private bool isVertical = false;
        private ImageBrush waterBrush = new ImageBrush();
        private ImageBrush fireBrush = new ImageBrush();
        private ImageBrush shipBrush = new ImageBrush();
        private ImageBrush sunkBrush = new ImageBrush();
        private ImageBrush aimBrush = new ImageBrush();
        private ImageBrush currentBrush = new ImageBrush();
        private Ship Ship40 = new Ship(4, 40);
        private Ship Ship30 = new Ship(3, 30);
        private Ship Ship31 = new Ship(3, 31);
        private Ship Ship20 = new Ship(2, 20);
        private Ship Ship21 = new Ship(2, 21);
        private Ship Ship22 = new Ship(2, 22);
        private Ship Ship10 = new Ship(1, 10);
        private Ship Ship11 = new Ship(1, 11);
        private Ship Ship12 = new Ship(1, 12);
        private Ship Ship13 = new Ship(1, 13);

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
            if (clickMode == ClickMode.shoot) return;
            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            if(clickMode == ClickMode.setFourSailer)
            {
                if(isVertical)
                {
                    if(row + 3 <= 10)
                    {
                        if(displayState[(row - 1)*10 + column - 1] == TileState.Unknown &&
                           displayState[(row) * 10 + column - 1] == TileState.Unknown &&
                           displayState[(row + 1) * 10 + column - 1] == TileState.Unknown &&
                           displayState[(row +2) * 10 + column - 1] == TileState.Unknown)
                        {
                            displayState[(row - 1) * 10 + column - 1] = TileState.Ally;
                            displayState[(row) * 10 + column - 1] = TileState.Ally;
                            displayState[(row + 1) * 10 + column - 1] = TileState.Ally;
                            displayState[(row + 2) * 10 + column - 1] = TileState.Ally;
                            UpdateDisplayBoard();
                            Ship40.SetSail(row, column, isVertical);
                            clickMode = ClickMode.setThreeSailer;
                        }
                    }
                }
                else
                {
                    if (column + 3 <= 10)
                    {
                        if (displayState[(row - 1) * 10 + column - 1] == TileState.Unknown &&
                           displayState[(row - 1) * 10 + column] == TileState.Unknown &&
                           displayState[(row - 1) * 10 + column + 1] == TileState.Unknown &&
                           displayState[(row - 1) * 10 + column + 2] == TileState.Unknown)
                        {
                            displayState[(row - 1) * 10 + column - 1] = TileState.Ally;
                            displayState[(row - 1) * 10 + column] = TileState.Ally;
                            displayState[(row - 1) * 10 + column + 1] = TileState.Ally;
                            displayState[(row - 1) * 10 + column + 2] = TileState.Ally;
                            UpdateDisplayBoard();
                            Ship40.SetSail(row, column, isVertical);
                            clickMode = ClickMode.setThreeSailer;
                        }
                    }

                }
            }
            else if(clickMode == ClickMode.setThreeSailer)
            {
                if (isVertical)
                {
                    if (row + 2 <= 10)
                    {
                        if (displayState[(row - 1) * 10 + column - 1] == TileState.Unknown &&
                           displayState[(row) * 10 + column - 1] == TileState.Unknown &&
                           displayState[(row + 1) * 10 + column - 1] == TileState.Unknown)
                        {
                            displayState[(row - 1) * 10 + column - 1] = TileState.Ally;
                            displayState[(row) * 10 + column - 1] = TileState.Ally;
                            displayState[(row + 1) * 10 + column - 1] = TileState.Ally;
                            UpdateDisplayBoard();
                            if (setterCounter == 0) Ship30.SetSail(row, column, isVertical);
                            else Ship31.SetSail(row, column, isVertical);
                            setterCounter++;
                            if(setterCounter > 1)
                            {
                                clickMode = ClickMode.setTwoSailer;
                                setterCounter = 0;
                            }
                        }
                    }
                }
                else
                {
                    if (column + 2 <= 10)
                    {
                        if (displayState[(row - 1) * 10 + column - 1] == TileState.Unknown &&
                           displayState[(row - 1) * 10 + column] == TileState.Unknown &&
                           displayState[(row - 1) * 10 + column + 1] == TileState.Unknown)
                        {
                            displayState[(row - 1) * 10 + column - 1] = TileState.Ally;
                            displayState[(row - 1) * 10 + column] = TileState.Ally;
                            displayState[(row - 1) * 10 + column + 1] = TileState.Ally;
                            UpdateDisplayBoard();
                            if (setterCounter == 0) Ship30.SetSail(row, column, isVertical);
                            else Ship31.SetSail(row, column, isVertical);
                            setterCounter++;
                            if (setterCounter > 1)
                            {
                                clickMode = ClickMode.setTwoSailer;
                                setterCounter = 0;
                            }
                        }
                    }

                }
            }
            else if(clickMode == ClickMode.setTwoSailer)
            {
                if (isVertical)
                {
                    if (row + 1 <= 10)
                    {
                        if (displayState[(row - 1) * 10 + column - 1] == TileState.Unknown &&
                           displayState[(row) * 10 + column - 1] == TileState.Unknown)
                        {
                            displayState[(row - 1) * 10 + column - 1] = TileState.Ally;
                            displayState[(row) * 10 + column - 1] = TileState.Ally;
                            UpdateDisplayBoard();
                            if (setterCounter == 0) Ship20.SetSail(row, column, isVertical);
                            else if (setterCounter == 1) Ship21.SetSail(row, column, isVertical);
                            else Ship22.SetSail(row, column, isVertical);
                            setterCounter++;
                            if (setterCounter > 2)
                            {
                                clickMode = ClickMode.setOneSailer;
                                setterCounter = 0;
                            }
                        }
                    }
                }
                else
                {
                    if (column + 1 <= 10)
                    {
                        if (displayState[(row - 1) * 10 + column - 1] == TileState.Unknown &&
                           displayState[(row - 1) * 10 + column] == TileState.Unknown)
                        {
                            displayState[(row - 1) * 10 + column - 1] = TileState.Ally;
                            displayState[(row - 1) * 10 + column] = TileState.Ally;
                            UpdateDisplayBoard();
                            if (setterCounter == 0) Ship20.SetSail(row, column, isVertical);
                            else if (setterCounter == 1) Ship21.SetSail(row, column, isVertical);
                            else Ship22.SetSail(row, column, isVertical);
                            setterCounter++;
                            if (setterCounter > 2)
                            {
                                clickMode = ClickMode.setOneSailer;
                                setterCounter = 0;
                            }
                        }
                    }

                }
            }
            else if(clickMode == ClickMode.setOneSailer)
            {
                        if (displayState[(row - 1) * 10 + column - 1] == TileState.Unknown)
                        {
                            displayState[(row - 1) * 10 + column - 1] = TileState.Ally;
                            UpdateDisplayBoard();
                    if (setterCounter == 0) Ship10.SetSail(row, column, isVertical);
                    else if (setterCounter == 1) Ship11.SetSail(row, column, isVertical);
                    else if (setterCounter == 2) Ship12.SetSail(row, column, isVertical);
                    else Ship13.SetSail(row, column, isVertical);
                    setterCounter++;
                            if (setterCounter > 3)
                            {
                                clickMode = ClickMode.standby;
                                setterCounter = 0;
                            }
                        }
            }

        }

        private void ButtonBrusher(TileState state, Button button)
        {
            if (state == TileState.Unknown) button.Background = waterBrush;
            else if (state == TileState.Ally) button.Background = shipBrush;
            else if (state == TileState.Hit) button.Background = fireBrush;
            else if (state == TileState.Sunk) button.Background = sunkBrush;
            else return;
        }

        private void Mouse_Enter_DisplayTile(object sender, RoutedEventArgs e)
        {
            if (clickMode == ClickMode.shoot) return;
            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            TileState[] tmp = new TileState[100];
            displayState.CopyTo(tmp, 0);
            if (clickMode == ClickMode.setFourSailer)
            {
                displayState.CopyTo(tmp, 0);
                if (isVertical)
                {
                    if (row + 3 <= 10)
                    {
                        if (displayState[(row - 1) * 10 + column - 1] == TileState.Unknown &&
                           displayState[(row) * 10 + column - 1] == TileState.Unknown &&
                           displayState[(row + 1) * 10 + column - 1] == TileState.Unknown &&
                           displayState[(row + 2) * 10 + column - 1] == TileState.Unknown)
                        {
                            displayState[(row - 1) * 10 + column - 1] = TileState.Ally;
                            displayState[(row) * 10 + column - 1] = TileState.Ally;
                            displayState[(row + 1) * 10 + column - 1] = TileState.Ally;
                            displayState[(row + 2) * 10 + column - 1] = TileState.Ally;
                            UpdateDisplayBoard();
                            tmp.CopyTo(displayState, 0);
                        }
                    }
                }
                else
                {
                    if (column + 3 <= 10)
                    {
                        if (displayState[(row - 1) * 10 + column - 1] == TileState.Unknown &&
                           displayState[(row - 1) * 10 + column] == TileState.Unknown &&
                           displayState[(row - 1) * 10 + column + 1] == TileState.Unknown &&
                           displayState[(row - 1) * 10 + column + 2] == TileState.Unknown)
                        {
                            displayState[(row - 1) * 10 + column - 1] = TileState.Ally;
                            displayState[(row - 1) * 10 + column] = TileState.Ally;
                            displayState[(row - 1) * 10 + column + 1] = TileState.Ally;
                            displayState[(row - 1) * 10 + column + 2] = TileState.Ally;
                            UpdateDisplayBoard();
                            tmp.CopyTo(displayState, 0);
                        }
                    }

                }
            }
            else if (clickMode == ClickMode.setThreeSailer)
            {
                if (isVertical)
                {
                    if (row + 2 <= 10)
                    {
                        if (displayState[(row - 1) * 10 + column - 1] == TileState.Unknown &&
                           displayState[(row) * 10 + column - 1] == TileState.Unknown &&
                           displayState[(row + 1) * 10 + column - 1] == TileState.Unknown)
                        {
                            displayState[(row - 1) * 10 + column - 1] = TileState.Ally;
                            displayState[(row) * 10 + column - 1] = TileState.Ally;
                            displayState[(row + 1) * 10 + column - 1] = TileState.Ally;
                            UpdateDisplayBoard();
                            tmp.CopyTo(displayState, 0);
                        }
                    }
                }
                else
                {
                    if (column + 2 <= 10)
                    {
                        if (displayState[(row - 1) * 10 + column - 1] == TileState.Unknown &&
                           displayState[(row - 1) * 10 + column] == TileState.Unknown &&
                           displayState[(row - 1) * 10 + column + 1] == TileState.Unknown)
                        {
                            displayState[(row - 1) * 10 + column - 1] = TileState.Ally;
                            displayState[(row - 1) * 10 + column] = TileState.Ally;
                            displayState[(row - 1) * 10 + column + 1] = TileState.Ally;
                            UpdateDisplayBoard();
                            tmp.CopyTo(displayState, 0);
                        }
                    }

                }
            }
            else if (clickMode == ClickMode.setTwoSailer)
            {
                if (isVertical)
                {
                    if (row + 1 <= 10)
                    {
                        if (displayState[(row - 1) * 10 + column - 1] == TileState.Unknown &&
                           displayState[(row) * 10 + column - 1] == TileState.Unknown)
                        {
                            displayState[(row - 1) * 10 + column - 1] = TileState.Ally;
                            displayState[(row) * 10 + column - 1] = TileState.Ally;
                            UpdateDisplayBoard();
                            tmp.CopyTo(displayState, 0);
                        }
                    }
                }
                else
                {
                    if (column + 1 <= 10)
                    {
                        if (displayState[(row - 1) * 10 + column - 1] == TileState.Unknown &&
                           displayState[(row - 1) * 10 + column] == TileState.Unknown)
                        {
                            displayState[(row - 1) * 10 + column - 1] = TileState.Ally;
                            displayState[(row - 1) * 10 + column] = TileState.Ally;
                            UpdateDisplayBoard();
                            tmp.CopyTo(displayState, 0);
                        }
                    }

                }
            }
            else if (clickMode == ClickMode.setOneSailer)
            {
                if (displayState[(row - 1) * 10 + column - 1] == TileState.Unknown)
                {
                    displayState[(row - 1) * 10 + column - 1] = TileState.Ally;
                    UpdateDisplayBoard();
                    displayState[(row - 1) * 10 + column - 1] = TileState.Unknown;
                }
            }
        }

        private void Mouse_Exit_DisplayTile(object sender, RoutedEventArgs e)
        {
            UpdateDisplayBoard();
        }

        private void UpdateDisplayBoard()
        {
            ButtonBrusher(displayState[0], DB00);
            ButtonBrusher(displayState[1], DB01);
            ButtonBrusher(displayState[2], DB02);
            ButtonBrusher(displayState[3], DB03);
            ButtonBrusher(displayState[4], DB04);
            ButtonBrusher(displayState[5], DB05);
            ButtonBrusher(displayState[6], DB06);
            ButtonBrusher(displayState[7], DB07);
            ButtonBrusher(displayState[8], DB08);
            ButtonBrusher(displayState[9], DB09);
            ButtonBrusher(displayState[10], DB10);
            ButtonBrusher(displayState[11], DB11);
            ButtonBrusher(displayState[12], DB12);
            ButtonBrusher(displayState[13], DB13);
            ButtonBrusher(displayState[14], DB14);
            ButtonBrusher(displayState[15], DB15);
            ButtonBrusher(displayState[16], DB16);
            ButtonBrusher(displayState[17], DB17);
            ButtonBrusher(displayState[18], DB18);
            ButtonBrusher(displayState[19], DB19);
            ButtonBrusher(displayState[20], DB20);
            ButtonBrusher(displayState[21], DB21);
            ButtonBrusher(displayState[22], DB22);
            ButtonBrusher(displayState[23], DB23);
            ButtonBrusher(displayState[24], DB24);
            ButtonBrusher(displayState[25], DB25);
            ButtonBrusher(displayState[26], DB26);
            ButtonBrusher(displayState[27], DB27);
            ButtonBrusher(displayState[28], DB28);
            ButtonBrusher(displayState[29], DB29);
            ButtonBrusher(displayState[30], DB30);
            ButtonBrusher(displayState[31], DB31);
            ButtonBrusher(displayState[32], DB32);
            ButtonBrusher(displayState[33], DB33);
            ButtonBrusher(displayState[34], DB34);
            ButtonBrusher(displayState[35], DB35);
            ButtonBrusher(displayState[36], DB36);
            ButtonBrusher(displayState[37], DB37);
            ButtonBrusher(displayState[38], DB38);
            ButtonBrusher(displayState[39], DB39);
            ButtonBrusher(displayState[40], DB40);
            ButtonBrusher(displayState[41], DB41);
            ButtonBrusher(displayState[42], DB42);
            ButtonBrusher(displayState[43], DB43);
            ButtonBrusher(displayState[44], DB44);
            ButtonBrusher(displayState[45], DB45);
            ButtonBrusher(displayState[46], DB46);
            ButtonBrusher(displayState[47], DB47);
            ButtonBrusher(displayState[48], DB48);
            ButtonBrusher(displayState[49], DB49);
            ButtonBrusher(displayState[50], DB50);
            ButtonBrusher(displayState[51], DB51);
            ButtonBrusher(displayState[52], DB52);
            ButtonBrusher(displayState[53], DB53);
            ButtonBrusher(displayState[54], DB54);
            ButtonBrusher(displayState[55], DB55);
            ButtonBrusher(displayState[56], DB56);
            ButtonBrusher(displayState[57], DB57);
            ButtonBrusher(displayState[58], DB58);
            ButtonBrusher(displayState[59], DB59);
            ButtonBrusher(displayState[60], DB60);
            ButtonBrusher(displayState[61], DB61);
            ButtonBrusher(displayState[62], DB62);
            ButtonBrusher(displayState[63], DB63);
            ButtonBrusher(displayState[64], DB64);
            ButtonBrusher(displayState[65], DB65);
            ButtonBrusher(displayState[66], DB66);
            ButtonBrusher(displayState[67], DB67);
            ButtonBrusher(displayState[68], DB68);
            ButtonBrusher(displayState[69], DB69);
            ButtonBrusher(displayState[70], DB70);
            ButtonBrusher(displayState[71], DB71);
            ButtonBrusher(displayState[72], DB72);
            ButtonBrusher(displayState[73], DB73);
            ButtonBrusher(displayState[74], DB74);
            ButtonBrusher(displayState[75], DB75);
            ButtonBrusher(displayState[76], DB76);
            ButtonBrusher(displayState[77], DB77);
            ButtonBrusher(displayState[78], DB78);
            ButtonBrusher(displayState[79], DB79);
            ButtonBrusher(displayState[80], DB80);
            ButtonBrusher(displayState[81], DB81);
            ButtonBrusher(displayState[82], DB82);
            ButtonBrusher(displayState[83], DB83);
            ButtonBrusher(displayState[84], DB84);
            ButtonBrusher(displayState[85], DB85);
            ButtonBrusher(displayState[86], DB86);
            ButtonBrusher(displayState[87], DB87);
            ButtonBrusher(displayState[88], DB88);
            ButtonBrusher(displayState[89], DB89);
            ButtonBrusher(displayState[90], DB90);
            ButtonBrusher(displayState[91], DB91);
            ButtonBrusher(displayState[92], DB92);
            ButtonBrusher(displayState[93], DB93);
            ButtonBrusher(displayState[94], DB94);
            ButtonBrusher(displayState[95], DB95);
            ButtonBrusher(displayState[96], DB96);
            ButtonBrusher(displayState[97], DB97);
            ButtonBrusher(displayState[98], DB98);
            ButtonBrusher(displayState[99], DB99);
        }

        private void UpdatePlayBoard()
        {
            ButtonBrusher(playState[0], PB00);
            ButtonBrusher(playState[1], PB01);
            ButtonBrusher(playState[2], PB02);
            ButtonBrusher(playState[3], PB03);
            ButtonBrusher(playState[4], PB04);
            ButtonBrusher(playState[5], PB05);
            ButtonBrusher(playState[6], PB06);
            ButtonBrusher(playState[7], PB07);
            ButtonBrusher(playState[8], PB08);
            ButtonBrusher(playState[9], PB09);
            ButtonBrusher(playState[10], PB10);
            ButtonBrusher(playState[11], PB11);
            ButtonBrusher(playState[12], PB12);
            ButtonBrusher(playState[13], PB13);
            ButtonBrusher(playState[14], PB14);
            ButtonBrusher(playState[15], PB15);
            ButtonBrusher(playState[16], PB16);
            ButtonBrusher(playState[17], PB17);
            ButtonBrusher(playState[18], PB18);
            ButtonBrusher(playState[19], PB19);
            ButtonBrusher(playState[20], PB20);
            ButtonBrusher(playState[21], PB21);
            ButtonBrusher(playState[22], PB22);
            ButtonBrusher(playState[23], PB23);
            ButtonBrusher(playState[24], PB24);
            ButtonBrusher(playState[25], PB25);
            ButtonBrusher(playState[26], PB26);
            ButtonBrusher(playState[27], PB27);
            ButtonBrusher(playState[28], PB28);
            ButtonBrusher(playState[29], PB29);
            ButtonBrusher(playState[30], PB30);
            ButtonBrusher(playState[31], PB31);
            ButtonBrusher(playState[32], PB32);
            ButtonBrusher(playState[33], PB33);
            ButtonBrusher(playState[34], PB34);
            ButtonBrusher(playState[35], PB35);
            ButtonBrusher(playState[36], PB36);
            ButtonBrusher(playState[37], PB37);
            ButtonBrusher(playState[38], PB38);
            ButtonBrusher(playState[39], PB39);
            ButtonBrusher(playState[40], PB40);
            ButtonBrusher(playState[41], PB41);
            ButtonBrusher(playState[42], PB42);
            ButtonBrusher(playState[43], PB43);
            ButtonBrusher(playState[44], PB44);
            ButtonBrusher(playState[45], PB45);
            ButtonBrusher(playState[46], PB46);
            ButtonBrusher(playState[47], PB47);
            ButtonBrusher(playState[48], PB48);
            ButtonBrusher(playState[49], PB49);
            ButtonBrusher(playState[50], PB50);
            ButtonBrusher(playState[51], PB51);
            ButtonBrusher(playState[52], PB52);
            ButtonBrusher(playState[53], PB53);
            ButtonBrusher(playState[54], PB54);
            ButtonBrusher(playState[55], PB55);
            ButtonBrusher(playState[56], PB56);
            ButtonBrusher(playState[57], PB57);
            ButtonBrusher(playState[58], PB58);
            ButtonBrusher(playState[59], PB59);
            ButtonBrusher(playState[60], PB60);
            ButtonBrusher(playState[61], PB61);
            ButtonBrusher(playState[62], PB62);
            ButtonBrusher(playState[63], PB63);
            ButtonBrusher(playState[64], PB64);
            ButtonBrusher(playState[65], PB65);
            ButtonBrusher(playState[66], PB66);
            ButtonBrusher(playState[67], PB67);
            ButtonBrusher(playState[68], PB68);
            ButtonBrusher(playState[69], PB69);
            ButtonBrusher(playState[70], PB70);
            ButtonBrusher(playState[71], PB71);
            ButtonBrusher(playState[72], PB72);
            ButtonBrusher(playState[73], PB73);
            ButtonBrusher(playState[74], PB74);
            ButtonBrusher(playState[75], PB75);
            ButtonBrusher(playState[76], PB76);
            ButtonBrusher(playState[77], PB77);
            ButtonBrusher(playState[78], PB78);
            ButtonBrusher(playState[79], PB79);
            ButtonBrusher(playState[80], PB80);
            ButtonBrusher(playState[81], PB81);
            ButtonBrusher(playState[82], PB82);
            ButtonBrusher(playState[83], PB83);
            ButtonBrusher(playState[84], PB84);
            ButtonBrusher(playState[85], PB85);
            ButtonBrusher(playState[86], PB86);
            ButtonBrusher(playState[87], PB87);
            ButtonBrusher(playState[88], PB88);
            ButtonBrusher(playState[89], PB89);
            ButtonBrusher(playState[90], PB90);
            ButtonBrusher(playState[91], PB91);
            ButtonBrusher(playState[92], PB92);
            ButtonBrusher(playState[93], PB93);
            ButtonBrusher(playState[94], PB94);
            ButtonBrusher(playState[95], PB95);
            ButtonBrusher(playState[96], PB96);
            ButtonBrusher(playState[97], PB97);
            ButtonBrusher(playState[98], PB98);
            ButtonBrusher(playState[99], PB99);
        }

        private void ChVerticallytyButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if(isVertical)
            {
                button.Content = "Ustawaj pionowo";
                isVertical = false;
            }
            else
            {
                button.Content = "Ustawaj poziomo";
                isVertical = true;
            }
        }

        private void Mouse_Enter_PlayTile(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            currentBrush = (ImageBrush)button.Background;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = (row - 1) * 10 + (column - 1);
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
            playState.ToList<TileState>().ForEach(member => member = TileState.Unknown);
            displayState.ToList<TileState>().ForEach(member => member = TileState.Unknown);
            DisplayContainer.Children.Cast<Control>().ToList().ForEach(button =>
            {
                if(button is Button && button.Name != "ChVerticallytyButton") button.Background = waterBrush;
            });
            PlayContainer.Children.Cast<Control>().ToList().ForEach(button =>
            {
                if(button is Button) button.Background = waterBrush;
            });
            clickMode = ClickMode.setFourSailer;
            /*DB02.Background = waterBrush;
            DB03.Background = sunkBrush;
            DB04.Background = fireBrush;
            DB05.Background = shipBrush;
            DB06.Background = aimBrush;*/

        }

    }
}
