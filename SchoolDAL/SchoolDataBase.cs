using Microsoft.EntityFrameworkCore;
using SchoolDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDAL
{
    public class SchoolDataBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SchoolDataBase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Client> Clients { set; get; }

        public virtual DbSet<Cost> Costs { set; get; }

        public virtual DbSet<Employee> Employees { set; get; }

        public virtual DbSet<Lesson> Lessons { set; get; }

        public virtual DbSet<Payment> Payments { set; get; }

        public virtual DbSet<Society> Societies { set; get; }

        public virtual DbSet<SocietyCost> SocietyCosts { set; get; }

        public virtual DbSet<SocietyLesson> SocietyLessons { set; get; }

        public virtual DbSet<User> Users { set; get; }
    }
}
