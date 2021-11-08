using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasLinq
{
	class Program
	{
		static void Main(string[] args)
		{
			//int[] enteros = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

			//List<int> pares = enteros.Where(e => e % 2 == 0).ToList();

			//foreach (int par in pares)
			//{
			//	Console.WriteLine(par);
			//}

			CargarEmpleadosEmpresa cargarEmpleadosEmpresa = new CargarEmpleadosEmpresa();
			cargarEmpleadosEmpresa.getCargo("CEO");
			Console.WriteLine("");
			cargarEmpleadosEmpresa.getEmpleadosOrdenados();
			Console.WriteLine("");
			cargarEmpleadosEmpresa.getEmpleadosEmpresa("google");
			Console.WriteLine("");
		}

		

	}

	class CargarEmpleadosEmpresa
	{
		public List<Empresa> empresas = new List<Empresa>();
		public List<Empleado> empleados = new List<Empleado>();

		public CargarEmpleadosEmpresa()
		{
			empresas = new List<Empresa> {
				new Empresa { Id = 1, Nombre = "Yahoo" },
				new Empresa { Id = 2, Nombre = "Google" }
			};

			empleados = new List<Empleado> {
				new Empleado { Id = 1, Nombre = "Juan Maria Usons", Cargo="CEO", IdEmpresa=1, Salario=22000 },
				new Empleado { Id = 2, Nombre = "Pedro Ruiz", Cargo="Sub-Ceo", IdEmpresa=1, Salario=20000 },
				new Empleado { Id = 3, Nombre = "Luis García", Cargo="CEO", IdEmpresa=2, Salario=24000 },
				new Empleado { Id = 4, Nombre = "Pedro Sanchez", Cargo="Sub-Ceo", IdEmpresa=2, Salario=22000 }
			};
		}

		public void getCargo(string Cargo)
		{
			IEnumerable<Empleado> empleadosCargo = from empleado in empleados where empleado.Cargo.ToUpper() == Cargo.ToUpper() select empleado;

			empleadosCargo.ToList().ForEach(e => Console.WriteLine(e.ToString()));
		}

		public void getEmpleadosOrdenados ()
		{
			IEnumerable<Empleado> empleadosOrd = empleados.OrderBy(e => e.Nombre);

			empleadosOrd.ToList().ForEach(e => Console.WriteLine(e.ToString()));
		}

		public void getEmpleadosEmpresa(string nomEmpresa)
		{
			IEnumerable<Empleado> empleadosEmpresa = from empleado in empleados
													 join empresa in empresas on empleado.IdEmpresa equals empresa.Id
													 where empresa.Nombre.ToUpper() == nomEmpresa.ToUpper()
													 select empleado;
			empleadosEmpresa.ToList().ForEach(e => Console.WriteLine(e.ToString()));
		}
	}


	public class Empresa
	{
		public int Id { get; set; }
		public string Nombre { get; set; }

		public override string ToString()
		{
			return $"Empresa {this.Id} con el nombre {this.Nombre}";
		}
	}

	public class Empleado
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Cargo { get; set; }
		public double Salario { get; set; }

		public int IdEmpresa { get; set; }

		public override string ToString()
		{
			return $"Empleado con {this.Id} con el nombre {this.Nombre}, cargo {this.Cargo} y salario {this.Salario}";
		}

	}
		
}
