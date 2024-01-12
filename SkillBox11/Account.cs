using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox11
{
    internal class Account : ITopUp<Account>, ITransfer<Client>, INotifyPropertyChanged
    {
        private int _sum;
        private DateTime _open;
        private DateTime _close;
        public long AccountNumber { get; set; }
        public int Sum
        {
            get { return this._sum; }
            set
            {
                this._sum = value;
                OnPropertyChanged("Sum");
            }
        }
        public DateTime OpenningDate
        {
            get { return this._open; }
            set
            {
                this._open = value;
                OnPropertyChanged("OpenningDate");
            }
        }
        public DateTime ClosedDate
        {
            get { return this._close; }
            set
            {
                this._close = value;
                OnPropertyChanged("ClosedDate");
            }
        }
        public bool IsActive { get; set; }
        protected Random random = new Random();
        public DateTime DefaultTime = new DateTime();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// конструктор создания нового счета
        /// </summary>
        /// <param name="sum">сумма с которой создается счет</param>
        public Account()
        {
            AccountNumber = random.Next(11111111, 99999999);
            Sum = 0;
            OpenningDate = DateTime.Now;
            IsActive = true;
            ClosedDate = DefaultTime;
        }
        /// <summary>
        /// закрытие счета
        /// </summary>
        public void CloseAccount()
        {
            this.Sum = 0;
            this.IsActive = false;
            this.ClosedDate = DateTime.Now;
        }
        /// <summary>
        /// пополнение счета
        /// </summary>
        /// <param name="sum"></param>
        /// <returns></returns>
        public Account TopUp(int sum)
        {
            this.Sum += sum;
            return this;
        }
        /// <summary>
        /// перевод другому клиенту с текущего счета
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="sum"></param>
        public void Transfer(Client Account, int sum)
        {
            this.Sum -= sum;
            Account.Curent.Sum += sum;
        }
    }
}
