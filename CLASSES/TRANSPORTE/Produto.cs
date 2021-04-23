using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.CLASSES.TRANSPORTE
{
    public class Produto
    {
        private int _id;
        private string _nome;
        private double _preco;

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public double Preco { get => _preco; set => _preco = value; }
    }
}
