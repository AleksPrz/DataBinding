using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar
{
    public class PersonaModel
    {
        public string nombre { set; get; }
        public string apellido { set; get; }
        public string fh_nac { set; get; }
        public string sexo { set; get; }
        public int id_rol { set; get; }

        public PersonaModel() { }
        
        public PersonaModel(string nombre, string apellido, string fh_nac, string sexo, int id_rol) {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fh_nac = fh_nac;
            this.sexo = sexo;
            this.id_rol = id_rol;
        }
        
    }
}
