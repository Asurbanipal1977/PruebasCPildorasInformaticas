using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTask
{
	class Program
	{
		private static int acumulador = 0;
		static void Main(string[] args)
		{
			//for (int i = 0; i < 100; i++)
			//{
			//	EjecutarTarea(i);
			//	Console.WriteLine($"Acumulador vale {acumulador}. Tarea realizada por {Thread.CurrentThread.ManagedThreadId}");
			//}

			Parallel.For(0, 100, EjecutarTarea);

			Console.ReadLine();
		}

		static void EjecutarTarea(int valor)
		{
			if (acumulador % 2 == 0)
			{
				acumulador += valor;
				Thread.Sleep(100);
			}
			else
			{
				acumulador -= valor;
				Thread.Sleep(100);
			}

			Console.WriteLine($"Acumulador vale {acumulador}. Tarea realizada por {Thread.CurrentThread.ManagedThreadId}");
		}
	}
}
