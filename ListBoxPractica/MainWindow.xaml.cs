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

namespace ListBoxPractica
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			List<Ciudades> lstCiudades = new List<Ciudades>();
			lstCiudades.Add(new Ciudades { NombrePoblacion = "Madrid" });
			lstCiudades.Add(new Ciudades { NombrePoblacion = "París" });
			lstCiudades.Add(new Ciudades { NombrePoblacion = "Berlín" });
			lstCiudades.Add(new Ciudades { NombrePoblacion = "Londres" });
			cmbCapitales.ItemsSource = lstCiudades;
			cmbCapitales.SelectedIndex = 0;

			List<Poblaciones> lstPoblaciones = new List<Poblaciones>();
			lstPoblaciones.Add(new Poblaciones { Poblacion1 = "Madrid", Temperatura1=15, Poblacion2 = "Barcelona", Temperatura2 = 20 });
			lstPoblaciones.Add(new Poblaciones { Poblacion1 = "Mallorca", Temperatura1 = 21, Poblacion2 = "Alicante", Temperatura2 = 19 });
			lstPoblaciones.Add(new Poblaciones { Poblacion1 = "Bilbao", Temperatura1 = 10, Poblacion2 = "Ciudad Real", Temperatura2 = 13 });
			lstPoblaciones.Add(new Poblaciones { Poblacion1 = "Sevilla", Temperatura1 = 22, Poblacion2 = "Málaga", Temperatura2 = 22 });

			lstPoblacionesXAML.ItemsSource = lstPoblaciones;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (lstPoblacionesXAML.SelectedItem != null)
			{
				Poblaciones p = lstPoblacionesXAML.SelectedItem as Poblaciones;
				MessageBox.Show($"{p.Poblacion1} {p.Temperatura1} {p.Poblacion2} {p.Temperatura2}");
			}
		}

		private void lstPoblacionesXAML_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Button_Click(sender, e);
		}

		private void TodasCapitales_Checked(object sender, RoutedEventArgs e)
		{
			CheckBox capitales = (CheckBox)sender;
			bool newVal = (capitales.IsChecked == true);
			chkMadrid.IsChecked = newVal;
			chkBerlin.IsChecked = newVal;
			chkLondres.IsChecked = newVal;
		}

		private void cmbElem_Checked(object sender, RoutedEventArgs e)
		{
			TodasCapitales.IsChecked = null;
			if ((bool)chkMadrid.IsChecked && (bool)chkBerlin.IsChecked && (bool)chkLondres.IsChecked)
			{
				TodasCapitales.IsChecked = true;
			}

			if ((bool)!chkMadrid.IsChecked && (bool)!chkBerlin.IsChecked && (bool)!chkLondres.IsChecked)
			{
				TodasCapitales.IsChecked = false;
			}
		}

	}

	public class Poblaciones
	{
		public string Poblacion1 { get; set; }
		public int Temperatura1 { get; set; }

		public string Poblacion2 { get; set; }
		public int Temperatura2 { get; set; }

		private int diferenciaTemperatura;
		public int DiferenciaTemperatura
		{
			get
			{
				return Math.Abs(Temperatura1 - Temperatura2);
			}
			set
			{
				diferenciaTemperatura = value;
			}
		}
	}
	public class Ciudades
	{
		public string NombrePoblacion { get; set; }
	}
}
