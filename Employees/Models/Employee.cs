using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Models
{
    /// <summary>
    /// сотрудник
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// ид
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// имя
        /// </summary>
        [DisplayName("Имя")]
        public string Name { get; set; }

        /// <summary>
        /// фамилия
        /// </summary>
        [DisplayName("Фамилия")]
        public string Surname { get; set; }

        /// <summary>
        /// возраст
        /// </summary>
        [Range(1, Int32.MaxValue)]
        [DisplayName("Возраст")]
        public int Age { get; set; }

        /// <summary>
        /// ид отдела
        /// </summary>
        [DisplayName("Отдел")]
        public long DepartmentId { get; set; }

        /// <summary>
        /// отдел
        /// </summary>
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        /// <summary>
        /// ид языка программирования
        /// </summary>
        [DisplayName("Язык программирования")]
        public long ProgrammingLanguageId { get; set; }

        /// <summary>
        /// язык программирования
        /// </summary>
        [ForeignKey("ProgrammingLanguageId")]
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
    }
}