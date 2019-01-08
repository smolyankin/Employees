namespace Emplyees.Models
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
        /// название
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// этаж
        /// </summary>
        public int Floor { get; set; }
    }
}