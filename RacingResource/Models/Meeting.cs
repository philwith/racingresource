using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RacingResource.Models
{
    [DisplayColumn("Name")]
    public class Meeting
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Race> Races { get; set; } 
    }
}