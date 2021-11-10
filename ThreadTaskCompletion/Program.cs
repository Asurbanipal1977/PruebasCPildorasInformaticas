using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTaskCompletion
{
	class Program
	{
		static void Main(string[] args)
		{
			var tareaTerminada = new TaskCompletionSource<bool>();
			var tareaTerminada2 = new TaskCompletionSource<bool>();

			Thread hilo = new Thread(() =>
			{
				for (int j = 0; j < 5; j++)
				{
					Console.WriteLine("Hilo de Ejecución");
					Thread.Sleep(1000);
				}
				tareaTerminada.TrySetResult(true);
			});

			Thread hilo2 = new Thread(() =>
			{
				for (int j = 0; j < 5; j++)
				{
					Console.WriteLine("Hilo de Ejecución 2");
					Thread.Sleep(1000);
				}

				tareaTerminada2.TrySetResult(true);
			});

			Thread hilo3 = new Thread(() =>
			{
				for (int j = 0; j < 5; j++)
				{
					Console.WriteLine("Hilo de Ejecución 3");
					Thread.Sleep(1000);
				}
			});

			hilo.Start();
			var resultado = tareaTerminada.Task.Result;
			hilo2.Start();
			var resultado2 = tareaTerminada2.Task.Result;
			hilo3.Start();
			var resultado3 = tareaTerminada3.Task.Result;

		}
	}
}

