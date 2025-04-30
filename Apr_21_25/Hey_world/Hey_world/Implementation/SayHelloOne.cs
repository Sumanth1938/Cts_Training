using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hey_world.Implementation
{
    public class SayHelloOne : Interfaces.IsayHello
    {
        public void SayHello(string name)
        {
            Console.WriteLine("Hello from SayHelloOne");
        }
    }
}
