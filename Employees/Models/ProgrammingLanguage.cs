using System.ComponentModel;

namespace Employees.Models
{
    /// <summary>
    /// язык программирования
    /// </summary>
    public class ProgrammingLanguage
    {
        /// <summary>
        /// ид
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// название языка программирования
        /// </summary>
        [DisplayName("Язык программирования")]
        public string Title { get; set; }
    }
}