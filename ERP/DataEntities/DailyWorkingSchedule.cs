using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DataEntities
{
    public class DailyWorkingSchedule
    {
        public int Id { get; set; }
        public DateTime WorkingDate { get; set; }
        public int WorkingHours { get; set; }
        public string Reason { get; set; }

        public virtual EmployeeWorkingSchedule EmployeeWorkingSchedule { get; set; }
    }

    class SoenenHendrikErpDayliWorkingScheduleConfiguration : EntityTypeConfiguration<DailyWorkingSchedule>
    {
        public SoenenHendrikErpDayliWorkingScheduleConfiguration()
        {
            HasRequired(dws => dws.EmployeeWorkingSchedule)
                .WithMany(ews => ews.WorkingSchedule);
        }
    }
}
