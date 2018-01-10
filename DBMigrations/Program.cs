using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMigrations
{
    class Program
    {
        private static AdminBusinessOperations bl = new AdminBusinessOperations();
        static void Main(string[] args)
        {            
            bl.SetRoles();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
