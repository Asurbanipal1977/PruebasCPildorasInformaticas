using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLinq.AccesoBD
{
	public class AccesoDatos
	{
		private DataClasses1DataContext myConexion;
		//Devolvemos el DataContext
		public AccesoDatos()
		{
			if (myConexion == null)
			{
				myConexion = new DataClasses1DataContext(ConfigurationManager.AppSettings["CadenaConexion"]);
			}
		}

		public void InsertaEmpresa()
		{
			DataClasses1DataContext dataContext= myConexion;
			
			List<Empresa> empresas = new List<Empresa>
			{
				new Empresa { Nombre="Google"},
				new Empresa { Nombre="Yahoo"},
				new Empresa { Nombre="BitCoin"}
			};

			dataContext.Empresa.InsertAllOnSubmit(empresas);
			dataContext.SubmitChanges();
		}

		public void InsertaCargo()
		{
			DataClasses1DataContext dataContext = myConexion;
			List<Cargo> cargos = new List<Cargo>
			{
				new Cargo { NombreCargo="CEO" },
				new Cargo { NombreCargo="Jefe de Proyecto" },
				new Cargo { NombreCargo="Analista"}
			};

			dataContext.Cargo.InsertAllOnSubmit(cargos);
			dataContext.SubmitChanges();
		}

		public void InsertaEmpleadoGoogle(string nomEmpresa)
		{
			DataClasses1DataContext dataContext = myConexion;

			Empresa empresa = dataContext.Empresa.Where(c => c.Nombre.ToUpper() == nomEmpresa.ToUpper()).FirstOrDefault();
			List<Empleado> empleados = new List<Empleado>
			{
				new Empleado { Nombre="Juan", Apellido="Pérez", EmpresaId=empresa.Id},
				new Empleado { Nombre="Luis", Apellido="Sánchez", EmpresaId=empresa.Id}
			};

			dataContext.Empleado.InsertAllOnSubmit(empleados);
			dataContext.SubmitChanges();
		}

		public void InsertaEmpleadoYahoo(string nomEmpresa)
		{
			DataClasses1DataContext dataContext = myConexion;

			Empresa empresa = dataContext.Empresa.Where(c => c.Nombre.ToUpper() == nomEmpresa.ToUpper()).FirstOrDefault();
			List<Empleado> empleados = new List<Empleado>
			{
				new Empleado { Nombre="Mario", Apellido="Milano", EmpresaId=empresa.Id},
				new Empleado { Nombre="Miguel", Apellido="Martínez", EmpresaId=empresa.Id}
			};

			dataContext.Empleado.InsertAllOnSubmit(empleados);
			dataContext.SubmitChanges();
		}


		public void ActualizaEmpleado(string nombre, string apellido)
		{
			DataClasses1DataContext dataContext = myConexion;

			Empleado empleado = dataContext.Empleado.First(c => c.Nombre.ToUpper() == nombre.ToUpper() && c.Apellido.ToUpper() == apellido.ToUpper());
			empleado.Nombre = "Mariano";
			dataContext.SubmitChanges();
		}

		public void EliminaEmpleado(string nombre, string apellido)
		{
			DataClasses1DataContext dataContext = myConexion;


			Empleado empleado = dataContext.Empleado.FirstOrDefault(c => c.Nombre.ToUpper() == nombre.ToUpper() && c.Apellido.ToUpper() == apellido.ToUpper());
			if (empleado != null)
			{
				dataContext.Empleado.DeleteOnSubmit(empleado);
				dataContext.SubmitChanges();
			}
		}

		public void InsertaEmpleadoCargo()
		{
			DataClasses1DataContext dataContext = myConexion;

			List<CargoEmpleado> empleadoCargos = new List<CargoEmpleado>
			{
				new CargoEmpleado { IdCargo=1, IdEmpleado=1},
				new CargoEmpleado { IdCargo=2, IdEmpleado=2},
				new CargoEmpleado { IdCargo=1, IdEmpleado=3},
				new CargoEmpleado { IdCargo=2, IdEmpleado=4},
			};

			dataContext.CargoEmpleado.InsertAllOnSubmit(empleadoCargos);
			dataContext.SubmitChanges();
		}


		public DataClasses1DataContext getMyConexion()
		{
			return myConexion;
		}

	}
}
