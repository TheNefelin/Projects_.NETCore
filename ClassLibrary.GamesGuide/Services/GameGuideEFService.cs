using ClassLibrary.Common;
using ClassLibrary.Common.DTOs;
using ClassLibrary.GamesGuide.Connection;
using ClassLibrary.GamesGuide.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.GamesGuide.Services
{
    public class GameGuideEFService : IGameGuideEFService
    {
        private readonly ILogger<GameGuideEFService> _logger;
        private readonly GamesGuideDbContext _context;

        public GameGuideEFService(ILogger<GameGuideEFService> logger, GamesGuideDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<ResponseApi<IEnumerable<DataGameDTO>>> GetAllGamesAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all games");
            try
            {
                var result = await _context.GG_Games
                    .Include(t => t.Characters)
                    .Include(t => t.Source)
                    .Include(t => t.Backgrounds)
                    .Include(t => t.Guides)
                        .ThenInclude(t => t.GuidesUser)
                    .Include(t => t.Guides)
                        .ThenInclude(t => t.Adventures)
                            .ThenInclude(t => t.AdventuresUser)
                    .Include(t => t.Guides)
                        .ThenInclude(t => t.Adventures)
                            .ThenInclude(t => t.AdventuresImg)
                    .ToListAsync(cancellationToken);

                var gamesDTO = result.Select(ga => new DataGameDTO()
                {
                    Id = ga.Id,
                    Name = ga.Name,
                    Description = ga.Description,
                    ImgUrl = ga.ImgUrl,
                    IsActive = ga.IsActive,
                    Characters = ga.Characters.Select(ch => new DataCharacterDTO()
                    {
                        Id = ch.Id,
                        Name = ch.Name,
                        Description = ch.Description,
                        ImgUrl = ch.ImgUrl,
                    }).ToList(),
                    Sources = ga.Source.Select(sr => new DataSourceDTO()
                    {
                        Id = sr.Id,
                        Name = sr.Name,
                        Url = sr.Url,
                    }).ToList(),
                    Backgrounds = ga.Backgrounds.Select(bg => new DataBackgroundDTO()
                    {
                        Id = bg.Id,
                        ImgUrl = bg.ImgUrl,
                    }).ToList(),
                    Guides = ga.Guides.Select(gu => new DataGuideDTO()
                    {
                        Id = gu.Id,
                        Name = gu.Name,
                        Sort = gu.Sort,
                        GuideUser = gu.GuidesUser
                            .Where(guu => guu.Id_Guide == gu.Id)
                            .Select(guu => new DataGuideUserDTO
                            {
                                Id_Guide = guu.Id_Guide,
                                Id_User = guu.Id_User,
                                IsCheck = guu.IsCheck,
                            })
                            .FirstOrDefault() ?? (new DataGuideUserDTO
                            {
                                Id_Guide = gu.Id,
                                Id_User = null,
                                IsCheck = false,
                            }),
                        Adventures = gu.Adventures.Select(adv => new DataAdventureDTO()
                        {
                            Id = adv.Id,
                            Description = adv.Description,
                            IsImportant = adv.IsImportant,
                            Sort = adv.Sort,
                            AdventureUser = adv.AdventuresUser
                                .Where(advu => advu.Id_Adventure == adv.Id)
                                .Select(advu => new DataAdventureUserDTO
                                {
                                    Id_Adventure = advu.Id_Adventure,
                                    Id_User = advu.Id_User,
                                    IsCheck = advu.IsCheck,
                                })
                                .FirstOrDefault() ?? (new DataAdventureUserDTO
                                {
                                    Id_Adventure = adv.Id,
                                    Id_User = null,
                                    IsCheck = false,
                                }),
                            AdventuresImg = adv.AdventuresImg.Select(advi => new DataAdventureImgDTO()
                            {
                                Id = advi.Id,
                                ImgUrl = advi.ImgUrl,
                                Sort = advi.Sort,
                            }).ToList(),
                        }).ToList(),
                    }).ToList(),
                }).ToList();

                _logger.LogInformation("Successfully fetched all games.");
                var responseApi = new ResponseApi<IEnumerable<DataGameDTO>>()
                {
                    IsSucces = true,
                    StatusCode = 200,
                    Message = "Ok",
                    Data = gamesDTO,
                };

                return responseApi;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all games");
                return new ResponseApi<IEnumerable<DataGameDTO>>()
                {
                    IsSucces = false,
                    StatusCode = 500,
                    Message = ex.Message,
                };
            }
        }
    }
}
