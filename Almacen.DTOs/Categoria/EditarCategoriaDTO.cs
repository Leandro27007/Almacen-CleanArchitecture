﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.DTOs.Categoria
{
    public class EditarCategoriaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
