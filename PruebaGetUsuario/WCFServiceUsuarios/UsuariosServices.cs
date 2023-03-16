using ProxyServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WCFServiceUsuarios.DataLayer;

namespace WCFServiceUsuarios
{
    public class UsuariosServices : IUsuariosService
    {

        public Usuarios EliminarUsuario(int id)
        {
            Usuarios usuarios = new Usuarios();
            try
            {
                if (id != 0)
                {
                    usuarios.Id_Usuario = id;
                    CLs_Sql cLs_Sql = new CLs_Sql();
                    usuarios = cLs_Sql.DeleteUsuario(usuarios, "Delete");
                    usuarios.Cod_error = "0";
                    usuarios.Mensaje = "Se a eliminado el usuario: " + id;
                }
                else
                {
                    usuarios.Cod_error = "99";
                    usuarios.Mensaje = "El usuario: " + id + " no EXISTE";
                }
            }
            catch (Exception)
            {

                usuarios.Cod_error = "99";
                usuarios.Mensaje = "El Usuario no pudo ser eliminado";
            }
            return usuarios;
        }

        public Usuarios InsertarUsuario(Usuarios usuario)
        {
            Usuarios usuarios = new Usuarios();
            try
            {
                if (usuario != null)
                {
                    if (string.IsNullOrEmpty(usuario.Nombre))
                    {
                        usuarios.Cod_error = "99";
                        usuarios.Mensaje = "El campo: Nombre no debe estar vació";
                    }
                    else if (usuario.FechaNacimiento == null)
                    {
                        usuarios.Cod_error = "99";
                        usuarios.Mensaje = "El campo: FechaNacimiento no debe estar vació";
                    }
                    else if (string.IsNullOrEmpty(usuario.Sexo))
                    {
                        usuarios.Cod_error = "99";
                        usuarios.Mensaje = "El campo: Sexo no debe estar vació";
                    }
                    else
                    {
                        CLs_Sql cLs_Sql = new CLs_Sql();
                        usuarios = cLs_Sql.CuUsuario(usuario, "Create");
                        usuarios.Cod_error = "0";
                        usuarios.Mensaje = "Se a creado el usuario: " + usuario.Nombre;
                    }
                }
                else
                {
                    usuarios.Cod_error = "99";
                    usuarios.Mensaje = "Los valores deben estar llenos";
                }
            }
            catch (Exception)
            {

                usuarios.Cod_error = "99";
                usuarios.Mensaje = "El Usuario no pudo ser creado";
            }
            return usuarios;
        }

        public Usuarios ModificarUsuario(Usuarios usuario)
        {

            Usuarios usuarios = new Usuarios();
            try
            {
                if (usuario != null)
                {
                    CLs_Sql cLs_Sql = new CLs_Sql();
                    usuarios = cLs_Sql.CuUsuario(usuario, "Update");
                    usuarios.Cod_error = "0";
                    usuarios.Mensaje = "Se a editado el usuario: " + usuario.Nombre;
                }
                else
                {
                    usuarios.Cod_error = "99";
                    usuarios.Mensaje = "Los valores deben estar llenos";
                }
            }
            catch (Exception)
            {

                usuarios.Cod_error = "99";
                usuarios.Mensaje = "El Usuario no pudo ser Editado";
            }
            return usuarios;
        }

        public List<Usuarios> ObtenerUsuarios()
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            try
            {
                CLs_Sql cLs_Sql = new CLs_Sql();
                usuarios = cLs_Sql.ObtenerUsuario("Read");
            }
            catch (Exception)
            {

                usuarios[0].Cod_error = "99";
                usuarios[0].Mensaje = "No hay Usuarios";
            }
            return usuarios;
        }
    }
}
