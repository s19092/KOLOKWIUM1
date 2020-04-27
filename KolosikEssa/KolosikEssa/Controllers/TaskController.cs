using System;
using System.Collections.Generic;
using System.Linq;
using KolosikEssa.Models;
using KolosikEssa.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolosikEssa.Controllers
{

    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {

        IDbService _service;
        public TaskController(IDbService service)
        {

            _service = service;

        }
        [HttpPost]
        public IActionResult AddTask(Task req)
        {
            if (_service.Add(req))
                return Ok("Ok");
            return BadRequest("SOmething gone wrong");
        }
    }
}