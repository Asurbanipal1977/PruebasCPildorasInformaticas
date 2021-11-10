using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaThread
{
	public class Program
	{
		static void Main(string[] args)
		{
			Thread hilo2 = new Thread(MetodoPrueba);
			hilo2.Name = "Hilo 2";
			hilo2.Start();
			hilo2.Join();

			Thread hilo3 = new Thread(MetodoPrueba);
			hilo3.Name = "Hilo 3";
			hilo3.Start();
			hilo3.Join();

			Console.WriteLine("Prueba de hilo 1");
			Thread.Sleep(500);
			Console.WriteLine("Prueba de hilo 1");
			Thread.Sleep(500);
			Console.WriteLine("Prueba de hilo 1");
			Thread.Sleep(500);
			Console.WriteLine("Prueba de hilo 1");
			Thread.Sleep(500);			
		}

		public static void MetodoPrueba()
		{
			Console.WriteLine($"Prueba de {Thread.CurrentThread.Name}");
			Thread.Sleep(500);
			Console.WriteLine($"Prueba de {Thread.CurrentThread.Name}");
			Thread.Sleep(500);
			Console.WriteLine($"Prueba de {Thread.CurrentThread.Name}");
			Thread.Sleep(500);
			Console.WriteLine($"Prueba de {Thread.CurrentThread.Name}");
			Thread.Sleep(500);
		}
	}


}
