using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox11
{
    internal interface ITopUp<out T> where T : Account
    {
        /// <summary>
        /// Пополнение счета
        /// </summary>
        /// <param name="sum">Сумма поплнения</param>
        /// <returns></returns>
        T TopUp(int sum);
    }
}
