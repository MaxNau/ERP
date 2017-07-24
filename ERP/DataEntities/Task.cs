using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace ERP.DataEntities
{
    public abstract class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Assigned { get; set; }
        public DateTime Startetd { get; set; }
        public DateTime Deadline { get; set; }
        public decimal Budget { get; set; }
        public int ReportProgressInterval { get; set; }
        public bool IsCompleted { get; set; }
        public Status Status { get; set; }
        public bool IsSubTask { get; protected set; }
        public virtual Employee Assigner { get; set; }

        public virtual ICollection<Employee> ResponsiblePersons { get; set; }
        public virtual ICollection<SubTask> SubTasks { get; set; }

        public Task()
        {
            IsSubTask = false;
        }
    }

    class SoenenHendrikErpTaskConfiguration : EntityTypeConfiguration<Task>
    {
        public SoenenHendrikErpTaskConfiguration()
        {
            Property(t => t.Title).IsRequired();
            Property(t => t.Assigned).IsRequired();
            Property(t => t.Startetd).IsOptional();
            Property(t => t.Deadline).IsOptional();
            Property(t => t.Budget).IsOptional();
            Property(t => t.ReportProgressInterval).IsOptional();
            Property(t => t.IsCompleted).IsRequired();
            Property(t => t.Status).IsRequired();
            HasRequired(t => t.Assigner)
                .WithMany(e => e.Tasks);
            Map<ProductionTask>(m => m.Requires("Type").HasValue("ProductionTask"));
        }
    }

    public enum Status
    {
        InProgress,
        Completed,
        Failed,
        OnHold
    }
}
