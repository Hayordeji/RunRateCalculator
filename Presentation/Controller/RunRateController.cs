using Business_Logic.Dto;
using Business_Logic.Mapper;
using Business_Logic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunRateController : ControllerBase
    {
        private readonly IRunRateService _runRateService;
        public RunRateController(IRunRateService runRateService)
        {
            _runRateService = runRateService;
        }

        [HttpPost]
        public async Task<IActionResult> Record([FromBody] CreateRecordDto recordDto)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Model state is not valid");
                }
                var completedRecord = await _runRateService.CreateRecordAsync(recordDto);

                if (completedRecord == null)
                {
                    return BadRequest("record is null");
                }
                return Ok(completedRecord);
            }
            catch (Exception e)
            {
                return StatusCode(500,e);
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetRecords()
        {
            var list = await _runRateService.GetRecordsAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecord([FromRoute] int id) 
        {
            var record = await _runRateService.GetRecordAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecord([FromRoute] int id)
        {
           var recordToDelete =  await _runRateService.DeleteRecordAsync(id);
            if (recordToDelete == null)
            {
                return NotFound();
            }
            return Ok("Successfully Deleted");
        }

    }
}
