using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RacingResource.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string Position { get; set; }
        [MaxLength(20)]
        public string Distance { get; set; }
        public double? StartingPrice { get; set; }
        public int? Weight { get; set; }
        public int? Rating { get; set; }
        public virtual Horse Horse { get; set; }
        public virtual Jockey Jockey { get; set; }
        public virtual Race Race { get; set; }
        public int? Draw { get; set; }
        public int? BhaId { get; set; }
    }
}