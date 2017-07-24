using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DataEntities
{
    public class EmployeeWorkingSchedule
    {
        public string Position { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<DailyWorkingSchedule> WorkingSchedule { get; set; }
    }

    class SoenenHendrikErpEmployeeWorkingScheduleConfiguration : EntityTypeConfiguration<EmployeeWorkingSchedule>
    {
        public SoenenHendrikErpEmployeeWorkingScheduleConfiguration()
        {
            HasKey(ews => ews.EmployeeId);
            Property(ews => ews.EmployeeId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
        }
    }
}
