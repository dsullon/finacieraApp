using Financiera.Dominio;
using System.Collections.Generic;

namespace Financiera.Data
{
    public class TipoClienteData
    {
        public List<TipoCliente> Listar()
        {
            var listado = new List<TipoCliente>();
            return listado;
        }

        public TipoCliente BuscarPorId(int id)
        {
            var tipoCliente = new TipoCliente();
            return tipoCliente;
        }

        public bool Insertar()
        {
            return true;
        }


    }
}
