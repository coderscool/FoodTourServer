using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Abstractions.Messages
{
    public interface IProjection
    {
        string Id { get; }
        long Version { get; }
    }

    public interface IPositionProjection : IProjection
    {
        GeoJsonPoint<GeoJson2DGeographicCoordinates> Location { get; }
    }
}
