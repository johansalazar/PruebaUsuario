using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProxyServices.Dto
{
    [DataContract]
    public class Usuarios
    {
        [DataMember]
        public int Id_Usuario;

        [DataMember]
        public string Nombre;

        [DataMember]
         public DateTime FechaNacimiento;

        [DataMember]
        public string Sexo;

        [DataMember]
        public string Cod_error;

        [DataMember]
        public string Mensaje;
    }
}
