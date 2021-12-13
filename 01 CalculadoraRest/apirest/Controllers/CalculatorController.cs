using Microsoft.AspNetCore.Mvc;

namespace apirest.Controllers;

[ApiController]
[Route("[controller]")] /*Biding entre [controller] e o nome da classe
                         Note que o Controller ja faz um tratamento para a rota ignorar 'Controller'
no nome da classe.*/
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Soma(string firstNumber, string secondNumber)
    {
        /*Implementação*/
        if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }
    [HttpGet("sub/{firstNumber}/{secondNumber}")]
    public IActionResult sub(string firstNumber, string secondNumber)
    {
        /*Implementação*/
        if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
        {
            var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(sub.ToString());
        }
        return BadRequest("Invalid Input");
    }
    [HttpGet("mult/{firstNumber}/{secondNumber}")]
    public IActionResult mult(string firstNumber, string secondNumber)
    {
        /*Implementação*/
        if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
        {
            var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(mult.ToString());
        }
        return BadRequest("Invalid Input");
    }
    [HttpGet("div/{firstNumber}/{secondNumber}")]
    public IActionResult div(string firstNumber, string secondNumber)
    {
        /*Implementação*/
        if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
        {
            var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

            return Ok(div.ToString());
        }
        return BadRequest("Invalid Input");
    }
    [HttpGet("med/{firstNumber}/{secondNumber}")]
    public IActionResult med(string firstNumber, string secondNumber)
    {
        /*Implementação*/
        if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
        {
            var media = ConvertToDecimal((firstNumber) + ConvertToDecimal(secondNumber))/2;

            return Ok(media.ToString());
        }
        return BadRequest("Invalid Input");
    }
    [HttpGet("raiz/{firstNumber}")]
    public IActionResult raiz(string firstNumber)
    {
        /*Implementação*/
        if (IsNumeric(firstNumber))
        {
            var sqrd = Math.Sqrt((double)ConvertToDecimal(firstNumber));

            return Ok(sqrd.ToString());
        }
        return BadRequest("Invalid Input");
    }
    /*#############################
      ###########MÉTODOS###########
      #############################*/

    private decimal ConvertToDecimal(string strNumber)
    {
        /*Método 02 - Usado para converter o valor em um número decimal*/
        decimal decimalValue;
        if (decimal.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out decimalValue))
        {

            return decimalValue;
        } else 
        {
        return 0;

        }
    }

    private bool IsNumeric(string strNumber)
    {
        /*Método 01 - Usado para validar se o input é um número*/
        double number;
        /*Tente converter o numero inserido, considerando:
         01 - No sistema global, o estilo de numeros pode ser qualquer um (any => 0.0; 0,0, etc)
         02 - No sistema global, o formato do numero pode ser qualquer um (InvariantInfo => 10^3)
         03 - Jogue a saída para o number associado ao tipo out.
        */
        bool isNumber = double.TryParse(
            strNumber, 
            System.Globalization.NumberStyles.Any, 
            System.Globalization.NumberFormatInfo.InvariantInfo, 
            out number);

        return isNumber;
    }
}
