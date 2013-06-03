using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RacingResource.Models
{
    public class Course
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public int UKHR_CourseID { get; set; }
    }
}