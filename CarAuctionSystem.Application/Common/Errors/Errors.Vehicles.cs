using ErrorOr;

namespace CarAuctionSystem.Application.Common.Errors;

public static partial class Errors
{
    public static class Vehicles
    {
        public static Error DuplicateId =>
            Error.Conflict(
                code: "Vehicle.DuplicateId",
                description: "Id already exists.");

        public static Error NotFound =>
           Error.NotFound(
               code: "Vehicle.NotFound",
               description: "Vehicle not found.");

        public static Error AlreadyInAuction =>
           Error.Conflict(
               code: "Vehicle.AlreadyInAuction",
               description: "Vehicle already in auction.");
    }
}
