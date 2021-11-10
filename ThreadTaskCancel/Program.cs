using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTaskCancel
{
	class Program
	{
		private static int acumulador = 0;
		static void Main(string[] args)
		{
			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
			CancellationToken cancellationToken = cancellationTokenSource.Token; //Es el token a cancelar
			Task task = Task.Run(() => EjecutarTarea(cancellationToken));

			for (int i = 0; i < 100; i++)
			{
				acumulador+=30;
				Thread.Sleep(1000);

				if (acumulador >= 100)
				{
					cancellationTokenSource.Cancel();
					break;
				}
			}

			Console.ReadLine();
		}

		static void EjecutarTarea(CancellationToken cancellationToken)
		{
			for (int i = 0; i < 100; i++)
			{
				if (acumulador >= 100 || cancellationToken.IsCancellationRequested)
				{
					return;
				}

				acumulador++;

				var miThread = Thread.CurrentThread.ManagedThreadId;
				Thread.Sleep(1000);
				Console.WriteLine($"Ejecutando tarea el Thread {miThread}");
				Console.WriteLine(acumulador);

				
			}
		}
	}
}
