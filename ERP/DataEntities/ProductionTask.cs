using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DataEntities
{
    public class ProductionTask : Task
    {
        public virtual Product Product { get; set; }
    }

    class SoenenHendrikErpProductionTaskConfiguration : EntityTypeConfiguration<ProductionTask>
    {
        public SoenenHendrikErpProductionTaskConfiguration()
        {
            HasRequired(pt => pt.Product).WithRequiredPrincipal(p => p.ProductionTask);
        }
    }
}
