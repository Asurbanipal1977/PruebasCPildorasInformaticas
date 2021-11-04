using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionPedidosWPF
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private SqlConnection myConexion()
		{
			return new SqlConnection(ConfigurationManager.AppSettings["CadenaConexion"]);
		}

		private void MuestraClientes()
		{
			string consulta = "SELECT * FROM cliente";
			//using (SqlConnection oConexion = myConexion())
			//{			
			//	SqlDataAdapter sqlData = new SqlDataAdapter(consulta, oConexion);

			//	using (sqlData)
			//	{
			//		DataTable clientes = new DataTable();
			//		sqlData.Fill(clientes);
			//		ListaClientes.DisplayMemberPath = "nombre";
			//		ListaClientes.SelectedValuePath = "Id";
			//		ListaClientes.ItemsSource = clientes.DefaultView;
			//	}
			//}

			using (SqlConnection oConexion = myConexion())
			{
				oConexion.Open();
				SqlCommand sqlData = new SqlCommand(consulta, oConexion);

				using (sqlData)
				{
					DataTable clientes = new DataTable();
					clientes.Load(sqlData.ExecuteReader());
					
					ListaClientes.DisplayMemberPath = "nombre";
					ListaClientes.SelectedValuePath = "Id";
					ListaClientes.ItemsSource = clientes.DefaultView;
				}
			}
		}


		public MainWindow()
		{
			InitializeComponent();
			MuestraClientes();
		}
	}
}
