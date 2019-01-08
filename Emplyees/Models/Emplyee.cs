using System.ComponentModel.DataAnnotations.Schema;

namespace Emplyees.Models
{
    /// <summary>
    /// сотрудник
    /// </summary>
    public class Emplyee
    {
        /// <summary>
        /// ид
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// возраст
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// пол
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// ид отдела
        /// </summary>
        public long DepartmentId { get; set; }

        /// <summary>
        /// отдел
        /// </summary>
        [ForeignKey("Id")]
        public Department Department { get; set; }

        /// <summary>
        /// ид языка программирования
        /// </summary>
        public long ProgrammingLanguageId { get; set; }

        /// <summary>
        /// язык программирования
        /// </summary>
        [ForeignKey("Id")]
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
    }

    /// <summary>
    /// пол
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// все
        /// </summary>
        All,

        /// <summary>
        /// мужской
        /// </summary>
        Male,

        /// <summary>
        /// женский
        /// </summary>
        Female
    }
}