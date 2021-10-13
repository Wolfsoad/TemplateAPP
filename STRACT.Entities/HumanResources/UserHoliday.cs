using STRACT.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.HumanResources
{
    public class UserHoliday
    {
        public int UserHolidayId { get; set; }
        public DateTime DataOfHoliday { get; set; }
        public int UserInTeamId { get; set; }
        public UserInTeam User { get; set; }
    }
}
