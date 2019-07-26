using System.ComponentModel.DataAnnotations.Schema;

namespace Easy.WebApi.Models
{
    /// <summary>
    ///
    /// </summary>
    [Table("demo", Schema = "dbo")]
    public class EntityDemo
    {
        /// <summary>
        ///
        /// </summary>
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Column("name")]
        public string Name { get; set; }
    }
}