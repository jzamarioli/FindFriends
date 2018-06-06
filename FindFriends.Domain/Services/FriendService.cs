using System;
using System.Collections.Generic;
using System.Linq;
using Common.Helpers;
using FindFriends.Domain.Entities;
using FindFriends.Domain.Interfaces.Repositories;
using FindFriends.Domain.Interfaces.Services;

namespace FindFriends.Domain.Services
{
    public class FriendService : ServiceBase<Friend>, IFriendService
    {
        private readonly IFriendRepository _friendRepository;
        private readonly ICalculateLogService _calculoHistoricoLogService;

        public FriendService(IFriendRepository friendRepository, ICalculateLogService calculoHistoricoLogService)
            : base(friendRepository)
        {
            _friendRepository = friendRepository;
            _calculoHistoricoLogService = calculoHistoricoLogService;
        }

        public void Add_CheckingDuplicatesLatitudeLongitude(Friend friend)
        {
            _friendRepository.Add_CheckingDuplicatesLatitudeLongitude(friend);
        }

        public IEnumerable<Friend> GetNearbyFriends(string friendname)
        {
            Friend friend = _friendRepository.FindByName(friendname);
            if (friend == null)
                return null;

            decimal latitudeAtual = friend.Latitude;
            decimal longitudeAtual = friend.Longitude;            
            decimal difLatitude, difLongitude, distancia;
            int lastSearchNumber;

            SortedDictionary<decimal, Friend> dctDistancias = new SortedDictionary<decimal, Friend>();
            
            foreach (Friend f in _friendRepository.GetAll())
            {
                difLatitude = MathHelper.HasSameSign(latitudeAtual, f.Latitude) ?
                    Math.Abs(Math.Abs(latitudeAtual) - Math.Abs(f.Latitude)) :
                    Math.Abs(latitudeAtual) + Math.Abs(f.Latitude);

                difLongitude = MathHelper.HasSameSign(longitudeAtual, f.Longitude) ?
                    Math.Abs(Math.Abs(longitudeAtual) - Math.Abs(f.Longitude)) :
                    Math.Abs(longitudeAtual) + Math.Abs(f.Longitude);

                distancia = difLatitude + difLongitude;
                if ((distancia) != 0)
                    dctDistancias.Add(distancia, f);
            }
            // Procura o nro da última busca
            lastSearchNumber = _calculoHistoricoLogService.GetNextSearchNumber();

            // Salva no BD o log da busca (todos os amigos, ordenados por proximidade)
            KeyValuePair<decimal, Friend> k;
            for (int i = 0; i < dctDistancias.Count; i++)
            {
                k = dctDistancias.ElementAt(i);
                _calculoHistoricoLogService.SaveLog(new CalculateLog
                {
                    SearchNumber = lastSearchNumber,
                    BaseFriendName = friend.Name,
                    NearbyFriendName = ((Friend)k.Value).Name,
                    Rank = i + 1,
                    Created = DateTime.Now
                });
            }

            // retorna os 3 amigos mais próximos do amigo escolhido
            return dctDistancias.Take(3).Select(f => f.Value);
        }
    }
}
