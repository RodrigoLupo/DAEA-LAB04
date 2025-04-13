using Laboratorio04_Lupo.Models;
using Laboratorio04_Lupo.Repositories.Unit;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio04_Lupo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoriaController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categorias = await _unitOfWork.Categorias.GetAll();
        return Ok(categorias);
    }

    [HttpPost]
    public async Task<IActionResult> CrearCategoria(Categoria categoria)
    {
        await _unitOfWork.Categorias.Add(categoria);
        await _unitOfWork.SaveChangesAsync();
        return Ok("Categoría creada con éxito");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarCategoria(int id, Categoria categoriaActualizada)
    {
        var categoriaExistente = await _unitOfWork.Categorias.GetById(id);
        if (categoriaExistente == null)
            return NotFound("Categoría no encontrada");

        categoriaExistente.Nombre = categoriaActualizada.Nombre;

        await _unitOfWork.Categorias.Update(categoriaExistente);
        await _unitOfWork.SaveChangesAsync();

        return Ok("Categoría actualizada con éxito");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarCategoria(int id)
    {
        await _unitOfWork.Categorias.Delete(id);
        await _unitOfWork.SaveChangesAsync();
        return Ok("Categoría eliminada con éxito");
    }
}
