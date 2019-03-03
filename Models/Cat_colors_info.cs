using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wg_backend.Models
{
    [Table("cat_colors_info")]
    public class Cat_colors_info
    {       
        
        [Column("color")]
        [Key]
        public cat_color Color {get; set;}
        [Column("count")]
        public int Count {get; set;}
    }

     

}