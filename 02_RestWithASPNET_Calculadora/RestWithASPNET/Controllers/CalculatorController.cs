using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
   

    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Sum(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            

            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }
    [HttpGet("sub/{firstNumber}/{secondNumber}")]
    public IActionResult Subtraction(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);


            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }
    [HttpGet("mult/{firstNumber}/{secondNumber}")]
    public IActionResult Mult(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);


            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("div/{firstNumber}/{secondNumber}")]
    public IActionResult Div(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);


            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("media/{firstNumber}/{secondNumber}")]
    public IActionResult Media(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ((ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2);

            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }
    [HttpGet("raiz/{firstNumber}/{secondNumber}")]
    public IActionResult Raiz(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = Math.Sqrt(ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber));


            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }


    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(
            strNumber,
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo,
            out number);

        return isNumber;
    }

    private int ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;
        if(decimal.TryParse(strNumber, out decimalValue))
        {
            return (int)decimalValue;
        }
        return 0;
    }
    
}
