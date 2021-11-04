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

namespace RadioButtonPractica
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Color_Click(object sender, RoutedEventArgs e)
		{
			RadioButton r = (RadioButton)sender;
			string color = ((TextBlock)r.Content).Text;

			eRojo.Visibility = Visibility.Hidden;
			eAmarillo.Visibility = Visibility.Hidden;
			eVerde.Visibility = Visibility.Hidden;

			if (color.Contains("Rojo"))
			{
				eRojo.Visibility = Visibility.Visible;
			}
			else if(color.Contains("Amarillo"))
			{
				eAmarillo.Visibility = Visibility.Visible;
			}
			else if (color.Contains("Verde"))
			{
				eVerde.Visibility = Visibility.Visible;
			}

		}
	}
}
