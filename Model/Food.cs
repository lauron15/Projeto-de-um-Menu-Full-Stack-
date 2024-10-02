using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foods.Model
{

    [Table("foods")]
    public class Food
    {
        [Key]
        [Column("id")]
        public long id { get; set; }
        [Column("title")]
        public string? name { get; set; }
        [Column("image")]
        public string? image { get; set; }
        [Column("price")]
        public int price { get; set; }
    }
}
