# CarAuctionSystem
Api for a Car Auction System

# Project
You can get the project here:
https://github.com/tpratas/CarAuctionSystem.git

You should see the swagger page just by running it.


# Assumptions
No UI and no Database are needed (contracts and stubs are there but just throws a not implemented exception)
No Authentication / Authorization

# Problem Modelling
I found it a bit hard to model, not only persistense but also models.
My approach was to have the vehicle types as different entities as I think it would be more clean and easy to evolve.
Also the require different validations due to different attributes.
A possibility would be to have DoorBased, SeatBased and LoadCapacityBased vehicle models, but in the future for sure you would end up mixing them.
Last approach in mind was to have a model with everything and a factory for validations.
Also thought on having a model with all attributes and maybe a factory to get the command but think it would get messier in the future.

As the structure changes a bit I would go for a document based DB appoach.
I used Clean Architecture and Mediatr just because I see the all system evolving in that way (bids, notification, payments, etc - Event Sourcing design)
Tried to: 
	- Have dependencies always pointing inward, 
	- Separation of technology details from the rest of the system
	- Respect the SOLID principles 
	- Single responsibility of each layer

# Future / Not addressed problems
- Concurrency (specially with the bids)
- Performance
	- Cache (Type, Manufacturer, Model)
	- SignalR
- Security
- Releability (Polly)
- Scalability
- Missing testing (validators, integration tests for api and persistence)
