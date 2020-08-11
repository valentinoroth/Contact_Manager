using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Contact_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isAdrBookLoaded = false;
        ObservableCollection<Contact> contacts;

        AddressBook AddressBook = new AddressBook();

        string openedFile = "";

        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
        Microsoft.Win32.SaveFileDialog slg = new Microsoft.Win32.SaveFileDialog();

        

        public MainWindow()
        {
            InitializeComponent();
            contacts = new ObservableCollection<Contact>();

        }

        private void Btn_load_Click(object sender, RoutedEventArgs e)
        {
            openFile();
        }

        private void Btn_save_Click_1(object sender, RoutedEventArgs e)
        {
            if(openedFile != "")
            AddressBook.Save(openedFile);
        }


        private void openFile()
        {
            var uc = new AddressBookUserControl();
            var ti = new TabItem();
            dlg.DefaultExt = ".txt";           
            dlg.Filter = "Text documents (.txt)|*.txt";
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                if (isAdrBookLoaded)
                { 
                    contacts.Clear();
                }
                uc.AdresseBook.Load(dlg.FileName);
                openedFile = dlg.FileName;
                uc.DataContext = uc.AdresseBook.Contacts;
                ti.Content = uc;
                ti.Header = dlg.SafeFileName;
                TabControl.Items.Add(ti);
                TabControl.SelectedItem = ti;
                isAdrBookLoaded = true;
            }
        }

        private void SaveFileAs()
        {
            slg.DefaultExt = ".txt";
            slg.Filter = "Text documents (.txt)|*.txt";
            bool? result = slg.ShowDialog();
            if (result == true)
            {
                AddressBook.Save(slg.FileName);
            }
        }

        private void CmdOpen_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CmdOpen_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            openFile();
        }

        private void CmdSave_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (isAdrBookLoaded)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void CmdSave_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (openedFile != "")
                AddressBook.Save(openedFile);
        }

        private void CmdSaveAs_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (isAdrBookLoaded)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void CmdSaveAs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileAs();
        }

        private void CmdHelp_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CmdHelp_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void TB_open_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
