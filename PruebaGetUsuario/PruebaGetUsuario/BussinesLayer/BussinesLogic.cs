using ProxyServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaGetUsuario.BussinesLayer
{
    public class BussinesLogic
    {
        UsuariosServiceReference.UsuariosServiceClient UsuariosService =  new UsuariosServiceReference.UsuariosServiceClient();

        public Usuarios CreateUsuario(Usuarios usuario)
        {
            Usuarios Resultado = new Usuarios();
            try
            {
                Resultado=UsuariosService.InsertarUsuario(usuario);
            }
            catch (Exception)
            {

                throw;
            }
            return Resultado;
        }

        public Usuarios EditarUsuarios(Usuarios usuario)
        {
            Usuarios Resultado = new Usuarios();
            try
            {
                Resultado = UsuariosService.ModificarUsuario(usuario);
            }
            catch (Exception)
            {

                throw;
            }
            return Resultado;
        }

        public Usuarios EliminarUsuarios(int usuarioId)
        {
            Usuarios Resultado = new Usuarios();
            try
            {
                Resultado = UsuariosService.EliminarUsuario(usuarioId);
            }
            catch (Exception)
            {

                throw;
            }
            return Resultado;
        }

        public List<Usuarios> GetUsuarios()
        {
            List<Usuarios> Resultado = new List<Usuarios>();
            try
            {
                Resultado = UsuariosService.ObtenerUsuarios().ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return Resultado;
        }
    }
}