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

			Thread hilo3 = new Thread(() =>
			{
				for (int j = 0; j < 5; j++)
				{
					Console.WriteLine("Hilo de Ejecución 3");
					Thread.Sleep(1000);
				}
			});

			Thread hilo = new Thread(() =>
			{
				for (int j = 0; j < 5; j++)
				{
					Console.WriteLine("Hilo de Ejecución 1");
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

				tareaTerminada.TrySetResult(true);
			});

			hilo3.Start();
			hilo.Start();
			var resultado = tareaTerminada.Task.Result;

			hilo2.Start();

		}
	}
}

