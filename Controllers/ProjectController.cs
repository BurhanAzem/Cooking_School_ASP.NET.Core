﻿using Cooking_School_ASP.NET.Dtos;
using Cooking_School_ASP.NET.Dtos.CookClassDto;
using Cooking_School_ASP.NET.Models;
using Cooking_School_ASP.NET.ModelUsed;
using Cooking_School_ASP.NET_.Controllers;
using Cooking_School_ASP.NET.Services.ProjectService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.WebPages;
using Cooking_School_ASP.NET.Services.AuthenticationServices;

namespace Cooking_School_ASP.NET.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private readonly ILogger<TraineeController> _logger;
        private readonly IProjectService _projectService;
        private readonly IAuthenticationServices _authenticationServices;
        public ProjectController(ILogger<TraineeController> logger, IProjectService projectService, IAuthenticationServices authenticationServices)
        {
            _logger = logger;
            _projectService = projectService;
            _authenticationServices = authenticationServices;
        }

        [HttpPost("~/api/cook-classes/{classId}/projects")]
        [Authorize(Roles = "Chef")]
        public async Task<IActionResult> CreateProject([FromForm] CreateProjectDto projectDto, int classId)
        {
            _logger.LogInformation($"Attempt Sinup for {nameof(projectDto)} ");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt for {nameof(projectDto)}");
                return BadRequest(ModelState);
            }
            var chef = await _authenticationServices.GetCurrentUser(HttpContext);
            var result = await _projectService.CreateProject(projectDto, chef.Id);
            if (result.Exception is not null)
            {
                var code = result.StatusCode;
                throw new StatusCodeException(code.Value, result.Exception);
            }
            return Ok(result.Dto);
        }


        [HttpPut("~/api/cook-classes/{classId}/projects/{projectId}")]
        [Authorize(Roles = "Chef")]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectDto projectDto, int projectId)
        {
            _logger.LogInformation($"Attempt Sinup for {nameof(projectDto)} ");
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Put attempt for {nameof(projectDto)}");
                return BadRequest(ModelState);
            }
            var result = await _projectService.UpdateProject(projectId, projectDto);
            if (result.Exception is not null)
            {
                var code = result.StatusCode;
                throw new StatusCodeException(code.Value, result.Exception);
            }
            return Ok(result.Dto);
        }

        [HttpDelete("~/api/cook-classes/{classId}/projects/{projectId}")]
        [Authorize(Roles = "Chef")]
        public async Task<IActionResult> DeleteProject(int classId, int projectId)
        {
            _logger.LogInformation($"Attempt Delete for {nameof(Project)} ");
            var result = await _projectService.DeleteProject(projectId, classId);
            if (result.Exception is not null)
            {
                var code = result.StatusCode;
                throw new StatusCodeException(code.Value, result.Exception);
            }
            return Ok(result.Dto);
        }

        [HttpGet("~/api/courses/{coursesId}/cook-classes/{cookclassId}/projects")]
        [Authorize(Roles = "Chef, Trainee")]
        public async Task<IActionResult> GetAllProjectTrainee([FromQuery] RequestParam requestParams)
        {
            _logger.LogInformation($"Attempt GetAll of {nameof(Project)} ");
            var result = await _projectService.GetAllProject(requestParams);
            return Ok(result.ListDto);
        }


        [HttpGet("~/api/courses/{coursesId}/cook-classes/{cookclassId}/projects/{projectId}")]
        [Authorize(Roles = "Chef, Trainee")]
        public async Task<IActionResult> GetProjectById(int projectId)
        {
            _logger.LogInformation($"Attempt GetBy Id of {nameof(Project)}");
            var result = await _projectService.GetProjectById(projectId);
            if (result.Exception is not null)
            {
                var code = result.StatusCode;
                throw new StatusCodeException(code.Value, result.Exception);
            }
            return Ok(result.Dto);
        }
    }
}
