using ClassLibrary.Common;
using ClassLibrary.GamesGuide.Connection;
using ClassLibrary.GamesGuide.DTOs;
using ClassLibrary.GamesGuide.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.GamesGuide.Services
{
    public class PublicService : IPublicService
    {
        private readonly ILogger<GameService> _logger;
        private readonly GamesGuideDbContext _context;

        public PublicService(ILogger<GameService> logger, GamesGuideDbContext context)
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
                    Characters = ga.Characters.Select(c => new DataCharacterDTO()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        ImgUrl = c.ImgUrl,
                    }).ToList(),
                    Sources = ga.Source.Select(s => new DataSourceDTO()
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Url = s.Url,
                    }).ToList(),
                    Backgrounds = ga.Backgrounds.Select(b => new DataBackgroundDTO()
                    {
                        Id = b.Id,
                        ImgUrl = b.ImgUrl,
                    }).ToList(),
                    Guides = ga.Guides.Select(gu => new DataGuideDTO()
                    {
                        Id = gu.Id,
                        Name = gu.Name,
                        Sort = gu.Sort,
                        GuidesUser = gu.GuidesUser.Select(gu => new DataGuideUserDTO()
                        {
                            Id_Guide = gu.Id_Guide,
                            Id_User = gu.Id_User,
                            IsCheck = gu.IsCheck,
                        }).ToList(),
                        Adventures = gu.Adventures.Select(ad => new DataAdventureDTO()
                        {
                            Id = ad.Id,
                            Description = ad.Description,
                            IsImportant = ad.IsImportant,
                            Sort = ad.Sort,
                            AdventuresUser = ad.AdventuresUser.Select(au => new DataAdventureUserDTO()
                            {
                                Id_User = au.Id_User,
                                Id_Adventure = au.Id_Adventure,
                                IsCheck = au.IsCheck,
                            }).ToList(),
                            AdventuresImg = ad.AdventuresImg.Select(ad => new DataAdventureImgDTO()
                            {
                                Id = ad.Id,
                                ImgUrl = ad.ImgUrl,
                                Sort = ad.Sort,
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
