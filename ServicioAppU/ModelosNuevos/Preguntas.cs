﻿using System;
using System.Collections.Generic;

namespace ServicioAppU.ModelosNuevos
{
    public partial class Preguntas
    {
        public int IdPreguntas { get; set; }
        public int? IdCodigo { get; set; }
        public string Descripcion { get; set; }

        public Codigo IdCodigoNavigation { get; set; }
    }
}
