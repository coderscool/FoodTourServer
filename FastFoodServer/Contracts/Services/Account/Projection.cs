using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using MongoDB.Driver.GeoJsonObjectModel;
using Newtonsoft.Json;

namespace Contracts.Services.Account
{
    public static class Projection 
    {
        public record Account(string Id, string Name, string Image, string Phone, string Address,
            GeoJsonPoint<GeoJson2DGeographicCoordinates> Location, List<string> Nation, long Version) : IPositionProjection
        {
            public static implicit operator Protobuf.AccountDetails(Account account)
                => new()
                {
                    Id = account.Id,
                    Name = account.Name,
                    Image = account.Image,
                    Phone = account.Phone,
                    Address = account.Address
                };
        }

        public record AccountES(string Id, string Name, string Image, string Phone, string Address,
             List<string> Nation, long Version) : IProjection
        {
            public static implicit operator AccountES(Account account)
                => new(account.Id, account.Name, account.Image, account.Phone, account.Address, account.Nation, account.Version);

            public static implicit operator Protobuf.AccountDetails(AccountES account)
                => new()
                {
                    Id = account.Id,
                    Name = account.Name,
                    Image = account.Image,
                    Phone = account.Phone,
                    Address = account.Address
                };
        }
    }
}
