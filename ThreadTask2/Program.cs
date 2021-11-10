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
		static void Main(string[] args)
		{
			EjecutarTarea();

			Task tarea = Task.Run(EjecutarTarea);
			Task tarea2 = Task.Run(EjecutarTarea2);
			Task.WaitAll(tarea,tarea2);
			Task tarea3 = Task.Run(EjecutarTarea3);

			Console.ReadLine();
		}

		static void EjecutarTarea()
		{
			for (int i = 0; i < 5; i++)
			{
				int thread = Thread.CurrentThread.ManagedThreadId;
				Thread.Sleep(1000);
				Console.WriteLine($"Este Thread es {thread} de la tarea 1");
			}
		}

		static void EjecutarTarea2()
		{
			for (int i = 0; i < 5; i++)
			{
				int thread = Thread.CurrentThread.ManagedThreadId;
				Thread.Sleep(500);
				Console.WriteLine($"Este Thread es {thread} de la tarea 2");
			}
		}

		static void EjecutarTarea3()
		{
			for (int i = 0; i < 5; i++)
			{
				int thread = Thread.CurrentThread.ManagedThreadId;
				Thread.Sleep(500);
				Console.WriteLine($"Este Thread es {thread} de la tarea 3");
			}
		}


	}
}
