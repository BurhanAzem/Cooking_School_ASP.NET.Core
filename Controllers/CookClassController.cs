﻿using Cooking_School_ASP.NET.Controllers;
using Cooking_School_ASP.NET.Dtos;
using Cooking_School_ASP.NET.Dtos.CookClassDto;
using Cooking_School_ASP.NET.Dtos.TraineeDto;
using Cooking_School_ASP.NET.ModelUsed;
using Cooking_School_ASP.NET.Services.AuthenticationServices;
using Cooking_School_ASP.NET.Services.CookClassService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.WebPages;

namespace Cooking_School_ASP.NET_.Controllers
{
    [Route("api/cook-classes")]
    [ApiController]
    public class CookClassController : ControllerBase
    {
        private readonly ILogger<CookClassController> _logger;
        private readonly ICookClassService _cookClassService;
        private readonly IAuthenticationServices _authenticationServices;

        public CookClassController(ILogger<CookClassController> logger, ICookClassService cookClassService, IAuthenticationServices authenticationServices)
        {
            _logger = logger;
            _cookClassService = cookClassService;
            _authenticationServices = authenticationServices;
        }
        ///pi/chefs/{chefId}/cook-classes
        [HttpPost("~/api/cook-classes")]
        [Authorize(Roles = "Administrator, Chef")]
        public async Task<IActionResult> CreateClass([FromBody] CreateCookClassDto classDto)
        {
            var user = await _authenticationServices.GetCurrentUser(HttpContext);
            _logger.LogInformation($" Attempt Sinup for {classDto} ");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt for {nameof(classDto)}");
                return BadRequest(ModelState);
            }
            var result = await _cookClassService.CreateCookClass(classDto, user.Id);
            if (result.Exception is not null)
            {
                var code = result.StatusCode;
                throw new StatusCodeException(code.Value, result.Exception);
            }
            return Ok(result.Dto);
        }

        [HttpPut("~/api/cook-classes/{classId}")]
        [Authorize(Roles = "Administrator, Chef")]
        public async Task<IActionResult> UpdateClass(int classId, [FromBody] UpdateCookClassDto classDto)
        {
            _logger.LogInformation($" Attempt Update for {classDto} ");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Update attempt for {nameof(classDto)}");
                return BadRequest(ModelState);
            }
            var result = await _cookClassService.UpdateCookClass(classId, classDto);
            if (result.Exception is not null)
            {
                var code = result.StatusCode;
                throw new StatusCodeException(code.Value, result.Exception);
            }
            return Ok(result.Dto);
        }

        [HttpDelete("~/api/cook-classes/{classId}")]
        [Authorize(Roles = "Administrator, Chef")]
        public async Task<IActionResult> DleteClass(int classId)
        {
            _logger.LogInformation($" Attempt Delete CookClass {classId} ");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Delete CookClass {classId}");
                return BadRequest(ModelState);
            }
            var result = await _cookClassService.DeleteCookClass(classId);
            if (result.Exception is not null)
            {
                var code = result.StatusCode;
                throw new StatusCodeException(code.Value, result.Exception);
            }
            return Ok(result.Dto);
        }

        [HttpGet("~/api/cook-classes")]
        [Authorize(Roles = "Chef")]
        public async Task<IActionResult> GetAllCookClasses([FromQuery]RequestParam requestParam)
        {
            var chef = await _authenticationServices.GetCurrentUser(HttpContext);
            var result = await _cookClassService.GetAllCookClassesForChef(chef.Id, requestParam);
            if (result.Exception is not null)
            {
                var code = result.StatusCode;
                throw new StatusCodeException(code.Value, result.Exception);
            }
            return Ok(result.ListDto);
        }
    }





}
