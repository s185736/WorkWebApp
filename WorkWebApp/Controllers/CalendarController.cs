using System;
using Microsoft.AspNetCore.Mvc;

namespace WorkWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        [HttpGet("PreviousSeven")]
        public IActionResult PreviousSeven(DateTime currentDate)
        {
            var newDate = currentDate.AddDays(-7);
            return Ok(newDate.ToString("yyyy-MM-dd"));
        }

        [HttpGet("NextSeven")]
        public IActionResult NextSeven(DateTime currentDate)
        {
            var newDate = currentDate.AddDays(7);
            return Ok(newDate.ToString("yyyy-MM-dd"));
        }

        [HttpGet("GoToToday")]
        public IActionResult GoToToday()
        {
            var newDate = DateTime.Today;
            return Ok(newDate.ToString("yyyy-MM-dd"));
        }

        [HttpPost("UpdateCurrentDate")]
        public IActionResult UpdateCurrentDate(DateTime newDate)
        {
            // You can store the new date in a session, a cookie, or a database
            // to persist it across requests. For now, just return Ok.
            return Ok();
        }
    }
}