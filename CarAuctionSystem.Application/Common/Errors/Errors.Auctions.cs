using ErrorOr;

namespace CarAuctionSystem.Application.Common.Errors;

public static partial class Errors
{
    public static class Auctions
    {
        public static Error NotFound =>
           Error.NotFound(
               code: "Auction.NotFound",
               description: "Auction not found.");

        public static Error ItemNotFound =>
          Error.NotFound(
              code: "Auction.ItemNotFound",
              description: "Auction item not found.");

        public static Error InvalidBid =>
         Error.Conflict(
             code: "Auction.InvalidBid",
             description: "Bid is invalid. Check item's starting bid value.");
    }
}
