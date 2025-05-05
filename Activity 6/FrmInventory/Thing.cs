using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileIO
{
    [Serializable]
    public class Thing
    {
        public int Id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }

        public Thing()
        {
            
        }

        public override string ToString()
        {
            // Concatenate three properties
            return $"Id = {Id}, Name = {Name}, Value = {Value:C2}";
        }
    }
}
