using System;

namespace OPI.HHS.Core.Models
{
    public class AddressSearchResult
    {
        private string _formattedAddress;
        private string _phone;
        public int Case { get; set; }
        public int Referral { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Type { get; set; }
        public string Phone {
            get { return _phone; }
            set {
                if (value != null && value.Length > 9)
                {
                    value = string.Format("{0:(###) ###-####}", long.Parse(value));
                }
                _phone = value; 
            }
        }
        public string FormattedAddress {
            get       {              return _formattedAddress;}               
            set {
                if ( value != null){   _formattedAddress = value.Replace(", USA","");                }
                        
            }
        }
    }
}
