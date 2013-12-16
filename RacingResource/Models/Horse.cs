using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RacingResource.Models
{
    [DisplayColumn("Name")]
    public class Horse
    {
        public int Id { get; set; }
        [MaxLength(255)]
        [DisplayFormat(NullDisplayText = "-")]
        public string Name { get; set; }
        [DisplayFormat(NullDisplayText = "-")]
        public string Nationality { get; set; }
        [DisplayFormat(NullDisplayText = "-")]
        [DisplayName("Year of Birth")]
        public int? YearOfBirth { get; set; }
        [DisplayFormat(NullDisplayText = "-")]
        public string Sex { get; set; }
        [DisplayFormat(NullDisplayText = "-")]
        public int? FlatRating { get; set; }
        [DisplayFormat(NullDisplayText = "-")]
        public int? AWRating { get; set; }
        [DisplayFormat(NullDisplayText = "-")]
        public int? ChaseRating { get; set; }
        [DisplayFormat(NullDisplayText = "-")]
        public int? HurdleRating { get; set; }
        [DisplayFormat(NullDisplayText = "-")]
        [ScaffoldColumn(false)]
        public int? UKHR_HorseID { get; set; }
        [DisplayFormat(NullDisplayText = "-")]
        public int? SireId { get; set; }
        [DisplayFormat(NullDisplayText = "-")]
        public int? DamId { get; set; }
        [DisplayFormat(NullDisplayText = "-")]
        public virtual Trainer Trainer { get; set; }
        [ForeignKey("SireId")]
        [DisplayFormat(NullDisplayText = "-")]
        public virtual Horse Sire { get; set; }
        [ForeignKey("DamId")]
        [DisplayFormat(NullDisplayText = "-")]
        public virtual Horse Dam { get; set; }
        [ForeignKey("SireId")]
        [DisplayFormat(NullDisplayText = "-")]
        public virtual ICollection<Horse> SireProgeny { get; set; }
        [ForeignKey("DamId")]
        [DisplayFormat(NullDisplayText = "-")]
        public virtual ICollection<Horse> DamProgeny { get; set; }
        public string TwitterId { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}