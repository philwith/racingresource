using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RacingResource.Models
{
    [DisplayColumn("Surname")]
    public class Trainer
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Forename { get; set; }
        [MaxLength(255)]
        public string Surname { get; set; }
        [MaxLength(255)]
        public string LicenceType { get; set; }
        [ScaffoldColumn(false)]
        public int? UKHR_TrainerID { get; set; }
        public int? AddressId { get; set; }
        public virtual ICollection<Horse> Horses { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }
        public string TwitterId { get; set; }
        public string AlternateForename { get; set; }
        [DefaultValue(true)]
        public Boolean IsActive { get; set; }
    }
}