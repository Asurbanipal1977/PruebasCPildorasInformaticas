﻿using System;
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

namespace WPFLinq
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			AccesoBD.AccesoDatos acceso = new AccesoBD.AccesoDatos();
			//acceso.InsertaEmpresa();
			//acceso.InsertaCargo();
			//acceso.InsertaEmpleadoGoogle("google");
			//acceso.InsertaEmpleadoYahoo("yahoo");
			//acceso.InsertaEmpleadoCargo();

			//acceso.ActualizaEmpleado("Mario","Milano");
			acceso.EliminaEmpleado("Mariano", "Milano");
			DataPrincipal.ItemsSource = acceso.getMyConexion().Empleado;
		}
	}
}
