using System.Data.Entity;
using Employees.Models;

namespace Employees.Context
{
    /// <summary>
    /// подключение к базе данных
    /// </summary>
    public class BaseContext : DbContext
    {
        public BaseContext() : base("DefaultConnection")
        {

        }

        /// <summary>
        /// сотрудники
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// отделы
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// языки программирования
        /// </summary>
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    }
}