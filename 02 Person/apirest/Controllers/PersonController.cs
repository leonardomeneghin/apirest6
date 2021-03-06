using apirest.Controllers.Model;
using apirest.Services;
using Microsoft.AspNetCore.Mvc;

namespace apirest.Controllers;

[ApiController]
[Route("api/[controller]")] /*Biding entre [controller] e o nome da classe
                         Note que o Controller ja faz um tratamento para a rota ignorar 'Controller'
no nome da classe.*/
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private IPersonService _personService; //Instancia do servi?o no controller

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_personService.FindAll());

    }
    [HttpGet("{id}")]
    public IActionResult GetAll(long id)
    {
        var person = _personService.FindById(id);
        if (person == null) return NotFound();
        return Ok(person);

    }
    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        if (person == null) return BadRequest();
        return Ok(_personService.Create(person));
    }
    [HttpPut]
    public IActionResult Put([FromBody] Person person)
    {
        if (person == null) return BadRequest();
        return Ok(_personService.Update(person));
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _personService.Delete(id);
        return NoContent();

    }
}
