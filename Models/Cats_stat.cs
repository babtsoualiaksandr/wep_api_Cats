using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wg_backend.Models
{
    [Table("cats_stat")]
    public class Cats_stat
    {
        [Key]
        public double tail_length_mean { get; set; }
        public double tail_length_median { get; set; }
        public int[] tail_length_mode { get; set; }
        public double whiskers_length_mean { get; set; }
        public double whiskers_length_median { get; set; }
        public int[] whiskers_length_mode { get; set; }
    }



}