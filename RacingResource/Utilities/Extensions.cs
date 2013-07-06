using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using RacingResource.Models;

namespace RacingResource.Utilities
{
    public static class Extensions
    {
        public static string ToFormattedString(this Address address)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(address.StreetAddress))
            {
                sb.Append(address.StreetAddress);
                sb.Append(", ");
            }
            if (!string.IsNullOrEmpty(address.AddressLocality))
            {
                sb.Append(address.AddressLocality);
                sb.Append(", ");
            }
            if (!string.IsNullOrEmpty(address.AddressRegion))
            {
                sb.Append(address.AddressRegion);
                sb.Append(", ");
            }
            sb.Append(address.PostalCode);
            return sb.ToString();
        }
    }

}