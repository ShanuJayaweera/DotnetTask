using DotNetTask.DTOs.Request;
using DotNetTask.Interfaces;
using DotNetTask.Mappers;
using DotNetTask.Models;
using Microsoft.AspNetCore.Mvc;
using static DotNetTask.Const.ConstEnums;

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
         * Get Question Types
         * @param programRequest
         */

        [HttpGet]
        public ActionResult GetQuestionTypes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = Enum.GetValues(typeof(QuestionTypes))
                             .Cast<QuestionTypes>()
                             .Select(q => new { Name = q.ToString(), Value = (int)q })
                             .ToDictionary(x => x.Name, x => x.Value);

            return Ok(values);
        }


        /* 
         * Save program data
         * @param programRequest
         */

        [HttpPost("SaveProgram")]
        public async Task<ActionResult> SaveProgram(ProgramDataRequestDTO programRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ProgramData data = programRequest.ToProgramsDataModel();
            ProgramData programResponse = await _programDataRepository.CreateProgramDataAsync(data);
            return Ok(programResponse);
        }


        /* 
         * Question update
         * @param quiz, programId, questionId
         */

        [HttpPut("UpdateQuiz/{programId}/{questionId}")]
        public async Task<ActionResult> UpdateQuestion(QuestionDataDTO quiz, string programId, string questionId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _programDataRepository.UpdateQuestionsAsync(quiz, programId, questionId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        /* 
         * Question delete
         * @param programId, questionId
         */
        [HttpDelete("DeleteQuiz/{programId}/{questionId}")]
        public async Task<ActionResult> DeleteQuestion(string programId, string questionId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _programDataRepository.DeleteQuestionsAsync(programId, questionId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        /* 
         * Get program data
         * @param programId
         */

        [HttpGet("GetProgram/{programId}")]
        public async Task<ActionResult> GetProgramData(string programId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _programDataRepository.GetProgramAsync(programId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
