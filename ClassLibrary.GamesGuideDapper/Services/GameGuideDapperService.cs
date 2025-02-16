using ClassLibrary.Common.Models;
using ClassLibrary.GamesGuideDapper.DTOs;
using ClassLibrary.GamesGuideDapper.Entities;
using ClassLibrary.GamesGuideDapper.Interfaces;
using System.Data;

namespace ClassLibrary.GamesGuideDapper.Services
{
    public class GameGuideDapperService : IGameGuideDapperService
    {
        private readonly IServiceCRUD<GameEntity> _game;
        private readonly IServiceCRUD<CharacterEntity> _character;
        private readonly IServiceCRUD<SourceEntity> _source;
        private readonly IServiceCRUD<BackgroundEntity> _background;
        private readonly IServiceCRUD<GuideEntity> _guide;
        private readonly IServiceCRUD<AdventureEntity> _adventure;
        private readonly IServiceCRUD<AdventureImgEntity> _adventureImg;
        private readonly IServiceUserCRUD<GuideUserEntity> _guideUser;
        private readonly IServiceUserCRUD<AdventureUserEntity> _adventureUser;

        public GameGuideDapperService(
            IServiceCRUD<GameEntity> game,
            IServiceCRUD<CharacterEntity> character,
            IServiceCRUD<SourceEntity> source,
            IServiceCRUD<BackgroundEntity> background,
            IServiceCRUD<GuideEntity> guide,
            IServiceCRUD<AdventureEntity> adventure,
            IServiceCRUD<AdventureImgEntity> adventureImg,
            IServiceUserCRUD<GuideUserEntity> guideUser,
            IServiceUserCRUD<AdventureUserEntity> adventureUser
            )
        {
            _game = game;
            _character = character;
            _source = source;
            _background = background;
            _guide = guide;
            _adventure = adventure;
            _adventureImg = adventureImg;
            _guideUser = guideUser;
            _adventureUser = adventureUser;
        }

        public async Task<ResponseApi<IEnumerable<DataGameDTO>>> GetAllAsync(string Id_User, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(Id_User))
                Id_User = string.Empty;

            try
            {
                var taskGame = _game.GetAllAsync(cancellationToken);
                var taskCharacter = _character.GetAllAsync(cancellationToken);
                var taskSource = _source.GetAllAsync(cancellationToken);
                var taskBackground = _background.GetAllAsync(cancellationToken);
                var taskGuide = _guide.GetAllAsync(cancellationToken);
                var taskGuideUser = _guideUser.GetAllByIdAsync(Id_User, cancellationToken);
                var taskAdventure = _adventure.GetAllAsync(cancellationToken);
                var taskAdventureUser = _adventureUser.GetAllByIdAsync(Id_User, cancellationToken);
                var taskAdventureImg = _adventureImg.GetAllAsync(cancellationToken);

                Task.WaitAll(taskGame, taskCharacter, taskSource, taskBackground, taskGuide, taskGuideUser, taskAdventure, taskAdventureUser, taskAdventureImg);

                var game = await taskGame;
                var character = await taskCharacter;
                var source = await taskSource;
                var background = await taskBackground;
                var guide = await taskGuide;
                var guideUser = await taskGuideUser;
                var adventure = await taskAdventure;
                var adventureUser = await taskAdventureUser;
                var adventureImg = await taskAdventureImg;

                var result = game.Select(ga => new DataGameDTO
                {
                    Id = ga.Id,
                    Name = ga.Name,
                    Description = ga.Description,
                    ImgUrl = ga.ImgUrl,
                    IsActive = ga.IsActive,
                    Characters = character.Where(ch => ch.Id_Game == ga.Id).Select(ch => new DataCharacterDTO { 
                        Id = ch.Id,
                        Name = ch.Name,
                        Description = ch.Description,
                        ImgUrl = ch.ImgUrl,
                    }).ToList(),
                    Sources = source.Where(sr => sr.Id_Game == ga.Id).Select(sr => new DataSourceDTO { 
                        Id = sr.Id,
                        Name = sr.Name,
                        Url = sr.Url,
                    }).ToList(),
                    Backgrounds = background.Where(bg => bg.Id_Game == ga.Id).Select(bg => new DataBackgroundDTO { 
                        Id = bg.Id,
                        ImgUrl = bg.ImgUrl,
                    }).ToList(),
                    Guides = guide.Where(gu => gu.Id_Game == ga.Id).Select(gu => new DataGuideDTO { 
                        Id = gu.Id,
                        Name = gu.Name,
                        Sort = gu.Sort,
                        GuideUser = guideUser
                            .Where(guu => guu.Id_Guide == gu.Id && guu.Id_User == Id_User)
                            .Select(guu => new DataGuideUserDTO { 
                                Id_Guide = guu.Id_Guide,
                                Id_User = guu.Id_User,
                                IsCheck = guu.IsCheck,
                            })
                            .FirstOrDefault() ?? (new DataGuideUserDTO { 
                                Id_Guide = gu.Id,
                                Id_User = Id_User,
                                IsCheck = false
                            }),
                        Adventures = adventure.Where(ad => ad.Id_Guide == gu.Id).Select(adv => new DataAdventureDTO
                        {
                            Id = adv.Id,
                            Description = adv.Description,
                            IsImportant = adv.IsImportant,
                            Sort = adv.Sort,
                            AdventureUser = adventureUser
                                .Where(advu => advu.Id_Adventure == adv.Id && advu.Id_User == Id_User)
                                .Select(advu => new DataAdventureUserDTO
                                {
                                    Id_Adventure = advu.Id_Adventure,
                                    Id_User = advu.Id_User,
                                    IsCheck = advu.IsCheck,
                                })
                                .FirstOrDefault() ?? (new DataAdventureUserDTO {
                                    Id_Adventure = adv.Id,
                                    Id_User = Id_User,
                                    IsCheck = false
                                }),
                            AdventuresImg = adventureImg.Where(adi => adi.Id_Adventure == adv.Id).Select(adi => new DataAdventureImgDTO
                            {
                                Id = adi.Id,
                                ImgUrl = adi.ImgUrl,
                                Sort = adi.Sort,
                            }).ToList(),
                        }).ToList(),
                    }).ToList(),
                }).ToList();

                return new ResponseApi<IEnumerable<DataGameDTO>> { 
                    IsSucces = true,
                    StatusCode = 200,
                    Message = "Ok",
                    Data = result
                };
            }
            catch (Exception ex) {
                return new ResponseApi<IEnumerable<DataGameDTO>>
                {
                    IsSucces = false,
                    StatusCode = 500,
                    Message = ex.Message,
                };
            }
        }
    }
}
