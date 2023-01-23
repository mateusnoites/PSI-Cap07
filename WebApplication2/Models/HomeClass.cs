using Modelo.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class HomeClass
    {
        public IQueryable<Produto> listaprodutoLançamentos;
        public IQueryable<Produto> listaprodutoDestaque;
    }
}