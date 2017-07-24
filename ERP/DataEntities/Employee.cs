using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DataEntities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public decimal SalaryPerHour { get; set; }

        public virtual SubTask SubTask { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public virtual EmployeeWorkingSchedule WorkingSchedule { get; set; }
    }

    class SoenenHendrikErpEmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public SoenenHendrikErpEmployeeConfiguration()
        {
            Property(e => e.FirstName).IsRequired();
            Property(e => e.LastName).IsRequired();
            Property(e => e.MiddleName).IsRequired();
            Property(e => e.SalaryPerHour).IsRequired();
            HasRequired(e => e.WorkingSchedule)
                .WithRequiredPrincipal(ews => ews.Employee);
        }
    }
}
