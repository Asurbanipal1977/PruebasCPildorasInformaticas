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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculadoraWPF
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		bool operacionRealizada = false;
		public MainWindow()
		{
			InitializeComponent();
			operacionRealizada = false;
		}

		private void Numero_Click(object sender, RoutedEventArgs e)
		{
			Button botonActual = (Button)sender;
			string numero = botonActual.Content.ToString();

			if (Resultado.Text == "0") Resultado.Text = "";

			if (numero=="." && operacionRealizada) Resultado.Text = "";

			if (Acumulado.Text.IndexOf("+") == Acumulado.Text.Length - 1 || Acumulado.Text.IndexOf("-") == Acumulado.Text.Length - 1
				|| Acumulado.Text.IndexOf("*") == Acumulado.Text.Length - 1 || Acumulado.Text.IndexOf("/") == Acumulado.Text.Length - 1)
			{
				Resultado.Text = "";
			}

			Resultado.Text += numero.ToString();
			Acumulado.Text += numero.ToString();
		}

		private void Limpiar_Click(object sender, RoutedEventArgs e)
		{
			Button botonActual = (Button)sender;
			string numero = botonActual.Content.ToString();

			Resultado.Text = "0";
			Acumulado.Text = "0";
		}

		private void Simbolo_Click(object sender, RoutedEventArgs e)
		{
			operacionRealizada = false;
			if (Resultado.Text.IndexOf("-")==-1)
			{
				Resultado.Text = "-" + Resultado.Text;
				Acumulado.Text = "-" + Acumulado.Text;
			}
			else
			{
				Resultado.Text = Resultado.Text.Replace("-", "");
				Acumulado.Text = Acumulado.Text.Replace("-", "");
			}
		}

		private void Operador_Click(object sender, RoutedEventArgs e)
		{
			operacionRealizada = false;
			Button botonActual = (Button)sender;
			string operador = botonActual.Content.ToString();

			if (Acumulado.Text.IndexOf("+") == Acumulado.Text.Length - 1 || Acumulado.Text.IndexOf("-") == Acumulado.Text.Length - 1
				|| Acumulado.Text.IndexOf("*") == Acumulado.Text.Length - 1 || Acumulado.Text.IndexOf("/") == Acumulado.Text.Length - 1)
			{
				Resultado.Text = "";
				return;				
			}
			else
			{

				if (Acumulado.Text.IndexOf("+") >= 0 || Acumulado.Text.IndexOf("-") >= 0
				|| Acumulado.Text.IndexOf("*") >= 0 || Acumulado.Text.IndexOf("/") >= 0 || Acumulado.Text.IndexOf("=") >= 0)
				{
					Acumulado.Text = Eval(Acumulado.Text.Replace(",",".")).ToString().Replace(",", ".");
					Resultado.Text = Acumulado.Text;
					operacionRealizada = true;
				}
				else
				{
					Resultado.Text = "";
				}
			}

			if (operador != "=")
				Acumulado.Text += operador;
			
		}


		static Double Eval(String expression)
		{
			System.Data.DataTable table = new System.Data.DataTable();
			return Convert.ToDouble(table.Compute(expression, String.Empty));
		}


	}
}
