using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AccesoDatos;

namespace Logica
{
    public class LogicaCliente
    {

        public LogicaCliente()
        {


        }

        public int guardar(Cliente pvo_cliente)
        {
            AD_Cliente aD_Clientes = new AD_Cliente();
            int idCliente = -1;

            try
            {
                idCliente = aD_Clientes.guardar(pvo_cliente);

            }
            catch (Exception)
            {

                throw;
            }

            return idCliente;

        }

        public string eliminar(int pvn_idCliente)
        {

            string vlc_mensaje = null;
            AD_Cliente aD_Cliente = new AD_Cliente();

            try
            {
                vlc_mensaje = aD_Cliente.eliminar(pvn_idCliente);

            }
            catch (Exception)
            {

                throw;
            }

            return vlc_mensaje;

        }

        public Cliente obtenerRegistro(int pvn_idCliente)
        {

            Cliente vlo_cliente;
            AD_Cliente aD_Cliente = new AD_Cliente();

            try
            {
                vlo_cliente = aD_Cliente.obtenerRegistro(pvn_idCliente);
            }
            catch (Exception)
            {

                throw;
            }

            return vlo_cliente;

        }

        public object listaRegistros(string pvc_nombreCliente = null) // indicando que el paramentro puede ser nulo
        {

            AD_Cliente aD_Cliente = new AD_Cliente();
            object consulta = null; // objeto que va a tener la lista de registros

            try
            {
                consulta = aD_Cliente.listaRegistros(pvc_nombreCliente);

            }
            catch (Exception)
            {

                throw;
            }

            return consulta;
        }

    }
}
