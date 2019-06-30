using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractLawFirm
{
    public enum OrderStatus
    {
        Ожидает_подтверждения = 0,
        Ожидает_оплаты = 1,
        В_кредите = 2,
        Оплачен = 3
    }
}
