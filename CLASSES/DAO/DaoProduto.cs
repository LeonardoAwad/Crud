using Crud.CLASSES.TRANSPORTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.CLASSES.DAO
{
	public class DaoProduto: Dao
	{
		#region"MembrosPrivados"
		public DaoProduto()
		{
			// TODO: Logica do construtor
		}
		#endregion
		#region"MetodosPublicos"
		public int Insere(Produto produto)
		{
			try
			{
				int cod = -1;
				if (abrirConexao())
				{
					comm.CommandText = @"INSERT INTO PRODUTOS
(
NOME,
PRECO
)
VALUES
(
@NOME,
@PRECO
); SELECT @@IDENTITY;";
					comm.Parameters.AddWithValue("@NOME", produto.Nome);
					comm.Parameters.AddWithValue("@PRECO", produto.Preco);
					cod = Convert.ToInt32(comm.ExecuteScalar());
				}
				return cod;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				fecharConexao();
			}
		}

		public bool Delete(Produto produto)
		{
			try
			{
				bool b = false;
				if (abrirConexao())
				{
					comm.CommandText = @"DELETE FROM PRODUTOS
WHERE ID = @ID;";
					comm.Parameters.AddWithValue("@ID", produto.Id);
					comm.ExecuteNonQuery();
					b = true;
				}
				return b;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				fecharConexao();
			}
		}

		public bool UpDate(Produto produto)
		{
			try
			{
				bool b = false;
				if (abrirConexao())
				{
					comm.CommandText = @"UPDATE PRODUTOS
SET
NOME = @NOME,
PRECO = @PRECO
WHERE ID = @ID;";
					comm.Parameters.AddWithValue("@ID", (produto.Id == -1 ? (object)null : produto.Id));
					comm.Parameters.AddWithValue("@NOME", produto.Nome);
					comm.Parameters.AddWithValue("@PRECO", produto.Preco);
					comm.ExecuteNonQuery();
					b = true;
				}
				return b;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				fecharConexao();
			}
		}

		public bool Carrega(ref Produto produto, int id)
		{
			try
			{
				bool b = false;
				if (abrirConexao())
				{
					comm.CommandText = @"SELECT 
ID,
NOME,
PRECO
FROM PRODUTOS
WHERE ID = @ID;";
					comm.Parameters.AddWithValue("@ID", id);
					dr = comm.ExecuteReader();
					if (dr.Read())
					{
						if (produto == null)
							produto = new Produto();
						int col = dr.GetOrdinal("ID");
						produto.Id = dr.IsDBNull(col) == true ? -1 : dr.GetInt32(col);
						produto.Nome = dr.GetString("NOME");
						produto.Preco = dr.GetDouble("PRECO");

						b = true;
					}
				}
				return b;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				fecharConexao();
			}
		}

		public List<Produto> Lista()
		{
			try
			{
				List<Produto> listaProduto = new List<Produto>();
				if (abrirConexao())
				{
					comm.CommandText = @"SELECT 
ID,
NOME,
PRECO
FROM PRODUTOS;";
					dr = comm.ExecuteReader();
					while (dr.Read())
					{
						Produto produto = new Produto();
						int col = dr.GetOrdinal("ID");
						produto.Id = dr.IsDBNull(col) == true ? -1 : dr.GetInt32(col);
						produto.Nome = dr.GetString("NOME");
						produto.Preco = dr.GetDouble("PRECO");
						
						listaProduto.Add(produto);
					}
				}
				return listaProduto;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				fecharConexao();
			}
		}
		#endregion
	}
}
