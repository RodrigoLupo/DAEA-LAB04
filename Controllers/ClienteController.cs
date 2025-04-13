using Laboratorio04_Lupo.Models;
using Laboratorio04_Lupo.Repositories.Unit;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio04_Lupo.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClienteController:ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    
    public ClienteController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clientes = await _unitOfWork.Clientes.GetAll();

        return Ok(clientes);
    }
    [HttpPost]
    public async Task<IActionResult> CrearCliente(Cliente cliente)
    {
        await _unitOfWork.Clientes.Add(cliente);
        await _unitOfWork.SaveChangesAsync();
        return Ok("Cliente creado con exito");
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarCliente(int id, Cliente clienteActualizado)
    {
        var clienteExistente = await _unitOfWork.Clientes.GetById(id);

        if (clienteExistente == null)
            return NotFound("Cliente no encontrado");

        clienteExistente.Nombre = clienteActualizado.Nombre;
        clienteExistente.Correo = clienteActualizado.Correo;

        await _unitOfWork.Clientes.Update(clienteExistente);
        await _unitOfWork.SaveChangesAsync();

        return Ok("Cliente actualizado con éxito");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarCliente(int id)
    {
        await _unitOfWork.Clientes.Delete(id);
        await _unitOfWork.SaveChangesAsync();

        return Ok("Cliente eliminado con éxito");
    }
    
}