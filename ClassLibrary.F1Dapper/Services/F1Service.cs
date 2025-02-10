using ClassLibrary.Common;
using ClassLibrary.F1Dapper.DTOs;
using ClassLibrary.F1Dapper.Entities;
using ClassLibrary.F1Dapper.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ClassLibrary.F1Dapper.Services
{
    public class F1Service : IF1Service
    {
        private readonly SqlConnection _connection;

        public F1Service(SqlConnection connection)
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
                throw new Exception("Error F1Service.", ex);
            }
        }

        private async Task<IEnumerable<FlagEntity>> GetAllFlagsAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, Name, ImgFlag FROM F1_Flags";
            return await GetAll<FlagEntity>(query, cancellationToken);
        }

        private async Task<IEnumerable<TeamEntity>> GetAllTeamsAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, Name, ImgCar, Id_Flag FROM F1_Teams";
            return await GetAll<TeamEntity>(query, cancellationToken);
        }

        private async Task<IEnumerable<PilotEntity>> GetAllPilotsAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, Name, DateBirth, Height, Weight, Dorsal, ImgProfile, IsAlive, Points, Id_Flag, Id_Team FROM F1_Pilots";
            return await GetAll<PilotEntity>(query, cancellationToken);
        }

        private async Task<IEnumerable<CircuitEntity>> GetAllCircuitsAsync(CancellationToken cancellationToken)
        {
            var query = "SELECT Id, Name, Id_Flag FROM F1_Circuits";
            return await GetAll<CircuitEntity>(query, cancellationToken);
        }

        public async Task<ResponseApi<IEnumerable<TeamDTO>>> GetAll_Teams_Async(CancellationToken cancellationToken)
        {
            try
            {
                var taskFlags = GetAllFlagsAsync(cancellationToken);
                var taskTeams = GetAllTeamsAsync(cancellationToken);
                var taskPilots = GetAllPilotsAsync(cancellationToken);

                await Task.WhenAll(taskFlags, taskTeams, taskPilots);

                var flags = await taskFlags;
                var teams = await taskTeams;
                var pilots = await taskPilots;

                var result = teams.Select(ntm => new TeamDTO
                {
                    Id = ntm.Id,
                    Name = ntm.Name,
                    ImgCar = ntm.ImgCar,
                    flag = flags.Where(fl => fl.Id == ntm.Id_Flag).Select(nfl => new FlagDTO
                    {
                        Id = nfl.Id,
                        Name = nfl.Name,
                        ImgFlag = nfl.ImgFlag,
                    }).FirstOrDefault(new FlagDTO()),
                    pilots = pilots.Where(pl => pl.Id_Team == ntm.Id).Select(npl => new PilotDTO
                    {
                        Id = npl.Id,
                        Name = npl.Name,
                        DateBirth = npl.DateBirth,
                        Height = npl.Height,
                        Weight = npl.Weight,
                        Dorsal = npl.Dorsal,
                        ImgProfile = npl.ImgProfile,
                        IsAlive = npl.IsAlive,
                        Points = npl.Points,
                        flag = flags.Where(fl => fl.Id == npl.Id_Flag).Select(nfl => new FlagDTO
                        {
                            Id = nfl.Id,
                            Name = nfl.Name,
                            ImgFlag = nfl.ImgFlag,
                        }).FirstOrDefault(new FlagDTO()),
                    }).ToList(),
                }).ToList();

                var apiResult = new ResponseApi<IEnumerable<TeamDTO>>
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
                var apiResult = new ResponseApi<IEnumerable<TeamDTO>>
                {
                    IsSucces = false,
                    StatusCode = 500,
                    Message = $"Error al obtener los datos: {ex.Message}",
                    Data = null
                };

                return apiResult;
            }
        }

        public async Task<ResponseApi<IEnumerable<PilotDTO>>> GetAll_Pilots_Async(CancellationToken cancellationToken)
        {
            try
            {
                var taskFlags = GetAllFlagsAsync(cancellationToken);
                var taskPilots = GetAllPilotsAsync(cancellationToken);
                var taskTeams = GetAllTeamsAsync(cancellationToken);

                await Task.WhenAll(taskFlags, taskPilots, taskTeams);

                var flags = await taskFlags;
                var pilots = await taskPilots;
                var teams = await taskTeams;

                var result = pilots.Select(npl => new PilotDTO
                {
                    Id = npl.Id,
                    Name = npl.Name,
                    DateBirth = npl.DateBirth,
                    Height = npl.Height,
                    Weight = npl.Weight,
                    Dorsal = npl.Dorsal,
                    ImgProfile = npl.ImgProfile,
                    IsAlive = npl.IsAlive,
                    Points = npl.Points,
                    flag = flags.Where(fl => fl.Id == npl.Id_Flag).Select(nfl => new FlagDTO
                    {
                        Id = nfl.Id,
                        Name = nfl.Name,
                        ImgFlag = nfl.ImgFlag,
                    }).FirstOrDefault(new FlagDTO()),
                    team = teams.Where(tm => tm.Id == npl.Id_Team).Select(ntm => new TeamDTO
                    {
                        Id = ntm.Id,
                        Name = ntm.Name,
                        ImgCar = ntm.ImgCar,
                        flag = flags.Where(fl => fl.Id == ntm.Id_Flag).Select(nfl => new FlagDTO
                        {
                            Id = nfl.Id,
                            Name = nfl.Name,
                            ImgFlag = nfl.ImgFlag,
                        }).FirstOrDefault(new FlagDTO()),
                    }).FirstOrDefault(new TeamDTO()),
                }).ToList();

                var apiResult = new ResponseApi<IEnumerable<PilotDTO>>
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
                var apiResult = new ResponseApi<IEnumerable<PilotDTO>>
                {
                    IsSucces = false,
                    StatusCode = 500,
                    Message = $"Error al obtener los datos: {ex.Message}",
                    Data = null
                };

                return apiResult;
            }
        }
        public async Task<ResponseApi<IEnumerable<CircuitDTO>>> GetAll_Circuits_Async(CancellationToken cancellationToken)
        {
            try
            {
                var taskFlags = GetAllFlagsAsync(cancellationToken);
                var taskCircuits = GetAllCircuitsAsync(cancellationToken);

                await Task.WhenAll(taskFlags, taskCircuits);

                var flags = await taskFlags;
                var circuits = await taskCircuits;

                var result = circuits.Select(nct => new CircuitDTO
                {
                    Id = nct.Id,
                    Name = nct.Name,
                    Flag = flags.Where(fl => fl.Id == nct.Id_Flag).Select(nfl => new FlagDTO
                    {
                        Id = nfl.Id,
                        Name = nfl.Name,
                        ImgFlag = nfl.ImgFlag,
                    }).FirstOrDefault(new FlagDTO()),
                }).ToList();

                var apiResult = new ResponseApi<IEnumerable<CircuitDTO>>
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
                var apiResult = new ResponseApi<IEnumerable<CircuitDTO>>
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
