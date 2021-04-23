using Crud.CLASSES.DAO;
using Crud.CLASSES.TRANSPORTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.CLASSES.NEGOCIOS
{
    public static class Negocios
    {
        public static int Insere(this Produto produto)
        {
            try
            {
                DaoProduto daoProduto = new DaoProduto();
                return daoProduto.Insere(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Delete(this Produto produto)
        {
            try
            {
                DaoProduto daoProduto = new DaoProduto();
                return daoProduto.Delete(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpDate(this Produto produto)
        {
            try
            {
                DaoProduto daoProduto = new DaoProduto();
                return daoProduto.UpDate(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Produto> ListaProduto()
        {
            try
            {
                DaoProduto daoProduto = new DaoProduto();
                return daoProduto.Lista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
