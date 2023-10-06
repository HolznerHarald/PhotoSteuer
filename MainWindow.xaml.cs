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
            SendKeys.SendWait("kkkkkkkkkkkkkkk");
            SendKeys.SendWait("\t");
        }
        }
}
