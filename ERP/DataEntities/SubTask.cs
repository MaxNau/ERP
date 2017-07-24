using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DataEntities
{
    public abstract class SubTask : Task
    {
        public virtual Task Tasks { get; set; }

        public SubTask()
        {
            IsSubTask = true;
        }
    }
    class SoenenHendrikErpSubTaskConfiguration : EntityTypeConfiguration<SubTask>
    {
        public SoenenHendrikErpSubTaskConfiguration()
        {
   
            Map<ProductionSubTask>(m => m.Requires("Type").HasValue("ProductionSubTask"));
        }
    }
}
