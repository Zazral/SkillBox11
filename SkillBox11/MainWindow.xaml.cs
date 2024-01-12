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

namespace SkillBox11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string trigger;
        ViewModel Vm = new ViewModel();
        public MainWindow()
        {
            DataContext = Vm;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Vm.AddAccount(trigger);
        }

        private void rbAddCurent_Checked(object sender, RoutedEventArgs e)
        {
            trigger = "Curent";
        }

        private void rbAddDeposit_Checked(object sender, RoutedEventArgs e)
        {
            trigger = "Deposit";
        }
        private void rbYour_Checked(object sender, RoutedEventArgs e)
        {
            CmBClients.SelectedIndex = -1;
            CmBClients.IsEnabled = false;
        }

        private void rbAnother_Unchecked(object sender, RoutedEventArgs e)
        {
            CmBClients.IsEnabled = false;
        }

        private void rbTransfers_Checked(object sender, RoutedEventArgs e)
        {
            BtnOpen.IsEnabled = false;
            BtnClose.IsEnabled = false;
            BtnTopUp.IsEnabled = false;
            BtnTransfer.IsEnabled = true;
            rbUncheck();
            rbAddDeposit.IsEnabled = false;
            rbAddCurent.IsEnabled = false;
            rbAnother.IsEnabled = true;
            rbYour.IsEnabled = true;
            rbTransferToCurent.IsEnabled = true;
            rbTransferToDeposit.IsEnabled = true;
        }

        private void rbAnotherActions_Checked(object sender, RoutedEventArgs e)
        {
            BtnOpen.IsEnabled = true;
            BtnClose.IsEnabled = true;
            BtnTopUp.IsEnabled = true;
            BtnTransfer.IsEnabled = false;
            rbUncheck();
            rbAddDeposit.IsEnabled = true;
            rbAddCurent.IsEnabled = true;
            rbAnother.IsEnabled = false;
            rbYour.IsEnabled=false;
            rbTransferToCurent.IsEnabled = false;
            rbTransferToDeposit.IsEnabled = false;
        }
        public void rbUncheck()
        {
            rbAddCurent.IsChecked=false;
            rbAddDeposit.IsChecked = false;
            rbAnother.IsChecked = false;
            rbTransferToCurent.IsChecked = false;
            rbTransferToDeposit.IsChecked = false;
            rbYour.IsChecked = false;
        }

        private void rbAnother_Checked(object sender, RoutedEventArgs e)
        {
            CmBClients.IsEnabled = true;
            trigger = "AnotherTransfer";
        }

        private void BtnTopUp_Click(object sender, RoutedEventArgs e)
        {
            Vm.TopUp(trigger);
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Vm.Close(trigger);
        }

        private void BtnTransfer_Click(object sender, RoutedEventArgs e)
        {
            Vm.Transfer(trigger);
        }

        private void rbTransferToDeposit_Checked(object sender, RoutedEventArgs e)
        {
            trigger = "ToDeposit";
        }

        private void rbTransferToCurent_Checked(object sender, RoutedEventArgs e)
        {
            trigger = "ToCurent";
        }
    }
}
