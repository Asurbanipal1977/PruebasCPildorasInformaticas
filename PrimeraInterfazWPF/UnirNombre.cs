using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraInterfazWPF
{
	public class UnirNombre: INotifyPropertyChanged
	{
		private string NombreVal, ApellidoVal;
		public string Nombre
		{
			get
			{
				return NombreVal;
			}
			set
			{
				NombreVal = value;
				NotifyPropertyChanged("NombreCompleto");
			}
		}
		public string Apellido {
			get
			{
				return ApellidoVal;
			}
			set
			{
				ApellidoVal = value;
				NotifyPropertyChanged("NombreCompleto");
			}
		}
		public string NombreCompleto
		{
			get
			{
				return $"{Nombre} {Apellido}";
			}
			set
			{
				Nombre = value.Split(' ')[0];
				NotifyPropertyChanged("Nombre");

				if (value.Split(' ').Length > 0)
				{
					Apellido = value.Split(' ')[1];
					NotifyPropertyChanged("Apellido");
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
