using System;
using DataAccess;

namespace AFCentral.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SqlServerAccess ssa = new SqlServerAccess(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AFCentral;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            
            System.Console.WriteLine("Please enter your First Name:");
            var firstName =System.Console.ReadLine();

            System.Console.WriteLine("Please enter your Surname:");
            var surname = System.Console.ReadLine();

            System.Console.WriteLine("Please enter your Printer Code:");
            var printerCode = System.Console.ReadLine();

            System.Console.WriteLine(ssa.InsertFacilitator(firstName, surname, printerCode));



        }
    }
}
