using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alerter.Models
{
    public class TargetUrlModel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string UserId { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Url { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
    }
}
