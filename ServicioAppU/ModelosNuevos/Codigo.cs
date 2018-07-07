using System;
using System.Collections.Generic;

namespace ServicioAppU.ModelosNuevos
{
    public partial class Codigo
    {
        public Codigo()
        {
            Preguntas = new HashSet<Preguntas>();
        }

        public int IdCodigo { get; set; }
        public string Identificacion { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Preguntas> Preguntas { get; set; }
    }
}
