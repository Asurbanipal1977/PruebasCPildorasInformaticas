using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPruebaBanco
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Thread> lstThread = new List<Thread>();
			CuentaBancaria cuentaBancaria = new CuentaBancaria(1000);

			for (int i = 1; i <= 15; i++)
			{
				Thread hilo = new Thread(() =>
				{
					cuentaBancaria.SacarDinero(250);
					cuentaBancaria.SacarDinero(250);
					cuentaBancaria.SacarDinero(250);
					cuentaBancaria.SacarDinero(250);
				});
				hilo.Name = $"Hilo cliente {i}";
				lstThread.Add(hilo);
			}

			lstThread.ForEach(t => t.Start());

		}
	}

	public class CuentaBancaria
	{
		private double saldo;
		private object bloqueaSaldo = new object();

		public CuentaBancaria(double saldo)
		{
			this.saldo = saldo;
		}

		public void SacarDinero(double cantidad)
		{
			lock (bloqueaSaldo)
			{
				if (cantidad > this.saldo)
				{
					Console.WriteLine($"No puede sacarse más dinero. Al cliente {Thread.CurrentThread.Name} le quedan {saldo} en la cuenta");
				}
				else
				{
					this.saldo -= cantidad;
					Console.WriteLine($"El cliente {Thread.CurrentThread.Name} ha sacado {cantidad}. Queda un saldo de {saldo}");
				}
			}
			Thread.Sleep(500);
		}
	}
}
