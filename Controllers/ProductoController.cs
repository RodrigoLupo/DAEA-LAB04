using Laboratorio04_Lupo.Models;
using Laboratorio04_Lupo.Repositories.Unit;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio04_Lupo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductoController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductoController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productos = await _unitOfWork.Productos.GetAll();
        return Ok(productos);
    }

    [HttpPost]
    public async Task<IActionResult> CrearProducto(Producto producto)
    {
        await _unitOfWork.Productos.Add(producto);
        await _unitOfWork.SaveChangesAsync();
        return Ok("Producto creado con éxito");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarProducto(int id, Producto productoActualizado)
    {
        var productoExistente = await _unitOfWork.Productos.GetById(id);

        if (productoExistente == null)
            return NotFound("Producto no encontrado");

        productoExistente.Nombre = productoActualizado.Nombre;
        productoExistente.Precio = productoActualizado.Precio;
        productoExistente.CategoriaId = productoActualizado.CategoriaId;
        // Agrega los demás campos que correspondan

        await _unitOfWork.Productos.Update(productoExistente);
        await _unitOfWork.SaveChangesAsync();

        return Ok("Producto actualizado con éxito");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarProducto(int id)
    {
        await _unitOfWork.Productos.Delete(id);
        await _unitOfWork.SaveChangesAsync();

        return Ok("Producto eliminado con éxito");
    }
}
