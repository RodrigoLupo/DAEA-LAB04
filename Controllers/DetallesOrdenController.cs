using Laboratorio04_Lupo.Models;
using Laboratorio04_Lupo.Repositories.Unit;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio04_Lupo.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DetallesOrdenController: ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public DetallesOrdenController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var detalles = await _unitOfWork.DetallesOrdenes.GetAll();
        return Ok(detalles);
    }

    [HttpPost]
    public async Task<IActionResult> CrearDetalle(DetallesOrden detalle)
    {
        await _unitOfWork.DetallesOrdenes.Add(detalle);
        await _unitOfWork.SaveChangesAsync();
        return Ok("Detalle de orden creado con éxito");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarDetalle(int id, DetallesOrden detalleActualizado)
    {
        var detalleExistente = await _unitOfWork.DetallesOrdenes.GetById(id);
        if (detalleExistente == null)
            return NotFound("Detalle no encontrado");

        detalleExistente.ProductoId = detalleActualizado.ProductoId;
        detalleExistente.OrdenId = detalleActualizado.OrdenId;
        detalleExistente.Cantidad = detalleActualizado.Cantidad;

        await _unitOfWork.DetallesOrdenes.Update(detalleExistente);
        await _unitOfWork.SaveChangesAsync();

        return Ok("Detalle de orden actualizado con éxito");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarDetalle(int id)
    {
        await _unitOfWork.DetallesOrdenes.Delete(id);
        await _unitOfWork.SaveChangesAsync();
        return Ok("Detalle de orden eliminado con éxito");
    }
}