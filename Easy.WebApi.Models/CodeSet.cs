using System.ComponentModel.DataAnnotations.Schema;

namespace Easy.WebApi.Models
{
    [Table("CodeSet", Schema = "dbo")]
    public class CodeSet
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("code")]
        public string Code { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("spell")]
        public string Spell { get; set; }

        [Column("wb")]
        public string Wb { get; set; }

        [Column("note")]
        public string Note { get; set; }

        [Column("remark")]
        public string Remark { get; set; }
    }
}