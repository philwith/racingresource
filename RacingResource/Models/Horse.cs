using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RacingResource.Models
{
    [DisplayColumn("Name")]
    public class Horse
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [DisplayName("Year of Birth")]
        public int YearOfBirth { get; set; }
        public int UKHR_HorseID { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}