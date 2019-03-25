using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos
{
    public class AD_Cliente
    {

        public AD_Cliente()
        {


        }

        public int guardar(Cliente pvo_cliente)
        {

            DB_ClientesDataContext vlo_dataContext = new DB_ClientesDataContext();
            // variable necesaria para pasar por referencia el valor del id del cliente
            int idCliente = pvo_cliente.Id; 

            try
            {
                vlo_dataContext.SP_GUARDAR_CLIENTE(ref idCliente,
                                                    pvo_cliente.Nombre,
                                                    pvo_cliente.Telefono);

            }
            catch (Exception)
            {

                throw;
            }

            return idCliente;

        }

        public string eliminar(int pvn_idCliente)
        {

            DB_ClientesDataContext vlo_dataContext = new DB_ClientesDataContext();
            string vlc_mensaje = null; // variable para obtener el mensaje del procedimiento almacenado

            try
            {

                vlo_dataContext.SP_ELIMINAR_CLIENTE(pvn_idCliente, ref vlc_mensaje);

            }
            catch (Exception)
            {

                throw;
            }

            return vlc_mensaje;
        }


        public Cliente obtenerRegistro(int pvn_idCliente)
        {

            DB_ClientesDataContext vlo_dataContext = new DB_ClientesDataContext();
            Cliente vlo_cliente = new Cliente();

            try
            {

                var consulta = from /*CUALQUIER NOMBRE*/ cliente in vlo_dataContext.CLIENTE
                               where cliente.ID == pvn_idCliente
                               select cliente; // equivalente a decir "select * from cliente 
                                                       // where id = @id"

                // ciclo para obtener los datos del cliente
                foreach (var item in consulta)
                {
                    vlo_cliente.Id = item.ID;
                    vlo_cliente.Nombre = item.NOMBRE;
                    vlo_cliente.Telefono = item.TELEFONO;
                }
            }
            catch (Exception)
            {

                throw;
            }


            return vlo_cliente;

        }

        // cuando se listan los registros siempre es necesario que retorne un objeto
        public object listaRegistros(string pvc_nombreCliente)
        {

            DB_ClientesDataContext vlo_dataContext = new DB_ClientesDataContext();

            try
            {
                // verificando si se especifico el nombre del cliente
                if (pvc_nombreCliente != null)
                {

                    var consulta = from /*CUALQUIER NOMBRE*/ cliente in vlo_dataContext.CLIENTE
                                   where cliente.NOMBRE.Contains(pvc_nombreCliente) // indicando que muestre los registros que tienen un nombre como el del parametro
                                   orderby cliente.ID // ordenandolos por id
                                   select cliente;

                    return consulta;

                }
                else
                {

                    var consulta = from cliente in vlo_dataContext.CLIENTE
                                   orderby cliente.ID // ordenandolos por id
                                   select cliente;

                    return consulta;

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
