using Laboratorio04_Lupo.Models;
using Laboratorio04_Lupo.Repositories.Unit;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio04_Lupo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PagoController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public PagoController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pagos = await _unitOfWork.Pagos.GetAll();
        return Ok(pagos);
    }

    [HttpPost]
    public async Task<IActionResult> CrearPago(Pago pago)
    {
        await _unitOfWork.Pagos.Add(pago);
        await _unitOfWork.SaveChangesAsync();
        return Ok("Pago creado con éxito");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarPago(int id, Pago pagoActualizado)
    {
        var pagoExistente = await _unitOfWork.Pagos.GetById(id);
        if (pagoExistente == null)
            return NotFound("Pago no encontrado");

        pagoExistente.Monto = pagoActualizado.Monto;
        pagoExistente.OrdenId = pagoActualizado.OrdenId;

        await _unitOfWork.Pagos.Update(pagoExistente);
        await _unitOfWork.SaveChangesAsync();

        return Ok("Pago actualizado con éxito");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarPago(int id)
    {
        await _unitOfWork.Pagos.Delete(id);
        await _unitOfWork.SaveChangesAsync();
        return Ok("Pago eliminado con éxito");
    }
}
