using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox11
{
    internal class Client : INotifyPropertyChanged
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _patronymic;
        private string _passport;
        private string _phoneNumber;
        private Account _curent;
        private Deposit _deposit;
        public int Id { get { return this._id; } set { this._id = value; } }
        public string FirstName { get { return this._firstName; } set { this._firstName = value; } }
        public string LastName { get { return this._lastName; } set { this._lastName = value; } }
        public string Patronymic { get { return this._patronymic; } set { this._patronymic = value; } }
        public string Passport { get { return this._passport; } set { this._passport = value; } }
        public string PhoneNumber { get { return this._phoneNumber; } set { this._phoneNumber = value; } }
        public Account Curent 
        {
            get { return this._curent; } 
            set
            { 
                this._curent = value;
                OnPropertyChanged("Curent");
            }
        }
        public Deposit Deposit 
        { 
            get { return this._deposit; } 
            set 
            { 
                this._deposit = value;
                OnPropertyChanged("Deposit");
            } 
        }
        public Client() { }
        /// <summary>
        /// конструктор создания нового клиента
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="patronymic"></param>
        /// <param name="passport"></param>
        /// <param name="phoneNumber"></param>
        public Client(string firstName, string lastName, string patronymic, string passport, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Passport = passport;
            PhoneNumber = phoneNumber;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        /// <summary>
        /// добавление текущего счета
        /// </summary>
        /// <param name="sum"></param>
        public void AddCurent()
        {
            if (this.Curent == null || this.Curent.IsActive == false)
            {
                this.Curent = new Account();
            }
                
        }
        /// <summary>
        /// добавление депозитного счета
        /// </summary>
        public void AddDeposit()
        {
            if (this.Deposit == null || this.Deposit.IsActive == false)
            {
                this.Deposit = new Deposit();
            }
        }
        /// <summary>
        /// закрытие выбранного счета
        /// </summary>
        /// <param name="trigger"></param>
        public void Close(string trigger)
        {
            if (trigger == "Curent")
            {
                this.Curent.CloseAccount();
            }
            else this.Deposit.CloseAccount();
        }
        /// <summary>
        /// перевод между счетами клиента
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="trigger"></param>
        public void MyTransfer(int sum, string trigger)
        {
            if (trigger == "ToDeposit")
            {
                this.Curent.Sum -= sum;
                this.Deposit.Sum += sum;
            }
            else
            {
                this.Deposit.Sum -= sum;
                this.Curent.Sum += sum;
            }
            
        }
    }
}
