using ClassLibrary.Common;
using ClassLibrary.PortfolioDapper.Models.DTOs;
using ClassLibrary.PortfolioDapper.Models.Entities;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ClassLibrary.PortfolioDapper.Services
{
    public class PortfolioService
    {
        private readonly SqlConnection _connection;

        public PortfolioService(SqlConnection connection)
        {
            _connection = connection;
        }

        private async Task<IEnumerable<T>> GetAll<T>(string Query, CancellationToken cancellationToken)
        {
            try
            {
                using var connection = new SqlConnection(_connection.ConnectionString);
                await connection.OpenAsync(cancellationToken);
                var result = await connection.QueryAsync<T>(Query);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error PortfolioService.", ex);
            }
        }

        private async Task<IEnumerable<UrlGrpEntity>> GetAllUrlsGrpAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, Name, IsEnable FROM PF_UrlGrp";
            return await GetAll<UrlGrpEntity>(query, cancellationToken);
        }

        private async Task<IEnumerable<UrlEntity>> GetAllUrlsAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, Name, Url, IsEnable, Id_UrlGrp FROM PF_Url";
            return await GetAll<UrlEntity>(query, cancellationToken);
        }

        private async Task<IEnumerable<ProjectEntity>> GetAllProjectsAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, Name, ImgUrl, RepoUrl, AppUrl FROM PF_Projects ORDER BY Id DESC";
            return await GetAll<ProjectEntity>(query, cancellationToken);
        }

        private async Task<IEnumerable<LanguageEntity>> GetAllLanguagesAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT a.Id, a.Name, a.ImgUrl, b.Id_Project FROM PF_Languages a INNER JOIN PF_Pro_Lang b ON a.Id = b.Id_Language";
            return await GetAll<LanguageEntity>(query, cancellationToken);
        }

        private async Task<IEnumerable<TechnologyEntity>> GetAllTechnologiesAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT a.Id, a.Name, a.ImgUrl, b.Id_Project FROM PF_Technologies a INNER JOIN PF_Pro_Tech b ON a.Id = b.Id_Technology";
            return await GetAll<TechnologyEntity>(query, cancellationToken);
        }

        public async Task<ResponseApi<IEnumerable<DataUrlGrpDTO>>> GetAll_Urls_Async(CancellationToken cancellationToken)
        {
            try
            {
                var taskUrlsGrp = GetAllUrlsGrpAsync(cancellationToken);
                var taskUrls = GetAllUrlsAsync(cancellationToken);

                await Task.WhenAll(taskUrlsGrp, taskUrls);

                var urlsGrp = await taskUrlsGrp;
                var urls = await taskUrls;

                var result = urlsGrp.Select(ug => new DataUrlGrpDTO
                {
                    Id = ug.Id,
                    Name = ug.Name,
                    IsEnable = ug.IsEnable,
                    Urls = urls.Where(u => u.Id_UrlGrp == ug.Id).Select(nu => new DataUrlDTO
                    {
                        Id = nu.Id,
                        Name = nu.Name,
                        Url = nu.Url,
                        IsEnable = nu.IsEnable,
                    }).ToList(),
                }).ToList();

                var apiResult = new ResponseApi<IEnumerable<DataUrlGrpDTO>>
                {
                    IsSucces = true,
                    StatusCode = 200,
                    Message = "Ok",
                    Data = result
                };

                return apiResult;
            }
            catch (Exception ex)
            {
                var apiResult = new ResponseApi<IEnumerable<DataUrlGrpDTO>>
                {
                    IsSucces = false,
                    StatusCode = 500,
                    Message = $"Error al obtener los datos: {ex.Message}",
                    Data = null
                };

                return apiResult;
            }          
        }

        public async Task<ResponseApi<IEnumerable<DataProjectDTO>>> GetAll_Projects_Async(CancellationToken cancellationToken)
        {
            try
            {
                var taskProjects = GetAllProjectsAsync(cancellationToken);
                var taskLanguages = GetAllLanguagesAsync(cancellationToken);
                var taskTechnologies = GetAllTechnologiesAsync(cancellationToken);

                await Task.WhenAll(taskProjects, taskLanguages, taskTechnologies);

                var projects = await taskProjects;
                var languages = await taskLanguages;
                var technologies = await taskTechnologies;

                var result = projects.Select(p => new DataProjectDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImgUrl = p.ImgUrl,
                    RepoUrl = p.RepoUrl,
                    AppUrl = p.AppUrl,
                    Languages = languages.Where(l => l.Id_Project == p.Id).Select(nl => new DataLanguageDTO
                    {
                        Id = nl.Id,
                        Name = nl.Name,
                        ImgUrl = nl.ImgUrl,
                    }).ToList(),
                    Technologies = technologies.Where(t => t.Id_Project == p.Id).Select(nt => new DataTechnologyDTO
                    {
                        Id = nt.Id,
                        Name = nt.Name,
                        ImgUrl = nt.ImgUrl,
                    }).ToList(),
                }).ToList();

                var apiResult = new ResponseApi<IEnumerable<DataProjectDTO>>
                {
                    IsSucces = true,
                    StatusCode = 200,
                    Message = "Ok",
                    Data = result
                };

                return apiResult;
            }
            catch (Exception ex)
            {
                var apiResult = new ResponseApi<IEnumerable<DataProjectDTO>>
                {
                    IsSucces = false,
                    StatusCode = 500,
                    Message = $"Error al obtener los datos: {ex.Message}",
                    Data = null
                };

                return apiResult;
            }
        }
    }
}
