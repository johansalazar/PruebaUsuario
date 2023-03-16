using ProxyServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceUsuarios
{
    [ServiceContract]
    public interface IUsuariosService
    {
        [OperationContract]
        List<Usuarios> ObtenerUsuarios();

        [OperationContract]
        Usuarios InsertarUsuario(Usuarios usuario);

        [OperationContract]
        Usuarios ModificarUsuario(Usuarios usuario);

        [OperationContract]
        Usuarios EliminarUsuario(int id);
    }
}
