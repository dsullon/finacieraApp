using Financiera.Data;
using Financiera.Dominio;
using System.Collections.Generic;

namespace Financiera.Logic
{
    public static class ClienteBL
    {
        public static List<Cliente> Listar()
        {
            var clienteData = new ClienteData();
            return clienteData.Listar();
        }
    }
}
