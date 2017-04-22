﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeonaStore;
using LeonaStore.Domain;
using Refit;
using System.Linq;

namespace ListingServices
{
	public class ListingService : IListingService
	{
		IListingService _listingService;

		public ListingService()
		{
			_listingService = RestService.For<IListingService>(API.REST_Endpoint);
		}

		public async Task<List<ListingItem>> GetAllListings()
		{
			return await _listingService.GetAllListings();
		}

		public async Task<ListingItem> GetListing(string productId)
		{
			return await Task.Run(async() => {
				var listings = await _listingService.GetAllListings();

				return listings.FirstOrDefault(listing => listing.ProductName == productId);
			});
		}
	}
}
