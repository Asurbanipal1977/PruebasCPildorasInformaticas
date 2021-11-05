using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
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
using Dapper;
using GestionPedidosWPF.AccesoBD;

namespace GestionPedidosWPF
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		AccesoDatos accesoDatos = new AccesoDatos();


		public MainWindow()
		{
			InitializeComponent();
			ListaClientes.DisplayMemberPath = "nombre";
			ListaClientes.SelectedValuePath = "Id";
			ListaClientes.ItemsSource = accesoDatos.MuestraClientes().DefaultView;

			ListaTodosPedidos.DisplayMemberPath = "cadenaPedido";
			ListaTodosPedidos.SelectedValuePath = "Id";
			ListaTodosPedidos.ItemsSource = accesoDatos.MuestraTodosPedidos().DefaultView;
		}

		private void ListaClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ListBox lstClientes = (ListBox)sender;
			if (lstClientes.SelectedValue != null)
			{
				ListaPedidos.DisplayMemberPath = "fechaPedido";
				ListaPedidos.SelectedValuePath = "Id";
				ListaPedidos.ItemsSource = accesoDatos.MuestraPedidos(int.Parse(lstClientes.SelectedValue.ToString())).DefaultView;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show(accesoDatos.EliminarPedido(int.Parse(ListaTodosPedidos.SelectedValue.ToString())));
			ListaTodosPedidos.DisplayMemberPath = "cadenaPedido";
			ListaTodosPedidos.SelectedValuePath = "Id";
			ListaTodosPedidos.ItemsSource = accesoDatos.MuestraTodosPedidos().DefaultView;
		}

		private void btnInsertarCliente_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show(accesoDatos.InsertarCliente(txtNombreCliente.Text));
			ListaClientes.DisplayMemberPath = "nombre";
			ListaClientes.SelectedValuePath = "Id";
			ListaClientes.ItemsSource = accesoDatos.MuestraClientes().DefaultView;
		}

		private void btnEliminarCliente_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show(accesoDatos.EliminarCliente(int.Parse(ListaClientes.SelectedValue.ToString())));
			ListaClientes.DisplayMemberPath = "nombre";
			ListaClientes.SelectedValuePath = "Id";
			ListaClientes.ItemsSource = accesoDatos.MuestraClientes().DefaultView;
		}

		private void btnModificarCliente_Click(object sender, RoutedEventArgs e)
		{
			if (ListaClientes.SelectedValue != null)
			{
				int ClienteSel = int.Parse(ListaClientes.SelectedValue.ToString());
				ModificarCliente mc = new ModificarCliente(ClienteSel);				

				mc.VentanaNombreCliente.Text = accesoDatos.MuestraCliente(ClienteSel).nombre;

				mc.ShowDialog();

				ListaClientes.DisplayMemberPath = "nombre";
				ListaClientes.SelectedValuePath = "Id";
				ListaClientes.ItemsSource = accesoDatos.MuestraClientes().DefaultView;
			}
		}
	}

	public class Cliente
	{
		public int Id { get; set; }
		public string nombre { get; set; }
		public string direccion { get; set; }
		public string poblacion { get; set; }
		public string telefono { get; set; }
	}

}
