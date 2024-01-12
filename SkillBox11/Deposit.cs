using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox11
{
    internal class Deposit : Account , ITopUp<Deposit>
    {
        public int InterestRate { get; set; }
        public Deposit()
        {
            AccountNumber = base.random.Next(11111111, 99999999);
            Sum = 0;
            OpenningDate = DateTime.Now;
            IsActive = true;
            ClosedDate = DefaultTime;
            InterestRate = base.random.Next(6,15);
        }
        /// <summary>
        /// пополнение счета
        /// </summary>
        /// <param name="sum"></param>
        /// <returns></returns>
        public Deposit TopUp(int sum)
        {
            this.Sum += sum;
            return this;
        }
    }
}
