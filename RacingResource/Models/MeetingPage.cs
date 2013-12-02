using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RacingResource.Models
{
    public class MeetingPage
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public virtual ICollection<ResultPage> ResultPages { get; set; }
    }
}