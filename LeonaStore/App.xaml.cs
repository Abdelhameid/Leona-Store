﻿using Prism.Unity;
using LeonaStore.Views;
using Xamarin.Forms;
using Prism.Navigation;
using Microsoft.Practices.Unity;
using LeonaStore.Views.Home;
using Like.ViewModels;
using ListingServices;
using ViewModels.ViewModels;
using LeonaStore.Views.NotReadyYet;

namespace LeonaStore
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();
             
            var screen = Device.RuntimePlatform == Device.Android ? Screens.SplashPage : Screens.NotReadyYetPage;
            
			NavigationService.NavigateAsync($"{screen}");
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MasterDetailContainer>();
			Container.RegisterTypeForNavigation<LeonaNavigationPage>();
			Container.RegisterTypeForNavigation<SplashPage>();
			Container.RegisterTypeForNavigation<LandingContentPage>();
			Container.RegisterTypeForNavigation<ProductListing>();
			Container.RegisterTypeForNavigation<ListingDetail>();
			Container.RegisterTypeForNavigation<SearchPage>();
			Container.RegisterTypeForNavigation<MoreApps>();
            Container.RegisterTypeForNavigation<NotReadyYetPage>();
			Container.RegisterType<LikeViewModel>();
			Container.RegisterType<AppDrawerViewModel>();

			Container.RegisterType(typeof(ICache), typeof(AkavacheImpl));
			Container.RegisterType(typeof(IListingService), typeof(ListingService));
		}
	}
}