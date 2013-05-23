using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RacingResource.Models
{
    public class Horse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Year of Birth")]
        public int YearOfBirth { get; set; }
    }
}