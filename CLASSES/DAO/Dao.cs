using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.CLASSES.DAO
{
	public class Dao
	{
		public MySqlConnection conn = new MySqlConnection();
		public MySqlCommand comm = new MySqlCommand();
		public MySqlDataReader dr;
		public bool abrirConexao()
		{
			bool b = false;
			try
			{
				if (conn.State != ConnectionState.Open)
				{
					comm.Connection = conn;
					conn.ConnectionString = "server=" + DadosGerais.ip + ";database=" + DadosGerais.nomeBanco + ";uid=" + DadosGerais.usuario + ";pwd=" + DadosGerais.senha;
					conn.Open();
				}
				b = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return b;
		}
		public bool abrirConexao(string ip, string nomeBanco, string usuario, string senha)
		{
			bool b = false;
			try
			{
				if (conn.State != ConnectionState.Open)
				{
					comm.Connection = conn;
					conn.ConnectionString = "server=" + ip + ";database=" + nomeBanco + ";uid=" + usuario + ";pwd=" + senha;
					conn.Open();
				}
				b = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return b;
		}
		public bool fecharConexao()
		{
			bool b = false;
			try
			{
				if (conn.State != ConnectionState.Closed)
				{
					conn.Close();
				}
				comm.Parameters.Clear();
				b = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return b;
		}
	}
}
