using DotNetTask.DTOs.Request;
using DotNetTask.Interfaces;
using DotNetTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        public readonly ICandidaterepository _candidateRepository;
        public readonly IProgramDataRepository _programDataRepository;
        public CandidateController(ICandidaterepository candidateRepository, IProgramDataRepository programDataRepository)
        {
            this._candidateRepository = candidateRepository;
            this._programDataRepository = programDataRepository;
        }


        /* 
         * Save candidate data
         * @param programRequest
         */

        [HttpPost("SaveCandidate")]
        public async Task<ActionResult> SaveCandidate(CandidateDTO candidateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            // check is program Exist
            bool programExist = await _programDataRepository.IsProgramExist(candidateDTO.ProgramId);
            if (!programExist)
            {
                return NotFound();
            }

            // check is all questionIds are correct
            bool isAllQuestionIdsExist = true;
            var answers = candidateDTO.Answers;
            foreach (var answer in answers)
            {
                string questionId = answer.QuestionID;
                bool isExist = await _programDataRepository.IsQuestionExist(candidateDTO.ProgramId, answer.QuestionID);
                if (!isExist)
                {
                    isAllQuestionIdsExist = false;
                    break;
                }
            }
            if (!isAllQuestionIdsExist)
            {
                return BadRequest();
            }
            
            Candidate candidate = await _candidateRepository.CreateCandidateAsync(candidateDTO);
            return Ok(candidate);
        }
    }
}
