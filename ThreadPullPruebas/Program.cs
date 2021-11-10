using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPullPruebas
{
	class Program
	{
		static void Main(string[] args)
		{
			//ThreadPool threadPool = new ThreadPool();

			for (int i = 0; i < 100; i++)
			{
				//Thread thread = new Thread(EjecutarTarea);
				//thread.Start();

				ThreadPool.QueueUserWorkItem(EjecutarTarea, i);
			}

			Console.ReadLine();
		}

		static void EjecutarTarea(Object oTarea)
		{
			Console.WriteLine($"Thread nº: {Thread.CurrentThread.ManagedThreadId} ha comenzado la tarea nº {oTarea}");
			Thread.Sleep(1000);
			Console.WriteLine($"Thread nº: {Thread.CurrentThread.ManagedThreadId} ha terminado la tarea nº {oTarea}");
		}
	}
}
