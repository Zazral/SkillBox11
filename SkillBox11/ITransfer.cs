using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox11
{
    internal interface ITransfer<in T>
    {
        void Transfer(T Account, int sum);
    }
}
