using Microsoft.AspNetCore.Mvc;
using ClockAngle.Services;

namespace ClockAngle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClockAngleController : ControllerBase
    {
        private readonly ClockAngleCalculator _calculator;

        public ClockAngleController(ClockAngleCalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet]
        public IActionResult CalculateTimeAngle([FromQuery] string? time, [FromQuery] int? hour, [FromQuery] int? minute)
        {
            try
            {
                int h, m;

                if (!string.IsNullOrEmpty(time))
                {
                    var parts = time.Split(':');
                    if (parts.Length != 2 || !int.TryParse(parts[0], out h) || !int.TryParse(parts[1], out m))
                        return BadRequest("Invalid time format. Use HH:mm");
                }
                else if (hour.HasValue && minute.HasValue)
                {
                    h = hour.Value;
                    m = minute.Value;
                }
                else
                {
                    return BadRequest("Provide either 'time' parameter or both 'hour' and 'minute' parameters");
                }

                var result = _calculator.Calculate(h, m);
                return Ok(new { totalAngle = result });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
