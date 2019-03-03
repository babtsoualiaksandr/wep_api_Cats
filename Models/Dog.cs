using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wg_backend.Models
{
    [Table("dogs")]
    public class Dog
    {
        [Column("name")]
        [Key]
        public string Name { get; set; }
        [Column("color")]
        public cat_color Color { get; set; }
        [Column("tail_length")]
        public int Tail_length { get; set; }
        [Column("whiskers_length")]
        public int Whiskers_length { get; set; }

    }




}