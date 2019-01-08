using System.Data.Entity;
using Emplyees.Models;

namespace Emplyees.Context
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
        public DbSet<Emplyee> Emplyees { get; set; }

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