using Microsoft.AspNetCore.Mvc;

namespace apirest.Controllers;

[ApiController]
[Route("[controller]")] /*Biding entre [controller] e o nome da classe
                         Note que o Controller ja faz um tratamento para a rota ignorar 'Controller'
no nome da classe.*/
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Get(string firstNumber, string secondNumber)
    {

    }
}
