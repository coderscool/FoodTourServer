using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Contracts.Services.Account
{
    public static class Projection 
    {
        public record AccountDetails(string Id, string Name, string Image, string Phone, string Address, 
            GeoJsonPoint<GeoJson2DGeographicCoordinates> Location, List<string> Nation, long Version) : IProjection
        {
            public static implicit operator Protobuf.AccountDetails(AccountDetails account)
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
