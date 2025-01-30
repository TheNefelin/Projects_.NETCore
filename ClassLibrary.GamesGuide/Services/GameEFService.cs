using ClassLibrary.Common;
using ClassLibrary.GamesGuide.Connection;
using ClassLibrary.GamesGuide.DTOs;
using ClassLibrary.GamesGuide.Entities;
using ClassLibrary.GamesGuide.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.GamesGuide.Services
{
    public class GameEFService : IGamesService
    {
        private readonly ILogger<GameEFService> _logger;
        private readonly GamesGuideDbContext _context;

        public GameEFService(ILogger<GameEFService> logger, GamesGuideDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<ResponseApi<IEnumerable<GameDTO>>> GetAllAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all games");
            try
            {
                var result = await _context.GG_Games.ToListAsync(cancellationToken);

                var gamesDTO = result.Select(e => new GameDTO()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    ImgUrl = e.ImgUrl,
                    IdActive = e.IsActive,
                }).ToList();

                _logger.LogInformation("Successfully fetched all games.");
                var responseApi = new ResponseApi<IEnumerable<GameDTO>>()
                {
                    IsSucces = true,
                    StatusCode = 200,
                    Message = "Ok",
                    Data = gamesDTO,
                };

                return responseApi;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error fetching all games");
                return new ResponseApi<IEnumerable<GameDTO>>()
                {
                    IsSucces = false,
                    StatusCode = 500,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseApi<GameDTO>> GetByIdAsync(int Id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching game by ID: {Id}", Id);
            try
            {
                var result = await _context.GG_Games.FirstOrDefaultAsync(e => e.Id == Id, cancellationToken);

                if (result == null)
                {
                    _logger.LogWarning("Game with ID {Id} not found.", Id);
                    return new ResponseApi<GameDTO>
                    {
                        IsSucces = false,
                        StatusCode = 404,
                        Message = $"Id = {Id} Not Found",
                    };
                }

                var gameDTO = new GameDTO
                {
                    Id = result.Id,
                    Name = result.Name,
                    Description = result.Description,
                    ImgUrl = result.ImgUrl,
                    IdActive = result.IsActive,
                };

                _logger.LogInformation("Successfully fetched game by ID: {Id}", Id);
                return new ResponseApi<GameDTO>
                {
                    IsSucces = true,
                    StatusCode = 200,
                    Message = "Ok",
                    Data = gameDTO,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching game by ID: {Id}", Id);
                return new ResponseApi<GameDTO>()
                {
                    IsSucces = false,
                    StatusCode = 500,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseApi<GameDTO>> CreateAsync(GameDTO gameDTO, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating a new game.");
            try
            {
                var entity = new GameEntity
                {
                    Name = gameDTO.Name,
                    Description = gameDTO.Description,
                    ImgUrl = gameDTO.ImgUrl,
                    IsActive = gameDTO.IdActive,
                };

                await _context.GG_Games.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                gameDTO.Id = entity.Id;

                _logger.LogInformation("Successfully created game with ID: {Id}", entity.Id);
                return new ResponseApi<GameDTO>
                {
                    IsSucces = true,
                    StatusCode = 201,
                    Message = "Created",
                    Data = gameDTO,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating a new game");
                return new ResponseApi<GameDTO>
                {
                    IsSucces = false,
                    StatusCode = 500,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseApi<GameDTO>> UpdateAsync(int Id, GameDTO gameDTO, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating game with ID: {Id}", Id);
            try
            {
                var entity = await _context.GG_Games.FirstOrDefaultAsync(e => e.Id == Id, cancellationToken);

                if (entity == null)
                {
                    _logger.LogWarning("Game with ID {Id} not found for update.", Id);
                    return new ResponseApi<GameDTO>
                    {
                        IsSucces = false,
                        StatusCode = 404,
                        Message = $"Id = {Id} Not Found",
                    };
                }

                entity.Name = gameDTO.Name;
                entity.Description = gameDTO.Description;
                entity.ImgUrl = gameDTO.ImgUrl;
                entity.IsActive = gameDTO.IdActive;

                _context.GG_Games.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);

                _logger.LogInformation("Successfully updated game with ID: {Id}", Id);
                return new ResponseApi<GameDTO>
                {
                    IsSucces = true,
                    StatusCode = 200,
                    Message = "Updated",
                    Data = gameDTO,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating game with ID: {Id}", Id);
                return new ResponseApi<GameDTO>
                {
                    IsSucces = false,
                    StatusCode = 500,
                    Message = ex.Message,
                };
            }
        }
        public async Task<ResponseApi<bool>> DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleting game with ID: {Id}", Id);
            try
            {
                var entity = await _context.GG_Games.FirstOrDefaultAsync(e => e.Id == Id, cancellationToken);

                if (entity == null)
                {
                    _logger.LogWarning("Game with ID {Id} not found for deletion.", Id);
                    return new ResponseApi<bool>
                    {
                        IsSucces = false,
                        StatusCode = 404,
                        Message = $"Id = {Id} Not Found",
                        Data = false,
                    };
                }

                _context.GG_Games.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);

                _logger.LogInformation("Successfully deleted game with ID: {Id}", Id);
                return new ResponseApi<bool>
                {
                    IsSucces = true,
                    StatusCode = 200,
                    Message = "Deleted",
                    Data = true,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting game with ID: {Id}", Id);
                return new ResponseApi<bool>
                {
                    IsSucces = false,
                    StatusCode = 500,
                    Message = ex.Message,
                    Data = false,
                };
            }
        }
    }
}
