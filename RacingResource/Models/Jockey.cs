using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RacingResource.Models
{
    public class Jockey
    {
        public int Id { get; set; }
        [MaxLength(10)]
        [Required]
        public string Initials { get; set; }
        [MaxLength(255)]
        public string Forenames { get; set; }
        [MaxLength(255)]
        [Required]
        public string Surname { get; set; }
        [MaxLength(255)]
        public string LicenceType { get; set; }
        [MaxLength(15)]
        public string TwitterId { get; set; }
        
    }
}