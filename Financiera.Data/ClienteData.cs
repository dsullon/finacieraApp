using Financiera.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Financiera.Data
{
    public class ClienteData
    {
        string cadenaConexion = "server=localhost; Database=Financiera; Integrated Security = true";
        public List<Cliente> Listar()
        {
            var listado = new List<Cliente>();
            using(var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using(var comando = new SqlCommand("Select * From Cliente", conexion))
                {
                    using(var lector = comando.ExecuteReader())
                    {
                        if(lector != null && lector.HasRows)
                        {
                            Cliente cliente;
                            while (lector.Read())
                            {
                                cliente = new Cliente();
                                cliente.ID = int.Parse(lector[0].ToString());
                                cliente.Nombres = lector[1].ToString();
                                cliente.Apellidos = lector[2].ToString();
                                cliente.Direccion = lector[3].ToString();
                                cliente.Referencia = lector[4].ToString();
                                cliente.IdTipoCliente = int.Parse(lector[5].ToString());
                                cliente.IdTipoDocumento = int.Parse(lector[6].ToString());
                                cliente.NumeroDocumento = lector[7].ToString();

                                listado.Add(cliente);
                            }
                        }
                    }
                }
            }
            return listado;
        }

        public Cliente BuscarPorId(int id)
        {
            var cliente = new Cliente();
            return cliente;
        }

        public bool Insertar(Cliente cliente)
        {
            return true;
        }

        public bool Actualizar(Cliente cliente)
        {
            return true;
        }

        public bool Eliminar(Cliente cliente)
        {
            return true;
        }
    }
}
