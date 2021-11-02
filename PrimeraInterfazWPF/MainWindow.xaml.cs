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

namespace PrimeraInterfazWPF
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public int MyProperty
		{
			get { return (int) GetValue(miDepencyProperty); }
			set { SetValue(miDepencyProperty, value); }
		}

		public static readonly DependencyProperty miDepencyProperty = 
			DependencyProperty.Register("MyProperty",typeof(int),typeof(MainWindow),new PropertyMetadata(0));

		public MainWindow()
		{
			InitializeComponent();

			//Grid grid = new Grid();

			////Se asigna a la ventana el grid
			//this.Content = grid;

			//Button boton = new Button();
			//WrapPanel w = new WrapPanel();
			//TextBlock txt1 = new TextBlock();
			//TextBlock txt2 = new TextBlock();
			//TextBlock txt3 = new TextBlock();
			//txt1.Text = "Click";
			//txt1.Foreground = Brushes.Red;
			//txt2.Text = "Otra";
			//txt2.Foreground = Brushes.Green;
			//txt3.Text = "Vez";
			//txt3.Foreground = Brushes.Blue;
			//w.Children.Add(txt1);
			//w.Children.Add(txt2);
			//w.Children.Add(txt3);

			//boton.Content = w;
			//boton.Width = 120;
			//boton.Height = 40;
			//boton.Background = Brushes.AliceBlue;

			////Se añade el botón al grid
			//grid.Children.Add(boton);

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Console.WriteLine("Se ha pulsado el botón 2");
		}

		//private void Panel_Click(object sender, RoutedEventArgs e)
		//{
		//	Console.WriteLine("Se ha pulsado en el panel");
		//}

		private void Panel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Console.WriteLine("Se ha pulsado en el panel");
		}
	}
}
