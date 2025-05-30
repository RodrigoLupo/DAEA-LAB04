﻿using Laboratorio04_Lupo.Models;

namespace Laboratorio04_Lupo.Repositories;

public class PagoRepository : GenericRepository<Pago>, IPagoRepository
{
    private readonly TiendaDbContext _context;
    public PagoRepository(TiendaDbContext context) : base(context)
    {
        _context = context;
    }
}