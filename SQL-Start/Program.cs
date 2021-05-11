using System;
using System.ServiceProcess;
using System.Threading;

namespace SQL_Start
{
    class Program
    {
        static void Main(string[] args)
        {
            string instancia = "BDD21A";
            string[] services = {$"SQL Server ({instancia})", $"SQL Server Agent ({instancia})", "SQL Server Browser", $"SQL Full-text Filter Daemon Launcher ({instancia})"};
            Console.Write("Corriendo Servicios de SQL para la instancia: {0}\n", instancia);
            for(int i = 0; i<services.Length; i++) 
            {
                Console.WriteLine("\nServicio: {0}", services[i]);
                ServiceController service = new ServiceController(services[i]);
                if (service.Status.Equals(ServiceControllerStatus.Stopped))
                {
                    service.Start();
                    Console.Write(" Corriendo...");
                }
                else
                {
                    Console.Write(" Ya estaba jalando...");
                }
                
            }
            Console.WriteLine("Corriendo SQL Server Management Studio...");
            System.Diagnostics.Process.Start(@"E:\Program Files (x86)\Microsoft SQL Server Management Studio 18\Common7\IDE\Ssms.exe");

            //Thread.Sleep(3000);
            Console.WriteLine("\nPuto el que lo lea");
            Thread.Sleep(1000);
        }
    }
}
