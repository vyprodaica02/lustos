using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Enums.TimeKeepingEnum
{
    public enum WorkShiftStatusEnum
    {
        /// <summary>
        /// Chờ Finance Team hoặc Admin đồng ý từ chối thì thành DENY
        /// </summary>
        WAITACCEPT = 1,
        ACTIVE = 2,
        DENY = 3,
        CLOSE = 4,
    }
}
