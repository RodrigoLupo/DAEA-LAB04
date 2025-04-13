using Laboratorio04_Lupo.Models;
using Laboratorio04_Lupo.Repositories.Unit;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio04_Lupo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdenController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdenController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var ordenes = await _unitOfWork.Ordenes.GetAll();
        return Ok(ordenes);
    }

    [HttpPost]
    public async Task<IActionResult> CrearOrden(Ordene orden)
    {
        await _unitOfWork.Ordenes.Add(orden);
        await _unitOfWork.SaveChangesAsync();
        return Ok("Orden creada con éxito");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarOrden(int id, Ordene ordenActualizada)
    {
        var ordenExistente = await _unitOfWork.Ordenes.GetById(id);
        if (ordenExistente == null)
            return NotFound("Orden no encontrada");

        ordenExistente.ClienteId = ordenActualizada.ClienteId;

        await _unitOfWork.Ordenes.Update(ordenExistente);
        await _unitOfWork.SaveChangesAsync();

        return Ok("Orden actualizada con éxito");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarOrden(int id)
    {
        await _unitOfWork.Ordenes.Delete(id);
        await _unitOfWork.SaveChangesAsync();
        return Ok("Orden eliminada con éxito");
    }
}
