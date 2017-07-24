namespace ERP.DataEntities
{
    using System.Data.Entity;

    public class SoenenHendrikErpContextDb : DbContext
    {
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SubTask> SubTasks { get; set; }
        public virtual DbSet<EmployeeWorkingSchedule> EmployeeWorkingSchedules { get; set; }
        public virtual DbSet<DailyWorkingSchedule> DayliWorkingSchedules { get; set; }

        public SoenenHendrikErpContextDb()
            : base("name=SoenenHendrikErpDb")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SoenenHendrikErpContextDb>());

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SoenenHendrikErpContextDb>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SoenenHendrikErpTaskConfiguration());
            modelBuilder.Configurations.Add(new SoenenHendrikErpProductionTaskConfiguration());
            modelBuilder.Configurations.Add(new SoenenHendrikErpSubTaskConfiguration());
            modelBuilder.Configurations.Add(new SoenenHendrikErpEmployeeConfiguration());
            modelBuilder.Configurations.Add(new SoenenHendrikErpEmployeeWorkingScheduleConfiguration());
            modelBuilder.Configurations.Add(new SoenenHendrikErpDayliWorkingScheduleConfiguration());
            
        }
    }
}