using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasDelegados
{
	delegate void Delegado(string valor);
	class Program
	{
		static void Main(string[] args)
		{
			Delegado oDelegado = new Delegado(Saludar.Saludo);
			oDelegado("Es un saludo");

			List<Empleado> empleados = new List<Empleado>
			{
				new Empleado{
					Nombre = "Pepe",
					Edad = 25
				},
				new Empleado{
					Nombre = "Luis",
					Edad = 25
				},
				new Empleado{
					Nombre = "Rosa",
					Edad = 30
				}
			};
			
			//Obtener todos los empleados con edad 25 con un predicado
			Predicate<Empleado> predicado = new Predicate<Empleado>(Empleados25);
			List<Empleado> empleados2 = empleados.FindAll(predicado);
			//Expresión Lambda
			empleados2.ForEach(e => Console.WriteLine(e.Nombre));

			Console.WriteLine();
			//Obtener los menores de 30 con lambda
			List<Empleado> empleados3 = empleados.FindAll(e=>e.Edad <= 30);
			empleados3.ForEach(e => Console.WriteLine(e.Nombre));

			Console.ReadLine();
		}

		static bool Empleados25(Empleado empleado)
		{
			return (empleado.Edad == 25);
		}
		
	}

	public static class Saludar
	{
		public static void Saludo(string saludo)
		{
			Console.WriteLine(saludo);
		}
	}

	public class Empleado
	{
		public string Nombre { get; set; }

		public int Edad { get; set; }
	}
}
