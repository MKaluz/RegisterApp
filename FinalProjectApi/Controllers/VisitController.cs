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
        private IVisitService _visitService;
        private IMapper _mapper;

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

        [AllowAnonymous]
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
    }
}
