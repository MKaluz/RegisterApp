using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinalProjectApi.Dto;
using FinalProjectApi.Entity;
using FinalProjectApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("visit")]
    public class VisitController: Controller
    {
        private readonly IVisitService _visitService;
        private readonly IMapper _mapper;

        public VisitController(IVisitService visitService, IMapper mapper)
        {
            _visitService = visitService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet()]
        public IActionResult GetVisits()
        {
            return new JsonResult(_visitService.GetAllVisits());
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost()]
        public IActionResult AddVisit([FromBody] VisitDto visitDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var visitToAdd = _mapper.Map<Visit>(visitDto);
            _visitService.Add(visitToAdd);

            return Ok(visitToAdd);
        }
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("id")]
        public IActionResult DeleteVisit(int id)
        {
            if (!_visitService.VisitExist(id))
            {
                return NotFound();
            }

            var visitToDelete = _visitService.GetVisitById(id);
            _visitService.Delete(visitToDelete);

            return NoContent();
        }
        [Authorize(Roles = Role.User)]
        [HttpPut("reserve/{visitId}")]
        public IActionResult ReserveVisit(int visitId)
        {
            var userId = HttpContext.User.Identity.Name;
            var visitToUpdate = _visitService.GetVisitById(visitId);
            visitToUpdate.Patient = Convert.ToInt32(userId);
            _visitService.Update(visitToUpdate);
            return Ok();
        }
    }
}
