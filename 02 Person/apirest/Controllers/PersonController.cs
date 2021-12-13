using apirest.Controllers.Model;
using apirest.Services;
using Microsoft.AspNetCore.Mvc;

namespace apirest.Controllers;

[ApiController]
[Route("[controller]")] /*Biding entre [controller] e o nome da classe
                         Note que o Controller ja faz um tratamento para a rota ignorar 'Controller'
no nome da classe.*/
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private IPersonService _personService; //Instancia do serviço no controller

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet()]
    public IActionResult Get()
    {
        return Ok(_personService.FindAll());
        
    }
    [HttpGet()]
    public IActionResult Get()
    {
        return Ok(_personService.FindAll());

    }
}
