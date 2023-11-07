using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using System.Runtime.InteropServices;
using System.Drawing;
using Point = System.Windows.Point;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Click here!");
            
        }
        private void Button_Click_1a(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("AA Click here!");
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            B1.Focus();
            Key key = Key.Enter;
            Send(key);
            key = Key.Tab;
            Send(key);
            key = Key.Enter;
            Send(key);
        }
        public static void Send(Key key)
        {
      
            if (Keyboard.PrimaryDevice != null)
            {
                if (Keyboard.PrimaryDevice.ActiveSource != null)
                {
                    var e = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key)
                    {
                        RoutedEvent = Keyboard.KeyDownEvent
                    };
                    InputManager.Current.ProcessInput(e);
                    

                    // Note: Based on your requirements you may also need to fire events for:
                    // RoutedEvent = Keyboard.PreviewKeyDownEvent
                    // RoutedEvent = Keyboard.KeyUpEvent
                    // RoutedEvent = Keyboard.PreviewKeyUpEvent
                }
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            Process proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            // proc.StartInfo.FileName = "http://stackoverflow.com";
            //proc.StartInfo.FileName = "http://www.orf.at";
            proc.StartInfo.FileName = "http://google.com";
            proc.Start();
            Thread.Sleep(2000);
            SendKeys.SendWait("orf.at");
            SendKeys.SendWait("\n");
            /*Thread.Sleep(2000);
            LeftClick(300, 300);
            Thread.Sleep(2000);
            LeftClick(400, 400);
            Thread.Sleep(2000);
            LeftClick(500, 500);*/
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            Process proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            // proc.StartInfo.FileName = "http://stackoverflow.com";
            proc.StartInfo.FileName = "http://www.orf.at";
            //proc.StartInfo.FileName = "http://google.com";
            proc.Start();
            //Thread.Sleep(2000);
            //SendKeys.SendWait("orf.at");
            //SendKeys.SendWait("\n");
            Thread.Sleep(2000);
            LeftClick(300, 300);
            Thread.Sleep(2000);
            LeftClick(400, 400);
            Thread.Sleep(2000);
            LeftClick(500, 500);
        }

        [DllImport("user32.dll")]
static extern void mouse_event(int dwFlags, int dx, int dy,
                      int dwData, int dwExtraInfo);

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }

        public static void LeftClick(int x, int y)
        {
            System.Windows.Forms.Cursor.Position = new System.Drawing.Point(x, y);

            //this.Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
        }
    }  //Test
}
