﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using System.Collections.ObjectModel;
using LeonaStore.Views.Home.ListingItem;
using Xamarin.Forms;
using System.Windows.Input;

namespace LeonaStore.ViewModels
	{
		public class ProductListingViewModel : BindableBase, INavigationAware
		{
			public string Title { get; set; }

			public Color BackgroundColor { get; set; }

			public ObservableCollection<ListingItem> Articles { get; set; }

			public ICommand RefreshListingCommand { get; set; }

			public ICommand ListingSelectedCommand { get; set; }

			public bool IsRefreshingListing { get; set; }

			readonly INavigationService _navigationService;

			public ProductListingViewModel(INavigationService navigationService)
			{
				_navigationService = navigationService;
				
				RefreshListingCommand = new Command(OnRefreshListing);

				ListingSelectedCommand = new Command(OnListingSelected);
			}

			async void OnListingSelected()
			{
				await _navigationService.NavigateAsync($"{Screens.ListingDetail}");
			}

			public void OnNavigatedFrom(NavigationParameters parameters)
			{
				
			}

			void OnRefreshListing()
			{
				IsRefreshingListing = false;
			}

			public void OnNavigatedTo(NavigationParameters parameters)
			{
				Title = "Leona Store";

				BackgroundColor = Color.FromHex("F5F5F5");

				Articles = new ObservableCollection<ListingItem>
				{
					new ListingItem()
					{
						ProductName = "Adidas R1",
						Price = new Price
						{
							Amount = 42.45,
							Currency = "USD"
						},
						ListingItemType = ListingItemType.Announcement,
						BrandCompany = "Adidas",
						BrandColor = Color.White,
						ProductBackground = "http://www.pngall.com/wp-content/uploads/2016/06/Adidas-Shoes-PNG-Picture.png"
					},
					new ListingItem()
					{
						ProductName = "Chuck II Rio",
						Price = new Price
						{
							Amount = 33.45,
							Currency = "USD"
						},
						ListingItemType = ListingItemType.Basic,
						BrandCompany = "Converse",
						BrandColor = Color.White,
						ProductBackground = "http://images2.nike.com/is/image/DotCom/PHN_PS/M7650_102_E_PREM/converse-chuck-taylor-all-star-high-top-unisex-shoe.png?fmt=png-alpha"
					},
					new ListingItem()
					{
						ProductName = "Nintendo Switch",
						Price = new Price
						{
							Amount = 299.99,
							Currency = "USD"
						},
						ListingItemType = ListingItemType.Basic,
						BrandCompany = "Nintendo",
						BrandColor = Color.White,
						ProductBackground = "http://vignette4.wikia.nocookie.net/fireemblem/images/4/42/Nintendo_Switch.png/revision/latest?cb=20170115150103"
					},
					new ListingItem()
					{
						ProductName = "iPhone 7",
						Price = new Price
						{
							Amount = 699.34,
							Currency = "USD"
						},
						ListingItemType = ListingItemType.Basic,
						BrandCompany = "Apple",
						BrandColor = Color.White,
						ProductBackground = "http://pngbase.com/content/Electronics/Iphone%20Apple/5396.png"
					},
					new ListingItem()
					{
						ProductName = "Macbook Pro 15'",
						Price = new Price
						{
							Amount = 1200.42,
							Currency = "USD"
						},
						ListingItemType = ListingItemType.Basic,
						BrandCompany = "Apple",
						BrandColor = Color.White,
						ProductBackground = "http://www.umbc.edu/bookstore-data/macbooksplash/images/MacBookPro_15inch_2.png"
					}
				};
			}

			public void OnNavigatingTo(NavigationParameters parameters)
			{
				
			}
		}
	}
