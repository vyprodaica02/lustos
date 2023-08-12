using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Design.Enums.TimeKeepingEnum
{
    public enum WorkShiftTypeEnum
    {
        STANDARD = 1,
        /// <summary>
        /// Phạm vi thời gian ca làm việc bị rơi vào giờ đêm lương sẽ phải tính đặc biệt
        /// </summary>
        OUTSTANDARD = 2,
    }
}
