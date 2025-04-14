using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrder
{
    public class PizzaOrder : IComparable
    {
        // properties of a PizzaOrder
        public string Name { get; set; }
        public bool[] Toppings { get; set; }
        public List<string> StrangeAddOns { get; set; }
        public int SauceQty { get; set; }
        public int GarlicQty { get; set; }
        public int ParmesanQty { get; set; }
        public DateTime Delivery {  get; set; }
        public decimal HungerLevel { get; set; }
        public string SauceColor { get; set; }
        public string CookedLevel { get; set; }
        public int CookedLevelValue { get; set; }
        public string CrustType { get; set; }
        public string Picture { get; set; }

        // Constructor to intialize with default values
        public PizzaOrder() 
        {
            Name = "";
            Toppings = new bool[8];
            StrangeAddOns = new List<string>();
            SauceQty = 0;
            GarlicQty = 0;
            ParmesanQty = 0;
            Delivery = DateTime.Now.AddHours(1);
            HungerLevel = 0;
            SauceColor = "Red";
            CookedLevel = "Normal";
            CookedLevelValue = 5;
            CrustType = "Hand Tossed";
            Picture = string.Empty;
        }

        // To compare the pizza orders by delivery time for sorting
        public int CompareTo(object? obj)
        {
            if (obj == null)
                return 1;

            PizzaOrder other = obj as PizzaOrder;
            if (other != null)
                return this.Delivery.CompareTo(other.Delivery);
            else
                throw new ArgumentException("Object is not a PizzaOrder");
        }
    }
}
