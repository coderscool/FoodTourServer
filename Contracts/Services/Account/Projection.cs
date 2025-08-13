using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Contracts.Services.Account
{
    public static class Projection 
    {
        public record AccountUser(string Id, string Name, string Image, long Version) : IProjection
        {
            public static implicit operator Protobuf.AccountUserDetail(AccountUser account)
                => new()
                {
                    Id = account.Id,
                    Name = account.Name,
                    Image = account.Image
                };
        }
        public record AccountSeller(string Id, Dto.DtoPerson Seller, string Image, GeoJsonPoint<GeoJson2DGeographicCoordinates> Location, 
            string Nation, Dto.TimeActive TimeActive, bool Status, long Version) : IPositionProjection
        {
            public static implicit operator Protobuf.AccountSellerDetail(AccountSeller account)
                => new()
                {
                    Id = account.Id,
                    Seller = account.Seller,
                    Image = account.Image,
                    Nation = account.Nation,
                    TimeActive = account.TimeActive,
                    Status = account.Status,
                };
        }
        public record AccountShipper(string Id, Dto.DtoPerson Shipper, string Image, long Version) : IProjection
        {
            public static implicit operator Protobuf.AccountShipperDetail(AccountShipper account)
                => new()
                {
                    Id = account.Id,
                    Shipper = account.Shipper,
                    Image = account.Image
                };
        }
        public record AccountSellerES(string Id, string Name, string Address, string Image, string Nation, long Version) : IProjection
        {
            public static implicit operator AccountSellerES(AccountSeller account)
                => new(account.Id, account.Seller.Name, account.Seller.Address.Address, account.Image, account.Nation, account.Version);

            public static implicit operator Protobuf.AccountSellerESDetail(AccountSellerES account)
                => new()
                {
                    Id = account.Id,
                    Name = account.Name,
                    Address = account.Address,
                    Image = account.Image,
                    Nation = account.Nation
                };
        }
    }
}
