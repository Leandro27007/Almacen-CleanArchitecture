﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.CasosDeUsoPorts.OutputPorts.Producto
{
    public interface IEliminarProductoOutputPort
    {
        Task EliminarProductoHandle(bool productoEliminado);
    }
}