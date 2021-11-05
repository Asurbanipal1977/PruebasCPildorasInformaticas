using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace GestionPedidosWPF.AccesoBD
{
	public class AccesoDatos
	{
		private SqlConnection myConexion()
		{
			return new SqlConnection(ConfigurationManager.AppSettings["CadenaConexion"]);
		}

		public DataTable MuestraClientes()
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
					return clientes;					
				}
			}
		}

		public Cliente MuestraCliente(int idCliente)
		{
			string consulta = "SELECT * FROM cliente where id=@idCliente";
			Cliente cliente = null;

			using (var oConexion = myConexion())
			{
				oConexion.Open();
				var sqlData = new SqlCommand(consulta, oConexion);
				sqlData.Parameters.Add("@idCliente", SqlDbType.Int);
				sqlData.Parameters["@idCliente"].Value = idCliente;

				using (sqlData)
				{
					var sqlDataReader = sqlData.ExecuteReader();
					var parser = sqlDataReader.GetRowParser<Cliente>(typeof(Cliente));
					while (sqlDataReader.Read())
					{
						cliente = parser(sqlDataReader);
					}

				}
			}

			return cliente;
		}

		public DataTable MuestraPedidos(int CodCliente)
		{
			string consulta = $"SELECT * FROM pedido where codCliente=@CodCliente";
			using (SqlConnection oConexion = myConexion())
			{
				oConexion.Open();
				SqlCommand sqlData = new SqlCommand(consulta, oConexion);
				sqlData.Parameters.Add("@CodCliente", SqlDbType.Int);
				sqlData.Parameters["@CodCliente"].Value = CodCliente;

				using (sqlData)
				{
					DataTable pedidos = new DataTable();
					pedidos.Load(sqlData.ExecuteReader());
					return pedidos;

					
				}
			}
		}

		public string EliminarPedido(int IdPedido)
		{
			string consulta = $"DELETE FROM pedido where id=@IdPedido";
			using (SqlConnection oConexion = myConexion())
			{
				oConexion.Open();
				SqlCommand sqlData = new SqlCommand(consulta, oConexion);
				sqlData.Parameters.Add("@IdPedido", SqlDbType.Int);
				sqlData.Parameters["@IdPedido"].Value = IdPedido;

				using (sqlData)
				{
					if (sqlData.ExecuteNonQuery() > 0)
					{
						 return "Elemento eliminado";
					}
					else
					{
						return "Error al eliminar";
					}
				}
			}
		}


		public string InsertarCliente(string txtNombreCliente)
		{
			string consulta = $"INSERT INTO Cliente (nombre) values (@NombreCliente)";

			if (!string.IsNullOrWhiteSpace(txtNombreCliente))
			{
				using (SqlConnection oConexion = myConexion())
				{
					oConexion.Open();
					SqlCommand sqlData = new SqlCommand(consulta, oConexion);
					sqlData.Parameters.Add("@NombreCliente", SqlDbType.VarChar);
					sqlData.Parameters["@NombreCliente"].Value = txtNombreCliente;

					using (sqlData)
					{
						if (sqlData.ExecuteNonQuery() > 0)
						{
							return "Elemento insertado";
						}
						else
						{
							return "Error al insertar";
						}
					}
				}
			}
			return "No se puede insertar";
		}

		public string ModificarCliente(int id, string txtNombreCliente)
		{
			string consulta = $"UPDATE Cliente SET nombre=@txtNombreCliente WHERE Id=@id";

			if (!string.IsNullOrWhiteSpace(txtNombreCliente) && id!=0)
			{
				using (SqlConnection oConexion = myConexion())
				{
					oConexion.Open();
					SqlCommand sqlData = new SqlCommand(consulta, oConexion);
					sqlData.Parameters.Add("@id", SqlDbType.Int);
					sqlData.Parameters.Add("@txtNombreCliente", SqlDbType.VarChar);
					sqlData.Parameters["@id"].Value = id;
					sqlData.Parameters["@txtNombreCliente"].Value = txtNombreCliente;


					using (sqlData)
					{
						if (sqlData.ExecuteNonQuery() > 0)
						{
							return "Elemento modificado";
						}
						else
						{
							return "Error al modificar";
						}
					}
				}
			}
			return "No se puede modificar";
		}

		public string EliminarCliente(int IdCliente)
		{
			string consulta = $"DELETE FROM cliente where id=@IdCliente";
			using (SqlConnection oConexion = myConexion())
			{
				oConexion.Open();
				SqlCommand sqlData = new SqlCommand(consulta, oConexion);
				sqlData.Parameters.Add("@IdCliente", SqlDbType.Int);
				sqlData.Parameters["@IdCliente"].Value = IdCliente;

				using (sqlData)
				{
					if (sqlData.ExecuteNonQuery() > 0)
					{
						 return "Elemento eliminado";
					}
					else
					{
						return "Error al eliminar";
					}
				}
			}
		}

		public DataTable MuestraTodosPedidos()
		{
			string consulta = $"SELECT *, CONCAT(codCliente,' ',fechaPedido,' ',formaPago) as cadenaPedido FROM pedido";
			using (SqlConnection oConexion = myConexion())
			{
				oConexion.Open();
				SqlCommand sqlData = new SqlCommand(consulta, oConexion);

				using (sqlData)
				{
					DataTable pedidos = new DataTable();
					pedidos.Load(sqlData.ExecuteReader());
					return pedidos;
				}
			}
		}
	}
}
