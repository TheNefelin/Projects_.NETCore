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
                    .ToListAsync(cancellationToken);

                var gamesDTO = result.Select(e => new DataGameDTO()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    ImgUrl = e.ImgUrl,
                    IsActive = e.IsActive,
                    Characters = e.Characters.Select(ch => new DataCharacterDTO()
                    {
                        Id = ch.Id,
                        Name = ch.Name,
                        Description = ch.Description,
                        ImgUrl = ch.ImgUrl,
                    }).ToList(),
                    Sources = e.Source.Select(sc => new DataSourceDTO()
                    {
                        Id = sc.Id,
                        Name = sc.Name,
                        ImgUrl = sc.ImgUrl,
                    }).ToList(),
                    Backgrounds = e.Backgrounds.Select(bg => new DataBackgroundDTO()
                    {
                        Id = bg.Id,
                        ImgUrl = bg.ImgUrl,
                    }).ToList(),
                    Guides = e.Guides.Select(gu => new DataGuideDTO()
                    {
                        Id = gu.Id,
                        Name = gu.Name,
                        Sort = gu.Sort,
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
