using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Models
{
    abstract class Shape
    {
       public abstract double Area();

        public void Describe()
        {
            Console.WriteLine($"{this.ToString()} Area : {Area().ToString()}");

        }
    }
}
