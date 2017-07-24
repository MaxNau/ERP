using ERP.DataEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ERP
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeWorkingSchedule ews = new EmployeeWorkingSchedule()
            {
                WorkingSchedule = new List<DailyWorkingSchedule>()
            };

            Employee assigner = new Employee()
            {
                FirstName = "Jor",
                LastName = "Berth",
                MiddleName = "Mauri",
                SalaryPerHour = 2.5m
            };

            DailyWorkingSchedule dws = new DailyWorkingSchedule()
            {
                EmployeeWorkingSchedule = ews,
                WorkingDate = DateTime.Now,
                WorkingHours = 8 
            };

            DailyWorkingSchedule dws2 = new DailyWorkingSchedule()
            {
                EmployeeWorkingSchedule = ews,
                WorkingDate = DateTime.Now.AddDays(1),
                WorkingHours = 8
            };

            DailyWorkingSchedule dws3 = new DailyWorkingSchedule()
            {
                EmployeeWorkingSchedule = ews,
                WorkingDate = DateTime.Now.AddDays(2),
                WorkingHours = 8
            };

            ews.Employee = assigner;
            ews.Position = "Proprietor";
            ews.WorkingSchedule.Add(dws);
            ews.WorkingSchedule.Add(dws2);
            ews.WorkingSchedule.Add(dws3);

        /*    using (SoenenHendrikErpContextDb context = new SoenenHendrikErpContextDb())
            {
                context.Employees.Add(assigner);
                context.EmployeeWorkingSchedules.Add(ews);
                context.SaveChanges();
            }*/

            Employee emp;
            using (SoenenHendrikErpContextDb context = new SoenenHendrikErpContextDb())
            {
                emp = context.Employees.Include("WorkingSchedule")
                    .Include("WorkingSchedule.WorkingSchedule").
                    FirstOrDefault(e => e.FirstName == "Jor");
            }

            Employee responsible1 = new Employee()
                {
                    FirstName = "Resnonsible",
                    LastName = "ForThe",
                    MiddleName = "Task",
                    SalaryPerHour = 8.5m
                };

            List<Employee> responsible = new List<Employee>();
            responsible.Add(responsible1);

            List<Employee> responsibleForSubtask = new List<Employee>
            {
                new Employee()
            {
                FirstName = "Resnonsible",
                LastName = "ForThe",
                MiddleName = "SubTask",
                SalaryPerHour = 8.5m
            }
            };

            Product productToAssemble = new Product()
            {
                Name = "Machine",
                Price = 300,
                Quantity = 3
            };

            List<SubTask> subtasks = new List<SubTask> {
                new ProductionSubTask(){
                Assigned = DateTime.Now,
                Startetd = DateTime.Now,
                Assigner = assigner,
                Budget = 1000m,
                Deadline = DateTime.Now.AddDays(3),
                IsCompleted = false,
                ReportProgressInterval = 60,
                Title = "Some tasks to do subtask",
                Status = Status.InProgress,
                Hello = "Heloo from sub task",
                ResponsiblePersons = responsibleForSubtask
            }};

            ProductionTask t = new ProductionTask()
            {
                Assigned = DateTime.Now,
                Startetd = DateTime.Now,
                Assigner = assigner,
                Budget = 1000m,
                Deadline = DateTime.Now.AddDays(3),
                IsCompleted = false,
                ReportProgressInterval = 60,
                Title = "Some tasks to do",
                Status = Status.InProgress,
                Product = productToAssemble,
                SubTasks = subtasks,
                ResponsiblePersons = responsible
            };

            
            using (var context = new SoenenHendrikErpContextDb())
            {
                context.Tasks.Add(t);
                context.SaveChanges();
            }

            List<ProductionTask> tasks = new List<ProductionTask>();

            using (var context = new SoenenHendrikErpContextDb())
            {
                tasks = context.Tasks.Include("Product").Include("Assigner")
                    .Include("ResponsiblePersons")
                    .Include("SubTasks").OfType<ProductionTask>().ToList();
            }


            Console.WriteLine("ss");
        }
    }
}
