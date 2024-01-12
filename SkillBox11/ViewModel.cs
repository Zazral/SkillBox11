using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SkillBox11
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Client> _clients;
        private Client _selectedClient;
        private int _summa;
        private Client _selectedTransfer;
        private Client _newClient = new Client();
        public Client NewClient
        {
            get { return this._newClient; }
            set { this._newClient = value; }
        }
        public Client SelectedTransfer
        {
            get { return this._selectedTransfer; }
            set { this._selectedTransfer = value; }
        }
        public int Summa
        {
            get { return this._summa; }
            set { this._summa = value; }
        }
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value; 
                OnPropertyChanged(nameof(SelectedClient));
            }
        }
        public void Transfer(string trigger)
        {
            if (trigger == "AnotherTransfer")
            {
                SelectedClient.Curent.Transfer(SelectedTransfer, Summa);
            }
            else
            {
                SelectedClient.MyTransfer(Summa, trigger);
            }
        }
        /// <summary>
        /// Закрытие счета
        /// </summary>
        /// <param name="trigger"></param>
        public void Close(string trigger)
        {
            SelectedClient.Close(trigger);
        }
        /// <summary>
        /// Пополнение счета
        /// </summary>
        /// <param name="trigger"></param>
        public void TopUp(string trigger)
        {
            if (trigger == "Curent") { SelectedClient.Curent.TopUp(Summa); }
            else { SelectedClient.Deposit.TopUp(Summa); }

        }
        /// <summary>
        /// создание текущего счета
        /// </summary>
        public void AddAccount(string trigger)
        {
            if (trigger == "Curent")
            {
                SelectedClient.AddCurent();
            }
            else 
            {
                SelectedClient.AddDeposit();
            }
        }
        public ObservableCollection<Client> Clients 
        {
            get { return this._clients; } 
            set 
            {
                this._clients = value;
                OnPropertyChanged(nameof(Clients));
                
            }
        }
        /// <summary>
        /// пробное заполнение данными
        /// </summary>
        public ViewModel()
        {
            Clients = new ObservableCollection<Client>
            {
                new Client("иванов0", "иван0", "иванович0", "04818 552233", "088005553535"),
                new Client("иванов1", "иван1", "иванович1", "14818 552233", "188005553535"),
                new Client("иванов2", "иван2", "иванович2", "24818 552233", "288005553535")
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
