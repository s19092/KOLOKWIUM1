using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolosikEssa.Models;
using KolosikEssa.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolosikEssa.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        IDbService _service;
        public ProjectController(IDbService service)
        {

            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetProject(int id)
        {
            var result = _service.GetProject(id);
            if (result == null)
                return BadRequest("Problem occured");
            return Ok(result);
        }
    }
}