using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RacingResource.Models
{
    [DisplayColumn("Name")]
    public class Race
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name{ get; set; }
        public DateTime OffTime { get; set; }
        public int? Distance { get; set; }
        public int? Prize { get; set; }
        public string Going { get; set; }
        public int BhaRid { get; set; }
        public int BhaCid { get; set; }
        public virtual RaceType Type { get; set; }
        public virtual RaceGrade Grade { get; set; }
        public virtual Meeting Meeting { get; set; }
        public virtual Feature Feature { get; set; }
        public virtual ICollection<Entry> Entries { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}