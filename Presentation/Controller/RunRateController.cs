﻿using Business_Logic.Dto;
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
        public async Task<IActionResult> Record([FromBody]CreateRecordDto recordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model state is not valid");
            }

            var newRecord = recordDto.ToCreateRecordDto();
            if (newRecord == null)
            {
                return BadRequest("newRecord is null");
            }

            var completedRecord = await _runRateService.CreateRecordAsync(newRecord);
            return Ok(completedRecord);

        }

        [HttpGet]
        public async Task<IActionResult> Records()
        {
            var list = await _runRateService.GetRecordsAsync();
            return Ok(list);
        }
    }
}
