using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RacingResource.Models
{
    [DisplayColumn("PostalCode")]
    public class Address
    {
        public int Id { get; set; }
        [MaxLength(255)]
        [DisplayFormat(NullDisplayText = "-")]
        public string StreetAddress { get; set; }
        [MaxLength(255)]
        [DisplayFormat(NullDisplayText = "-")]
        public string AddressLocality { get; set; }
        [MaxLength(255)]
        [DisplayFormat(NullDisplayText = "-")]
        public string AddressRegion { get; set; }
        [MaxLength(10)]
        [DisplayFormat(NullDisplayText = "-")]
        public string PostalCode { get; set; }
    }
}