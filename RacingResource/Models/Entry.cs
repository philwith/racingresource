using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RacingResource.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public virtual Horse Horse { get; set; }
        public virtual Race Race { get; set; }
    }
}