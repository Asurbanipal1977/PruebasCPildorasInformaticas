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
			Task tarea = Task.Run(EjecutarTarea);

			Task tarea2 = tarea.ContinueWith(EjecutarTarea2);

			Console.ReadLine();
		}

		static void EjecutarTarea()
		{
			for (int i = 0; i < 10; i++)
			{
				int thread = Thread.CurrentThread.ManagedThreadId;
				Thread.Sleep(1000);
				Console.WriteLine($"Este Thread es {thread}");
			}
		}

		static void EjecutarTarea2(Task task)
		{
			for (int i = 0; i < 10; i++)
			{
				int thread = Thread.CurrentThread.ManagedThreadId;
				Thread.Sleep(1000);
				Console.WriteLine($"Tarea correspondiente al hilo : {thread} ejecutándose desde el main");
			}
		}


	}
}
