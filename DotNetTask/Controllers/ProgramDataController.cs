using DotNetTask.DTOs.Request;
using DotNetTask.Interfaces;
using DotNetTask.Mappers;
using DotNetTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DotNetTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramDataController : ControllerBase
    {
        public readonly IProgramDataRepository _programDataRepository;
        public ProgramDataController(IProgramDataRepository programDataRepository)
        {
            this._programDataRepository = programDataRepository;
        }


        /* 
         * Save program data
         * @param programRequest
         */

        [HttpPost("SaveProgram")]
        public async Task<ActionResult> SaveProgram(ProgramDataRequestDTO programRequest)
        {
            ProgramData data = programRequest.ToProgramsDataModel();
            ProgramData programResponse = await _programDataRepository.CreateProgramDataAsync(data);
            return Ok(programResponse);
        }


    }
}
