using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ComplexHost
{
    class Service
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Microsoft.ServiceModel.Samples.ComplexCalculatorService)))
            {
                host.Open();
                Console.WriteLine("Host Started");
                Console.ReadKey();
            }

        }
    }
}
