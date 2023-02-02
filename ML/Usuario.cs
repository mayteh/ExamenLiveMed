using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int Id_usuario { get; set; }
        public string UsuarioN { get; set; }
        public int Id_country { get; set; }
        public List<object> Usuarios { get; set; }
        public ML.Country Country { get; set; }
    }
}
