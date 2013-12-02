using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RacingResource.Models
{
    public class ResultPage
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int BhaRid { get; set; }
        public int BhaCid { get; set; }
        public virtual MeetingPage MeetingPage { get; set; }
    }
}