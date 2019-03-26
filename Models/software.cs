using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rino.Models
{
    public class software
    {
        public int id { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string os { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string nombre { get; set; }
        [Column(TypeName = "money")]
        public double precio { get; set; }
    }
}