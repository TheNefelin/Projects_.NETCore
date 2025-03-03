﻿using ClassLibrary.Common.Models;
using ClassLibrary.GamesGuideDapper.DTOs;
using ClassLibrary.GamesGuideDapper.Entities;
using ClassLibrary.GamesGuideDapper.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/game-guide")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyFilter))]
    public class GameGuideController : ControllerBase
    {
        private readonly ILogger<GameGuideController> _logger;
        private readonly IGameGuideDapperService _dapper;
        private readonly IServiceUserCRUD<GuideUserEntity> _guideUser;
        private readonly IServiceUserCRUD<AdventureUserEntity> _adventureUser;
        private readonly IAuthGoogleService _authGoogleService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GameGuideController(
            ILogger<GameGuideController> logger,
            IServiceUserCRUD<GuideUserEntity> guideUser,
            IServiceUserCRUD<AdventureUserEntity> adventureUser,
            IGameGuideDapperService dapper,
            IAuthGoogleService authGoogleService,
            IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _guideUser = guideUser;
            _adventureUser = adventureUser;
            _dapper = dapper;
            _authGoogleService = authGoogleService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("img")]
        public IActionResult GetImg(string fileName)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "GamesGuide");
            var filePath = Path.Combine(path, fileName);

            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);

                return File(b, "image/webp");
            }

            return BadRequest(new { Msge = "El Archivo No Existe" });
        }

        [HttpGet("{iduser?}")]
        public async Task<ActionResult<ResponseApi<IEnumerable<DataGameDTO>>>> GetAllDapper(string? iduser, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received request to fetch all games.");
            var result = await _dapper.GetAllAsync(iduser, cancellationToken);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("auth-google")]
        public async Task<ActionResult<ResponseApi<LoggedToken>>> GoogleLoginAsync(LoginGoogle login, CancellationToken cancellationToken)
        {
            var result = await _authGoogleService.LoginGoogleAsync(login, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("guide")]
        public async Task<ActionResult<ResponseApi<object>>> PostGameDapper(GuideUserEntity gameUser, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received request to Check Guide.");
            var result = await _guideUser.UpdateAsync(gameUser, cancellationToken);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("adventure")]
        public async Task<ActionResult<ResponseApi<object>>> PostAdventureDapper(AdventureUserEntity adventureUser, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received request to Check Adventure.");
            var result = await _adventureUser.UpdateAsync(adventureUser, cancellationToken);

            return StatusCode(result.StatusCode, result);
        }
    }
}
