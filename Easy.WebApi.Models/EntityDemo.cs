using System.ComponentModel.DataAnnotations.Schema;

namespace Easy.WebApi.Models
{
    [Table("demo", Schema = "dbo")]
    public class EntityDemo
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}