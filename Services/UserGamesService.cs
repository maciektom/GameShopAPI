using AutoMapper;
using InternetGameShopAPI.Domain.UserAggregate;
using InternetGameShopAPI.Infrastructure;
using InternetGameShopAPI.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace InternetGameShopAPI.Services
{
    public class UserGamesService : IUserGamesService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserGamesUoW _userGamesUoW;
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        public UserGamesService(IUserRepository userRepository, IGameRepository gameRepository,IMapper mapper, IUserGamesUoW userGamesUoW)
        {
            _userRepository = userRepository;
            _userGamesUoW = userGamesUoW;
            _gameRepository = gameRepository;
            _mapper = mapper;
        }
        public async Task<UserGame> AddGameToUser(Guid userId, Guid gameId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new NotImplementedException("User not found.");
            }
            
            var game = await _gameRepository.GetGameById(gameId);
            if (game == null)
            {
                throw new NotImplementedException("Game not found.");
            }
            var userGame = _mapper.Map<UserGame>(game);
            userGame.User_id = userId;
            userGame.Game_id = gameId;

            //var games = user.GamesOwned.Count();
            //    if (games >= 1)
            //    {
            //    throw new Exception("User already owns this game."); 
            //    };

            user.UserGames.Add(userGame);

            await _userGamesUoW.DoWork(userGame);
            
            return userGame;
        }
    }
}
