using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Models
{
    internal class Circle:Shape,IDrawable
    {
        public override double Area()
        {
            return 25.0;
        }

        public  void Draw()
        {
            Console.WriteLine (" circle drawing");
        }

    }
}
