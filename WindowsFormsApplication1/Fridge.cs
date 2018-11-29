using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApplication1
{
    [DataContract]
    public class Fridge
    {
        public enum Comfort {Perfect, Good, Passably, Unset};
        [DataMember]
        public string make { get; set; }
        [DataMember]
        public decimal price { get; set; }
        [DataMember]
        public decimal volume { get; set; }
        [DataMember]
        public decimal reliability { get; set; }
        [DataMember]
        public Comfort comfort { get; set; }
        
        public DateTime creationDate;

        public Fridge()
        {
            this.make = "";
            this.price = 0;
            this.volume = 0;
            this.reliability = 0;
            this.comfort = Comfort.Unset;
            creationDate = DateTime.Today;
        }
        public Fridge(string make, decimal price, decimal volume, decimal reliability, Comfort comfort)
        {
            this.make = make;
            this.price = price;
            this.volume = volume;
            this.reliability = reliability;
            this.comfort = comfort;
            creationDate = DateTime.Today;
        }
    }
}
