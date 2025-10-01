using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Data.Common;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using static System.Net.Mime.MediaTypeNames;

namespace opros
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Polzunok.RenderTransform = polz;
            Phase2.RenderTransform = ph2;
            NuhUh.RenderTransform = NU;
            CrGrid.RenderTransform = CG;
            RedGrid.RenderTransform = RG;
            SeeGrid.RenderTransform = SG;
            ImprGrid.RenderTransform = IG;
            RedSpace.RenderTransform = RS;
            polz.Y = -140;

            mainWindow = this;
            MiniUpd();            
            Uptade();

            ChWhat[0] = 0;
            ChWhat[1] = 1;
            ChWhat[2] = 2;

            for(int i = 0; i < 9; i++)
            {
                VseOtveti[i, 0] = "";
                VseOtveti[i, 1] = "";
                RedVseOtveti[i, 0] = "";
                RedVseOtveti[i, 1] = "";
            }

            ChoosUpd();            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.R)
            {
            }
        }
        private async void SeeAll_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(chto != -1)
            {
                if (AS)
                {
                    AS = false;

                    tuda.From = WidthPolz();
                    tuda.To = 150;
                    tuda.Duration = TimeSpan.FromSeconds(2);
                    mainWindow.BeginAnimation(MainWindow.WidthProperty, tuda);
                    no = true;
                    await Task.Delay(2000);
                    no = false;
                    mainWindow.BeginAnimation(WidthProperty, null);
                }
                else
                {
                    AS = true;

                    tuda.From = 150;
                    tuda.To = WidthPolz();
                    tuda.Duration = TimeSpan.FromSeconds(2);
                    mainWindow.BeginAnimation(WidthProperty, tuda);
                    no = true;
                    await Task.Delay(2000);
                    no = false;
                    mainWindow.BeginAnimation(WidthProperty, null);
                }
            }
        }

        private void CrBord_MouseEnter(object sender, MouseEventArgs e)
        {
            CrBord.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF545454"));
            if (chto != 0)
                CrText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFBFBFBF"));
        }

        private void CrBord_MouseLeave(object sender, MouseEventArgs e)
        {
            CrBord.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCECECE"));
            if (chto != 0)
                CrText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF464646"));
        }

        private void RedBord_MouseEnter(object sender, MouseEventArgs e)
        {
            RedBord.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF545454"));
            if (chto != 1)
                RedText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFBFBFBF"));
        }

        private void RedBord_MouseLeave(object sender, MouseEventArgs e)
        {
            RedBord.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCECECE"));
            if (chto != 1)
                RedText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF464646"));
        }

        private void SeeAll_MouseEnter(object sender, MouseEventArgs e)
        {
            SeeAll.Background = Brushes.DarkGray;
        }

        private void SeeAll_MouseLeave(object sender, MouseEventArgs e)
        {
            SeeAll.Background = Brushes.Black;
        }

        private void SeeBord_MouseEnter(object sender, MouseEventArgs e)
        {
            SeeBord.Background = Brushes.DarkGray;
        }

        private void SeeBord_MouseLeave(object sender, MouseEventArgs e)
        {
            SeeBord.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCECECE"));
            if (chto != 2)
                SeeText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF464646"));
        }

        private void ImprBord_MouseEnter(object sender, MouseEventArgs e)
        {
            ImprBord.Background = Brushes.DarkGray;
        }

        private void ImprBord_MouseLeave(object sender, MouseEventArgs e)
        {
            ImprBord.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCECECE"));
            if (chto != 3)
                ImprText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF464646"));
        }

        private void CrBord_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(chto == -1)
                chto = 4;
            tuda.Duration = TimeSpan.FromSeconds(1);

            if (AS == false)
            {
                SeeAll_MouseLeftButtonDown(null, e);
                CrGrid.Opacity = 1;
                CG.Y = 490;
            }
                
            else if (chto != 0)
            {
                tuda.From = RedBord.Opacity;
                tuda.To = 0;
                RedGrid.BeginAnimation(OpacityProperty, tuda);
                tuda.From = SeeGrid.Opacity;
                tuda.To = 0;
                SeeGrid.BeginAnimation(OpacityProperty, tuda);
                tuda.From = ImprGrid.Opacity;
                tuda.To = 0;
                ImprGrid.BeginAnimation(OpacityProperty, tuda);

                tuda.From = RG.Y;
                tuda.To = 1000;
                RG.BeginAnimation(TranslateTransform.YProperty, tuda);
                tuda.From = SG.Y;
                tuda.To = 1000;
                SG.BeginAnimation(TranslateTransform.YProperty, tuda);
                tuda.From = IG.Y;
                tuda.To = 1000;
                IG.BeginAnimation(TranslateTransform.YProperty, tuda);

                tuda.From = 0;
                tuda.To = 490;
                CG.BeginAnimation(TranslateTransform.YProperty, tuda);

                tuda.From = 0;
                tuda.To = 1;
                CrGrid.BeginAnimation(OpacityProperty, tuda);
            }

            chto = 0;
            MiniUpd();
            ResetSee();
        }

        private void RedBord_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (chto == -1)
                chto = 4;
            tuda.Duration = TimeSpan.FromSeconds(1);

            if (AS == false)
            {
                SeeAll_MouseLeftButtonDown(null, e);
                RedBord.Opacity = 1;
                RG.Y = 490;
            }
            else if(chto != 1)
            {
                tuda.From = CrGrid.Opacity;
                tuda.To = 0;
                CrGrid.BeginAnimation(OpacityProperty, tuda);
                tuda.From = SeeGrid.Opacity;
                tuda.To = 0;
                SeeGrid.BeginAnimation(OpacityProperty, tuda);
                tuda.From = ImprGrid.Opacity;
                tuda.To = 0;
                ImprGrid.BeginAnimation(OpacityProperty, tuda);

                tuda.From = CG.Y;
                tuda.To = 1000;
                CG.BeginAnimation(TranslateTransform.YProperty, tuda);
                tuda.From = SG.Y;
                tuda.To = 1000;
                SG.BeginAnimation(TranslateTransform.YProperty, tuda);
                tuda.From = IG.Y;
                tuda.To = 1000;
                IG.BeginAnimation(TranslateTransform.YProperty, tuda);

                tuda.From = 0;
                tuda.To = 490;
                RG.BeginAnimation(TranslateTransform.YProperty, tuda);

                tuda.From = 0;
                tuda.To = 1;
                RedGrid.BeginAnimation(OpacityProperty, tuda);
            }

            if(File.Exists("OprosData.json") == false)
                InfoRed.Text = "Имеющийся опросы\n(пока ничего нету)";
            else
            {
                InfoRed.Text = "Имеющийся опросы";
                if (IsRed == false)
                {
                    IsRed = true;
                    RedVibor();
                }
            }    

            chto = 1;
            MiniUpd();
            ResetSee();
        }

        private void SeeBord_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (chto == -1)
                chto = 4;
            tuda.Duration = TimeSpan.FromSeconds(1);

            if (AS == false)
            {
                SeeAll_MouseLeftButtonDown(null, e);
                SeeGrid.Opacity = 1;
                SG.Y = 540;
            }

            else if (chto != 2)
            {
                tuda.From = RedBord.Opacity;
                tuda.To = 0;
                RedGrid.BeginAnimation(OpacityProperty, tuda);
                tuda.From = CrGrid.Opacity;
                tuda.To = 0;
                CrGrid.BeginAnimation(OpacityProperty, tuda);
                tuda.From = ImprGrid.Opacity;
                tuda.To = 0;
                ImprGrid.BeginAnimation(OpacityProperty, tuda);

                tuda.From = RG.Y;
                tuda.To = 1000;
                RG.BeginAnimation(TranslateTransform.YProperty, tuda);
                tuda.From = CG.Y;
                tuda.To = 1000;
                CG.BeginAnimation(TranslateTransform.YProperty, tuda);
                tuda.From = IG.Y;
                tuda.To = 1000;
                IG.BeginAnimation(TranslateTransform.YProperty, tuda);

                tuda.From = 0;
                tuda.To = 540;
                SG.BeginAnimation(TranslateTransform.YProperty, tuda);

                tuda.From = 0;
                tuda.To = 1;
                SeeGrid.BeginAnimation(OpacityProperty, tuda);
            }
            
            if(chto != 2)
            {
                if (File.Exists("OprosData.json") == false)
                    InfoSee.Text = "Здесь пока ничего";
                else
                {
                    WasSee = true;
                    InfoSee.Text = "";
                    var info = NewObjOpros() as OprosInfo;

                    for (int i = 1; i <= info.nomer + 1; i++)
                    {
                        StackPanel SamOpros = new StackPanel()
                        {
                            Margin = new Thickness(50, 0, 0, 0),
                            Name = "SamOpros" + i,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Top
                        };
                        TextBlock SamaTheme = new TextBlock()
                        {
                            Text = info.opr[i - 1, 0, 0],
                            Height = 25,
                            FontSize = 22,
                            FontFamily = new FontFamily("Cascadia Code ExtraLight"),
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Top
                        };

                        this.RegisterName(SamOpros.Name, SamOpros);

                        SamOpros.Children.Add(SamaTheme);
                        SeeGrid.Children.Add(SamOpros);

                        for (int j = 1; j < 11; j++)
                        {
                            if (info.opr[i - 1, 0, j] == null)
                            {
                                UltInt = j - 1;
                                break;
                            }
                        }
                        if (UltInt == 2)
                        {
                            StackPanel TwoQ = new StackPanel()
                            {
                                Margin = new Thickness(0,5,0,0),
                                HorizontalAlignment = HorizontalAlignment.Left,
                                VerticalAlignment = VerticalAlignment.Top,
                                Height = 25,
                                Width = 303,
                                Background = Brushes.Black,
                                Orientation = Orientation.Horizontal
                            };
                            SamOpros.Margin = new Thickness(50, 100, 0, 0);


                            int a = Convert.ToInt32(info.opr[i - 1, 1, 0]);
                            int b = Convert.ToInt32(info.opr[i - 1, 1, 1]);
                            UltInt = a + b;
                            if (UltInt == 0)
                                UltDou = 150;
                            else
                            {
                                UltDou = (a * 100) / UltInt;
                                UltDou *= 3;
                            }

                            TextBlock FirstQ = new TextBlock()
                            {
                                Margin = new Thickness(1, 1, 1, 1),
                                HorizontalAlignment = HorizontalAlignment.Left,
                                VerticalAlignment = VerticalAlignment.Stretch,
                                Background = Brushes.IndianRed,
                                Text = info.opr[i-1, 0, 1] + "(" + info.opr[i-1, 1, 0] + ")",
                                Width = UltDou,
                                TextAlignment = TextAlignment.Center,
                            };
                            TextBlock SecondQ = new TextBlock()
                            {
                                Margin = new Thickness(0, 1, 1, 1),
                                HorizontalAlignment = HorizontalAlignment.Left,
                                VerticalAlignment = VerticalAlignment.Stretch,
                                Background = Brushes.LightBlue,
                                Text = info.opr[i-1, 0, 2] + "(" + info.opr[i-1, 1, 1] + ")",
                                Width = 300 - FirstQ.Width,
                                TextAlignment = TextAlignment.Center,
                            };

                            TwoQ.Children.Add(FirstQ);
                            TwoQ.Children.Add(SecondQ);
                            SamOpros.Children.Add(TwoQ);
                        }
                        else
                        {
                            StackPanel Graf = new StackPanel()
                            {
                                HorizontalAlignment = HorizontalAlignment.Left,
                                VerticalAlignment = VerticalAlignment.Top,
                                Height = 325,
                                Orientation = Orientation.Horizontal,
                                Margin = new Thickness(-50, 0, 0, 0)
                            };
                            UltInt = 0;
                            for (int j = 0; j < 10; j++)
                            {
                                if (info.opr[i - 1, 1, j] != null)
                                    UltInt += Convert.ToInt32(info.opr[i - 1, 1, j]);
                                else
                                    break;                                      
                            }

                            for (int j = 1; j < 11; j++)
                            {
                                if (info.opr[i - 1, 0, j]  != null)
                                {
                                    if (UltInt == 0)
                                        UltDou = 10;
                                    else
                                    {
                                        UltDou = (Convert.ToInt32(info.opr[i - 1, 1, j - 1]) * 100) / UltInt;
                                        UltDou *= 3;
                                        if (UltDou == 0)
                                            UltDou = 10;
                                    }
                                    StackPanel stackPanel = new StackPanel()
                                    {
                                        HorizontalAlignment = HorizontalAlignment.Left,
                                        VerticalAlignment = VerticalAlignment.Bottom,
                                        Margin = new Thickness(50, 0, 0, 0)
                                    };
                                    TextBlock theme = new TextBlock()
                                    {
                                        Text = info.opr[i - 1, 0, j] + "\n(" + info.opr[i - 1, 1, j - 1] + ")",
                                        HorizontalAlignment = HorizontalAlignment.Left,
                                        VerticalAlignment = VerticalAlignment.Bottom,
                                    };
                                    Border gig = new Border()
                                    {
                                        Width = 50,
                                        Height = 5,
                                        Background = Brushes.Red,
                                        Margin = new Thickness(0, 0, 0, 5),
                                        HorizontalAlignment = HorizontalAlignment.Left,
                                        VerticalAlignment = VerticalAlignment.Bottom,
                                    };
                                    Border otvet = new Border()
                                    {
                                        HorizontalAlignment = HorizontalAlignment.Left,
                                        VerticalAlignment = VerticalAlignment.Bottom,
                                        Width = 50,
                                        Height = UltDou,
                                        Background = Brushes.IndianRed                                                                             
                                    };
                                    stackPanel.Children.Add(theme);
                                    stackPanel.Children.Add(gig);
                                    stackPanel.Children.Add(otvet);
                                    Graf.Children.Add(stackPanel);
                                }
                                else
                                    break;
                            }
                            SamOpros.Children.Add(Graf);
                        }

                        Border border = new Border()
                        {
                            Width = 200
                        };
                        SeeGrid.Children.Add(border);
                    }
                }
            }

            chto = 2;
            MiniUpd();           
        }

        private void ImprBord_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (chto == -1)
                chto = 4;
            tuda.Duration = TimeSpan.FromSeconds(1);

            if (AS == false)
            {
                SeeAll_MouseLeftButtonDown(null, e);
                ImprGrid.Opacity = 1;
                IG.Y = 490;
            }

            else if (chto != 2)
            {
                tuda.From = RedBord.Opacity;
                tuda.To = 0;
                RedGrid.BeginAnimation(OpacityProperty, tuda);
                tuda.From = CrGrid.Opacity;
                tuda.To = 0;
                CrGrid.BeginAnimation(OpacityProperty, tuda);
                tuda.From = SeeGrid.Opacity;
                tuda.To = 0;
                SeeGrid.BeginAnimation(OpacityProperty, tuda);

                tuda.From = RG.Y;
                tuda.To = 1000;
                RG.BeginAnimation(TranslateTransform.YProperty, tuda);
                tuda.From = CG.Y;
                tuda.To = 1000;
                CG.BeginAnimation(TranslateTransform.YProperty, tuda);
                tuda.From = SG.Y;
                tuda.To = 1000;
                SG.BeginAnimation(TranslateTransform.YProperty, tuda);

                tuda.From = 0;
                tuda.To = 490;
                IG.BeginAnimation(TranslateTransform.YProperty, tuda);

                tuda.From = 0;
                tuda.To = 1;
                ImprGrid.BeginAnimation(OpacityProperty, tuda);
            }

            chto = 3;
            MiniUpd();
        }

        void ResetSee()
        {
            if (WasSee)
            {
                var info = NewObjOpros() as OprosInfo;
                for (int i = 1; i <= info.nomer + 1; i++)
                {
                    this.UnregisterName("SamOpros" + i);
                }
                SeeGrid.Children.Clear();
                SeeGrid.Children.Add(InfoSee);
                WasSee = false;
            }
        }

        void RedVibor()
        {
            var info = NewObjOpros() as OprosInfo;

            UltInt = 0;
            for (int j = info.nomer + 1; j > 0; j -= 7)
                UltInt++;
            UltInt--;
            for (int j = 0; j < UltInt; j++)
            {
                ColumnDefinition column = new ColumnDefinition();
                TablOpr.ColumnDefinitions.Add(column);
            }

            for (int i = 0; i <= info.nomer; i++)
            {
                Border ThsiOpros = new Border
                {
                    Margin = new Thickness(25, 0, 0, 0),
                    Name = "ThsiOpros" + (i + 1),
                    Height = 25,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Background = Brushes.Black,
                };

                TextBlock newOtvet = new TextBlock
                {
                    Name = "ThsiOtvet" + (i + 1),
                    Margin = new Thickness(1, 1, 1, 1),
                    Text = info.opr[i, 0, 0],
                    FontFamily = new FontFamily("Cascadia Code ExtraLight"),
                    FontSize = 20,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Background = Brushes.White
                };

                ThsiOpros.Child = newOtvet;

                UltInt = 0;
                for(int j = i; j >= 0; j -= 7)
                    UltInt++;
                UltInt--;
                Grid.SetColumn(ThsiOpros, UltInt);
                Grid.SetRow(ThsiOpros, i - (UltInt * 7));

                ThsiOpros.MouseLeftButtonDown += ThsiOpros_MouseLeftButtonDown;

                TablOpr.Children.Add(ThsiOpros);
                this.RegisterName(ThsiOpros.Name, ThsiOpros);
                this.RegisterName(newOtvet.Name, newOtvet);
            }
        }

        private void ThsiOpros_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (UjeRed)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (RedVseOtveti[i, 0] != "")
                    {
                        var a1 = FindName(RedVseOtveti[i, 0]) as StackPanel;
                        var b1 = FindName(RedVseOtveti[i, 1]) as TextBox;
                        RedPhase2.Children.Remove(a1);
                        this.UnregisterName(a1.Name);
                        this.UnregisterName(b1.Name);
                    }
                }
                for (int i = 0; i < 9; i++)
                {
                    RedVseOtveti[i, 0] = "";
                    RedVseOtveti[i, 1] = "";
                }
            }

            UjeRed = true;

            var info = NewObjOpros() as OprosInfo;
            
            tuda.Duration = TimeSpan.FromSeconds(1);

            tuda.From = RS.X;
            tuda.To = 50;
            RS.BeginAnimation(TranslateTransform.XProperty, tuda);
            tuda.From = RedSpace.Opacity;
            tuda.To = 1;
            RedSpace.BeginAnimation(OpacityProperty, tuda);

            var a = sender as Border;
            UltInt = Convert.ToInt32(a.Name.Substring(9));
            var b = FindName("ThsiOtvet" + UltInt) as TextBlock;

            RedTheme.Text = b.Text;

            for(int i = 0; i <= info.nomer; i++)
            {
                if(b.Text == info.opr[i, 0, 0])
                {
                    UltInt = i;
                    ItTheme = i;
                    break;
                }
            }

            RedOtvet1.Text = info.opr[UltInt, 0, 1];
            for(int i = 1; true; i++)
            {
                if (info.opr[UltInt, 0, i] == null)
                {
                    RedKolVo = i - 1;
                    break;
                }                  
            }
            for (int i = 2; i < RedKolVo + 1; i++)
            {
                StackPanel SPNewOtvet = new StackPanel
                {
                    Name = "RedSPotvet" + i,
                    Margin = new Thickness(0, 5, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Orientation = Orientation.Horizontal
                };
                TextBlock minus = new TextBlock
                {
                    Margin = new Thickness(0, -5, 0, 0),
                    Text = "-",
                    FontSize = 22,
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch
                };
                TextBox newOtvet = new TextBox
                {
                    Name = "RedOtvet" + i,
                    Text = info.opr[UltInt, 0, i],
                    Height = 25,
                    FontFamily = new FontFamily("Cascadia Code ExtraLight"),
                    FontSize = 20,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    BorderBrush = Brushes.Black
                };
                Border BG = new Border
                {
                    Name = "RedMinus" + i,
                    Margin = new Thickness(5, 0, 0, 0),
                    Height = 25,
                    Width = 25,
                    Background = Brushes.Black,
                };
                Border BGinGB = new Border
                {
                    Height = 23,
                    Width = 23,
                    Background = Brushes.White
                };

                RedVseOtveti[i - 2, 0] = "RedSPotvet" + i;
                RedVseOtveti[i - 2, 1] = "RedOtvet" + i;

                this.RegisterName(newOtvet.Name, newOtvet);
                this.RegisterName(SPNewOtvet.Name, SPNewOtvet);

                BG.Child = BGinGB;
                BGinGB.Child = minus;
                BG.MouseLeftButtonDown += RedBG_MouseLeftButtonDown;
                SPNewOtvet.Children.Add(newOtvet);
                SPNewOtvet.Children.Add(BG);
                RedPhase2.Children.Add(SPNewOtvet);
            }
        }

        void UpdRed()
        {
            var info = NewObjOpros() as OprosInfo;
            IsRed = false;
            if (CrOrRed)
            {
                for (int i = 1; i <= info.nomer; i++)
                {
                    this.UnregisterName("ThsiOpros" + i);
                    this.UnregisterName("ThsiOtvet" + i);
                }

                TablOpr.ColumnDefinitions.Clear();
                ColumnDefinition column = new ColumnDefinition();
                TablOpr.ColumnDefinitions.Add(column);
                TablOpr.Children.Clear();
            }
            else
            {
                for (int i = 1; i <= info.nomer + 1; i++)
                {
                    this.UnregisterName("ThsiOpros" + i);
                    this.UnregisterName("ThsiOtvet" + i);
                }
            }
        }     

        private async void Polzunok_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (no == false)
            {
                dvig = true;
                while (dvig)
                {
                    await Task.Delay(1);
                    polz.Y = Mouse.GetPosition(this).Y - 320;

                    if (polz.Y > 0)
                        polz.Y = 0;
                    if (polz.Y < -140)
                        polz.Y = -140;

                    if (AS)
                        mainWindow.Width = WidthPolz();
                }
            }   
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dvig = false;
        }

        private void More_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(done == false)
            {
                if (Choosing)
                {
                    Choosing = false;

                    tuda.From = ChoosePanel.Height;
                    tuda.To = 25;
                    tuda.Duration = TimeSpan.FromMilliseconds(500);
                    ChoosePanel.BeginAnimation(HeightProperty, tuda);
                }
                else
                {
                    Choosing = true;

                    tuda.From = ChoosePanel.Height;
                    tuda.To = 78;
                    tuda.Duration = TimeSpan.FromMilliseconds(500);
                    ChoosePanel.BeginAnimation(HeightProperty, tuda);
                }
            }
        }

        async void Uptade()
        {
            while (true)
            {
                await Task.Delay(10);

                CP.Width = ChoosePanel.Width - 2;
                CP.Height = ChoosePanel.Height - 2;
            }
        }

        void MiniUpd()
        {
            switch (chto)
            {
                case 0:
                    CrText.Foreground = Brushes.White;
                    RedText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF464646"));
                    SeeText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF464646"));
                    break;
                case 1:
                    RedText.Foreground = Brushes.White;
                    CrText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF464646"));
                    SeeText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF464646"));
                    break;
                case 2:
                    SeeText.Foreground = Brushes.White;
                    RedText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF464646"));
                    CrText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF464646"));
                    break;
            }           
        }

        void ChoosUpd()
        {
            switch (ChWhat[0])
            {
                case 0:
                    IsNow.Text = "Обычный (да/нет)";
                    break;
                case 1:
                    IsNow.Text = "С неопределением";
                    break;
                case 2:
                    IsNow.Text = "Свой";
                    break;
            }
            switch (ChWhat[1])
            {
                case 0:
                    ChT1.Text = "Обычный (да/нет)";
                    break;
                case 1:
                    ChT1.Text = "С неопределением";
                    break;
                case 2:
                    ChT1.Text = "Свой";
                    break;
            }
            switch (ChWhat[2])
            {
                case 0:
                    ChT2.Text = "Обычный (да/нет)";
                    break;
                case 1:
                    ChT2.Text = "С неопределением";
                    break;
                case 2:
                    ChT2.Text = "Свой";
                    break;
            }
        }

        private void Ch1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(done == false)
            {
                UltInt = ChWhat[0];

                ChWhat[0] = ChWhat[1];
                ChWhat[1] = UltInt;

                ChoosUpd();
            }
        }

        private void Ch2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(done == false)
            {
                UltInt = ChWhat[0];

                ChWhat[0] = ChWhat[2];
                ChWhat[2] = UltInt;

                ChoosUpd();
            }
        }

        private void Next_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Opros.Text.Length > 0 && done == false)
            {
                done = true;

                Theme.Text = Opros.Text;

                NxBG.Background = Brushes.Gray;
                SPCH.Background = Brushes.Gray;
                CP.Background = Brushes.Gray;
                Ch1.Background = Brushes.Gray;
                Ch2.Background = Brushes.Gray;
                Opros.Background = Brushes.Gray;
                Opros.IsHitTestVisible = false;

                tuda.From = ph2.X;
                tuda.To = 150;
                tuda.Duration = TimeSpan.FromSeconds(1);
                ph2.BeginAnimation(TranslateTransform.XProperty, tuda);
                tuda.From = Phase2.Opacity;
                tuda.To = 1;
                Phase2.BeginAnimation(OpacityProperty, tuda);

                if (Choosing)
                {
                    Choosing = false;

                    tuda.From = 78;
                    tuda.To = 25;
                    tuda.Duration = TimeSpan.FromMilliseconds(500);
                    ChoosePanel.BeginAnimation(HeightProperty, tuda);
                }

                Back.Opacity = 1;
                Back.IsHitTestVisible = true;
                Done.Opacity = 1;
                Done.IsHitTestVisible = true;

                switch (ChWhat[0])
                {
                    case 0:
                        Otveti.Text = "- да\n- нет";
                        break;
                    case 1:
                        Otveti.Text = "- да\n- скорее да чем нет\n- не знаю\n- скорее нет чем да\n- нет";
                        break;
                    case 2:

                        Otveti.Text = "";

                        Spisok.Margin = new Thickness(0, 0, 0, 0);

                        break;
                }
            }
        }

        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            done = false;

            tuda.From = ph2.X;
            tuda.To = 0;
            tuda.Duration = TimeSpan.FromSeconds(1);
            ph2.BeginAnimation(TranslateTransform.XProperty, tuda);
            tuda.From = Phase2.Opacity;
            tuda.To = 0;
            Phase2.BeginAnimation(OpacityProperty, tuda);

            NxBG.Background = Brushes.White;
            SPCH.Background = Brushes.White;
            CP.Background = Brushes.White;
            Ch1.Background = Brushes.White;
            Ch2.Background = Brushes.White;
            Opros.Background = Brushes.White;
            Opros.IsHitTestVisible = true;

            Back.Opacity = 0;
            Back.IsHitTestVisible = false;
            Done.Opacity = 0;
            Done.IsHitTestVisible = false;

            for (int i = 0;  i < 9; i++)
            {
                if (VseOtveti[i, 0] != "")
                {
                    var a = FindName(VseOtveti[i, 0]) as StackPanel;
                    var b = FindName(VseOtveti[i, 1]) as TextBox;
                    Phase2.Children.Remove(a);
                    this.UnregisterName(a.Name);
                    this.UnregisterName(b.Name);
                }
            }
            for(int i = 0; i < 9; i++)
            {
                VseOtveti[i, 0] = "";
                VseOtveti[i, 1] = "";
            }

            Otvet1.Text = "Ответ 1";

            KolVo = 1;
        }

        private async void Plus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(KolVo < 10)
            {
                UltInt = 2;
                for(int i = 0; i < 10; i++)
                {
                    if (VseOtveti[i, 0] == "")
                        break;
                    else
                        UltInt++;
                }
                StackPanel SPNewOtvet = new StackPanel
                {
                    Name = "SPotvet" + UltInt,
                    Margin = new Thickness(0, 5, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Orientation = Orientation.Horizontal
                };
                TextBlock minus = new TextBlock
                {
                    Margin = new Thickness(0, -5, 0, 0),
                    Text = "-",
                    FontSize = 22,
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch
                };
                TextBox newOtvet = new TextBox
                {
                    Name = "Otvet" + UltInt,
                    Text = "Ответ " + UltInt,
                    Height = 25,
                    FontFamily = new FontFamily("Cascadia Code ExtraLight"),
                    FontSize = 20,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    BorderBrush = Brushes.Black
                };
                Border BG = new Border
                {
                    Name = "Minus" + UltInt,
                    Margin = new Thickness(5, 0, 0, 0),
                    Height = 25,
                    Width = 25,
                    Background = Brushes.Black,
                };
                Border BGinGB = new Border
                {
                    Height = 23,
                    Width = 23,
                    Background = Brushes.White
                };

                KolVo++;

                BGinGB.Child = minus;
                BG.Child = BGinGB;

                VseOtveti[UltInt - 2, 0] = "SPotvet" + UltInt;
                VseOtveti[UltInt - 2, 1] = "Otvet" + UltInt;
                
                this.RegisterName(newOtvet.Name, newOtvet);
                this.RegisterName(SPNewOtvet.Name, SPNewOtvet);
                BG.MouseLeftButtonDown += BG_MouseLeftButtonDown;
                SPNewOtvet.Children.Add(newOtvet);
                SPNewOtvet.Children.Add(BG);
                Phase2.Children.Add(SPNewOtvet);
            }
            else
            {
                if (rano == false)
                {
                    NuhUh.Text = "больше десяти нельзя";
                    rano = true;
                    tuda.From = 0;
                    tuda.To = -100;
                    tuda.Duration = TimeSpan.FromSeconds(1);
                    NU.BeginAnimation(TranslateTransform.XProperty, tuda);
                    tuda.From = 0;
                    tuda.To = 1;
                    tuda.Duration = TimeSpan.FromSeconds(1);
                    NuhUh.BeginAnimation(OpacityProperty, tuda);

                    await Task.Delay(1000);
                    tuda.From = 1;
                    tuda.To = 0;
                    tuda.Duration = TimeSpan.FromSeconds(10);
                    NuhUh.BeginAnimation(OpacityProperty, tuda);

                    await Task.Delay(10000);
                    rano = false;
                }
            }
        }

        private async void RedPlus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (RedKolVo < 10)
            {
                UltInt = 2;
                for (int i = 0; i < 10; i++)
                {
                    if (RedVseOtveti[i, 0] == "")
                        break;
                    else
                        UltInt++;
                }
                StackPanel SPNewOtvet = new StackPanel
                {
                    Name = "RedSPotvet" + UltInt,
                    Margin = new Thickness(0, 5, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Orientation = Orientation.Horizontal
                };
                TextBlock minus = new TextBlock
                {
                    Margin = new Thickness(0, -5, 0, 0),
                    Text = "-",
                    FontSize = 22,
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch
                };
                TextBox newOtvet = new TextBox
                {
                    Name = "RedOtvet" + UltInt,
                    Text = "Ответ " + UltInt,
                    Height = 25,
                    FontFamily = new FontFamily("Cascadia Code ExtraLight"),
                    FontSize = 20,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    BorderBrush = Brushes.Black
                };
                Border BG = new Border
                {
                    Name = "RedMinus" + UltInt,
                    Margin = new Thickness(5, 0, 0, 0),
                    Height = 25,
                    Width = 25,
                    Background = Brushes.Black,
                };
                Border BGinGB = new Border
                {
                    Height = 23,
                    Width = 23,
                    Background = Brushes.White
                };

                RedKolVo++;

                BGinGB.Child = minus;
                BG.Child = BGinGB;

                RedVseOtveti[UltInt - 2, 0] = "RedSPotvet" + UltInt;
                RedVseOtveti[UltInt - 2, 1] = "RedOtvet" + UltInt;

                this.RegisterName(newOtvet.Name, newOtvet);
                this.RegisterName(SPNewOtvet.Name, SPNewOtvet);

                BG.MouseLeftButtonDown += RedBG_MouseLeftButtonDown;
                SPNewOtvet.Children.Add(newOtvet);
                SPNewOtvet.Children.Add(BG);
                RedPhase2.Children.Add(SPNewOtvet);
            }
            else
            {
                if (rano == false)
                {
                    NuhUh.Text = "больше десяти нельзя";
                    rano = true;
                    tuda.From = 0;
                    tuda.To = -100;
                    tuda.Duration = TimeSpan.FromSeconds(1);
                    NU.BeginAnimation(TranslateTransform.XProperty, tuda);
                    tuda.From = 0;
                    tuda.To = 1;
                    tuda.Duration = TimeSpan.FromSeconds(1);
                    NuhUh.BeginAnimation(OpacityProperty, tuda);

                    await Task.Delay(1000);
                    tuda.From = 1;
                    tuda.To = 0;
                    tuda.Duration = TimeSpan.FromSeconds(10);
                    NuhUh.BeginAnimation(OpacityProperty, tuda);

                    await Task.Delay(10000);
                    rano = false;
                }
            }
        }

        private void RedBG_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var a = sender as Border;
            UltStr = a.Name.Substring(8);
            var b = FindName("RedSPotvet" + UltStr) as StackPanel;
            var c = FindName("RedOtvet" + UltStr) as TextBox;
            RedPhase2.Children.Remove(b);
            this.UnregisterName(b.Name);
            this.UnregisterName(c.Name);
            RedKolVo--;
            RedVseOtveti[Convert.ToInt32(UltStr) - 2, 0] = "";
            RedVseOtveti[Convert.ToInt32(UltStr) - 2, 1] = "";
        }

        private void BG_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var a = sender as Border;
            UltStr = a.Name.Substring(5);
            var b = FindName("SPotvet" + UltStr) as StackPanel;
            var c = FindName("Otvet" + UltStr) as TextBox;            
            Phase2.Children.Remove(b);            
            this.UnregisterName(b.Name);
            this.UnregisterName(c.Name);
            KolVo--;
            VseOtveti[Convert.ToInt32(UltStr) - 2, 0] = "";
            VseOtveti[Convert.ToInt32(UltStr) - 2, 1] = "";
        }

        private void RedDone_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CrOrRed = false;
            tuda.From = RS.X;
            tuda.To = 0;
            RS.BeginAnimation(TranslateTransform.XProperty, tuda);
            tuda.From = RedSpace.Opacity;
            tuda.To = 0;
            RedSpace.BeginAnimation(OpacityProperty, tuda);

            var info = NewObjOpros() as OprosInfo;
            string[] opr = new string[11];

            opr[0] = RedTheme.Text;
            opr[1] = RedOtvet1.Text;

            for (int i = 0; i < 9; i++)
            {
                if (RedVseOtveti[i, 1] != "")
                {
                    var a = FindName(RedVseOtveti[i, 1]) as TextBox;
                    opr[i + 2] = a.Text;
                }
                else
                    opr[i + 2] = "";
            }
            for(int i = 0; i < 11; i++)
            {
                info.opr[ItTheme, 0, i] = null;
                info.opr[ItTheme, 1, i] = null;
            }

            info.opr[ItTheme, 0, 0] = opr[0];
            info.opr[ItTheme, 0, 1] = opr[1];
            UltInt = 0;
            for (int i = 0; i <= 9; i++)
            {
                if (opr[i] != "")
                    info.opr[ItTheme, 0, i - UltInt] = opr[i];
                else
                    UltInt++;
            }
            for(int i = 0; i < 10; i++)
            {
                if(info.opr[ItTheme, 0, i + 1] != null)
                    info.opr[ItTheme, 1, i] = "0";
                else
                    break;
            }
            File.WriteAllText("OprosData.json", JsonConvert.SerializeObject(info));

            UpdRed();
            for (int i = 0; i <= info.nomer; i++)
            {
                Border ThsiOpros = new Border
                {
                    Margin = new Thickness(25, 0, 0, 0),
                    Name = "ThsiOpros" + (i + 1),
                    Height = 25,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Background = Brushes.Black,
                };

                TextBlock newOtvet = new TextBlock
                {
                    Name = "ThsiOtvet" + (i + 1),
                    Margin = new Thickness(1, 1, 1, 1),
                    Text = info.opr[i, 0, 0],
                    FontFamily = new FontFamily("Cascadia Code ExtraLight"),
                    FontSize = 20,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Background = Brushes.White
                };

                ThsiOpros.Child = newOtvet;

                UltInt = 0;
                for (int j = i; j >= 0; j -= 7)
                    UltInt++;
                UltInt--;
                Grid.SetColumn(ThsiOpros, UltInt);
                Grid.SetRow(ThsiOpros, i - (UltInt * 7));

                ThsiOpros.MouseLeftButtonDown += ThsiOpros_MouseLeftButtonDown;

                TablOpr.Children.Add(ThsiOpros);
                this.RegisterName(ThsiOpros.Name, ThsiOpros);
                this.RegisterName(newOtvet.Name, newOtvet);
            }
            IsRed = true;
        }

        private async void Done_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CrOrRed = true;
            tuda.From = ph2.X;
            tuda.To = 0;
            tuda.Duration = TimeSpan.FromSeconds(1);
            ph2.BeginAnimation(TranslateTransform.XProperty, tuda);
            tuda.From = Phase2.Opacity;
            tuda.To = 0;
            Phase2.BeginAnimation(OpacityProperty, tuda);

            NxBG.Background = Brushes.White;
            SPCH.Background = Brushes.White;
            CP.Background = Brushes.White;
            Ch1.Background = Brushes.White;
            Ch2.Background = Brushes.White;
            Opros.Background = Brushes.White;
            Opros.IsHitTestVisible = true;

            Back.Opacity = 0;
            Back.IsHitTestVisible = false;
            Done.IsHitTestVisible = false;

            string[] opr = new string[11];
            opr[0] = Opros.Text;
            switch (ChWhat[0])
            {
                case 0:
                    opr[1] = "Да";
                    opr[2] = "Нет";
                    break;
                case 1:
                    opr[1] = "Да";
                    opr[2] = "Скорее да чем нет";
                    opr[3] = "Не знаю";
                    opr[4] = "Скорее нет чем да";
                    opr[5] = "Нет";
                    break;
                case 2:

                    opr[1] = Otvet1.Text;

                    for(int i = 0; i < 9; i++)
                    {
                        if (VseOtveti[i, 1] != "")
                        {
                            var a = FindName(VseOtveti[i, 1]) as TextBox;
                            opr[i + 2] = a.Text;
                        }
                        else
                            opr[i + 2] = ""; 
                    }

                    break;
            }

            OprosInfo info = new OprosInfo();

            if (File.Exists("OprosData.json") == false)
            {
                info.nomer = 0;
                info.opr[0, 0, 0] = opr[0];
                info.opr[0, 0, 1] = opr[1];
                UltInt = 0;
                for (int i = 0; i <= 9; i++)
                {
                    if (opr[i] != "")
                        info.opr[0, 0, i - UltInt] = opr[i];
                    else
                        UltInt++;
                }
                for (int i = 0; i < 10; i++)
                {
                    if (info.opr[0, 0, i + 1] != null)
                        info.opr[0, 1, i] = "0";
                    else
                        break;
                }
                File.WriteAllText("OprosData.json", JsonConvert.SerializeObject(info));
                if(IsRed)
                    UpdRed();
            }
            else
            {
                UltStr = File.ReadAllText("OprosData.json");
                info = JsonConvert.DeserializeObject<OprosInfo>(UltStr);
                info.nomer++;
                info.opr[info.nomer, 0, 0] = opr[0];
                info.opr[info.nomer, 0, 1] = opr[1];
                UltInt = 0;
                for (int i = 0; i <= 9; i++)
                {
                    if (opr[i] != "")
                        info.opr[info.nomer, 0, i - UltInt] = opr[i];
                    else
                        UltInt++;
                }
                for (int i = 0; i < 10; i++)
                {
                    if (info.opr[info.nomer, 0, i + 1] != null)
                        info.opr[info.nomer, 1, i] = "0";
                    else
                        break;
                }
                File.WriteAllText("OprosData.json", JsonConvert.SerializeObject(info));
                if (IsRed)
                    UpdRed();
            }


            for (int i = 0; i < 9; i++)
            {
                if (VseOtveti[i, 0] != "")
                {
                    var a = FindName(VseOtveti[i, 0]) as StackPanel;
                    var b = FindName(VseOtveti[i, 1]) as TextBox;
                    Phase2.Children.Remove(a);
                    this.UnregisterName(a.Name);
                    this.UnregisterName(b.Name);
                }
            }
            for (int i = 0; i < 9; i++)
            {
                VseOtveti[i, 0] = "";
                VseOtveti[i, 1] = "";
            }

            Otvet1.Text = "Ответ 1";

            KolVo = 1;

            DnBG.Background = Brushes.Green;
            Done.Background = Brushes.Green;
            tuda.From = 1;
            tuda.To = 0;
            Done.BeginAnimation(OpacityProperty, tuda);
            tuda.From = 100;
            tuda.To = 1000;
            Done.BeginAnimation(WidthProperty, tuda);
            tuda.From = 25;
            tuda.To = 0;
            Done.BeginAnimation(HeightProperty, tuda);
            await Task.Delay(1000);
            done = false;
            Done.BeginAnimation(OpacityProperty, null);
            Done.BeginAnimation(WidthProperty, null);
            Done.BeginAnimation(HeightProperty, null);
            Done.Height = 25;
            Done.Width = 100;
            DnBG.Background = Brushes.White;
            Done.Background = Brushes.Black;
            Done.Opacity = 0;
        }

        private async void ImprGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (open.ShowDialog() == DialogResult)
                return;
            try
            {
                OprosInfo info = new OprosInfo();
                UltStr = File.ReadAllText(open.FileName);
                info = JsonConvert.DeserializeObject<OprosInfo>(UltStr);
            }
            catch
            {
                if (rano == false)
                {
                    NuhUh.Text = "неверный формат";
                    rano = true;
                    tuda.From = 0;
                    tuda.To = -100;
                    tuda.Duration = TimeSpan.FromSeconds(1);
                    NU.BeginAnimation(TranslateTransform.XProperty, tuda);
                    tuda.From = 0;
                    tuda.To = 1;
                    tuda.Duration = TimeSpan.FromSeconds(1);
                    NuhUh.BeginAnimation(OpacityProperty, tuda);

                    await Task.Delay(1000);
                    tuda.From = 1;
                    tuda.To = 0;
                    tuda.Duration = TimeSpan.FromSeconds(10);
                    NuhUh.BeginAnimation(OpacityProperty, tuda);

                    await Task.Delay(10000);
                    rano = false;
                }
            }
        }

        private void Expr_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var info = NewObjOpros() as OprosInfo;
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "OprosData.json" ), JsonConvert.SerializeObject(info));
        }

        //ультимотивные переменые
        public int UltInt;
        public double UltDou;
        public string UltStr;

        //отдел анимации
        DoubleAnimation tuda = new DoubleAnimation { EasingFunction = new QuarticEase() };
        TranslateTransform polz = new TranslateTransform();
        TranslateTransform ph2 = new TranslateTransform();
        TranslateTransform NU = new TranslateTransform();
        TranslateTransform CG = new TranslateTransform();
        TranslateTransform RG = new TranslateTransform();
        TranslateTransform RS = new TranslateTransform();
        TranslateTransform SG = new TranslateTransform();
        TranslateTransform IG = new TranslateTransform();

        //отдел контроля
        public MainWindow mainWindow;
        public bool AS = false;
        public int chto = -1;
        public bool dvig = false;
        public bool no = false;
        public int WP;
        public bool Choosing = false;
        public int[] ChWhat = new int[3];       
        int WidthPolz()
        {
            return WP = (int)polz.Y * (-10) + 400;
        }
        public bool done = false;
        public int KolVo = 1;
        public int RedKolVo = 1;
        public int ItTheme;
        public string[,] VseOtveti = new string[9, 2];
        public string[,] RedVseOtveti = new string[9, 2];
        public bool rano = false;
        public bool IsRed = false;
        object NewObjOpros()
        {
            OprosInfo info = new OprosInfo();
            UltStr = File.ReadAllText("OprosData.json");
            info = JsonConvert.DeserializeObject<OprosInfo>(UltStr);
            return info;
        }
        public bool UjeRed = false;
        public bool WasSee = false;
        public bool CrOrRed;
        OpenFileDialog open = new OpenFileDialog();      
    }
}
