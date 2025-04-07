﻿using System;
using System.Collections.Generic;

namespace Laboratorio04_Lupo.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Ordene> Ordenes { get; set; } = new List<Ordene>();
}
