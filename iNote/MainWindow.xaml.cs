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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace iNote
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

        new string? Language;
        string? success;
        string? fail;
        Boolean clicked;

        private void Started(object sender, RoutedEventArgs e)
        {
            Language = "EN";
            clicked = false;
        }

        private void btnEN_Click(object sender, RoutedEventArgs e)
        {
            Language = "EN";
        }

        private void btnKR_Click(object sender, RoutedEventArgs e)
        {
            Language = "KR";
        }

        private void btnSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            if (Language == "EN")
            {
                tbox_Memo.Text = "Enter your text here.";
                tbox_Path.Text = "Enter the path where the text file will be saved.";
                btnSave.Content = "Save";
                success = "Your note has been saved successfully.";
                fail = "An error has occurred.\n";
            }
            else if (Language == "KR")
            {
                tbox_Memo.Text = "이곳에 텍스트를 입력하십시오.";
                tbox_Path.Text = "메모를 저장할 경로를 입력하십시오.";
                btnSave.Content = "저장";
                success = "메모가 성공적으로 저장되었습니다.";
                fail = "오류가 발생했습니다.\n";
            }
            clicked = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string text = tbox_Memo.Text;
            string path = tbox_Path.Text;
            if (clicked != true)
            {
                MessageBox.Show("An error has occured. Please click 'Save Settings' button first.");
                return;
            }
            try
            {
                File.WriteAllText(path, text);
                MessageBox.Show(success);
            }
            catch (Exception error)
            {
                MessageBox.Show(fail + error.Message);
            }
        }
    }
}
