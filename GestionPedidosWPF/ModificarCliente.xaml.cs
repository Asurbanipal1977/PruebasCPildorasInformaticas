using GestionPedidosWPF.AccesoBD;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace GestionPedidosWPF
{
	/// <summary>
	/// Lógica de interacción para ModificarCliente.xaml
	/// </summary>
	public partial class ModificarCliente : Window
	{
		private AccesoDatos accesoDatos = new AccesoDatos();

		private int ClienteSel;

		public ModificarCliente(int ClienteSel)
		{
			InitializeComponent();
			this.ClienteSel = ClienteSel;
		}

		private void Modificar_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show(accesoDatos.ModificarCliente(this.ClienteSel, VentanaNombreCliente.Text));
			this.Close();
		}
	}
}
