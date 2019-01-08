using System.ComponentModel;

namespace Employees.Models
{
    /// <summary>
    /// отдел
    /// </summary>
    public class Department
    {
        /// <summary>
        /// ид
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// название отдела
        /// </summary>
        [DisplayName("Отдел")]
        public string Title { get; set; }

        /// <summary>
        /// этаж
        /// </summary>
        [DisplayName("Этаж")]
        public int Floor { get; set; }
    }
}