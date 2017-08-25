﻿using Prism.Mvvm;
using System;
using Prism.Navigation;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace LeonaStore.ViewModels
{
	public class SplashPageViewModel : BindableBase, INavigationAware
	{
		readonly INavigationService _navigationSevice;
		readonly ICache _cache;

		public SplashPageViewModel(INavigationService navigationService, ICache cache)
		{
			_cache = cache;

			_navigationSevice = navigationService;
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		public async void OnNavigatedTo(NavigationParameters parameters)
		{
			await Task.Delay(TimeSpan.FromSeconds(2));

			var isNotFirstTimeUser = await _cache.GetObjectAsync<bool>(CacheKeys.NewUserKey);

			if (isNotFirstTimeUser)
				await _navigationSevice.NavigateAsync(new Uri($"{Screens.AbsoluteURI}/MasterDetailContainer/NavigationPage/{Screens.ProductListing}", UriKind.Absolute));
			else
				await _navigationSevice.NavigateAsync(new Uri($"{Screens.AbsoluteURI}/{Screens.LandingContentPage}", UriKind.Absolute));
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{

		}
	}
}
