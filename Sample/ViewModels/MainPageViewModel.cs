using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Reactive.Bindings;
using Xamarin.Forms;
using FFImageLoading.Forms;
using System.IO;
using System.Collections.ObjectModel;
using FFImageLoading;

namespace Sample.ViewModels
{
	public class MainPageViewModel : BindableBase
	{
        public ReactivePropertySlim<ImageSource> Image { get; } = new ReactivePropertySlim<ImageSource>();
        public ReactiveCommand UpdateCommand { get; } = new ReactiveCommand();

        public MainPageViewModel(IImageServiceEx imageServiceEx)
		{
            var image = ImageSource.FromStream(() =>
            {
                return this.GetType().Assembly.GetManifestResourceStream("Sample.Resources.icon.png");
            });

            Image.Value = image;

            UpdateCommand.Subscribe(async _ =>
            {

                await FFImageLoading.ImageService.Instance.InvalidateCacheEntryAsync("image1",FFImageLoading.Cache.CacheType.All,true);

                // HACK: delete reuse_pool cache 
                await imageServiceEx.ForceInvalidateCacheEntryAsync("image1", FFImageLoading.Cache.CacheType.All, true);

                var newImage = ImageSource.FromStream(() =>
                {
                    return this.GetType().Assembly.GetManifestResourceStream("Sample.Resources.icon2.png");
                });

                Image.Value = newImage;
            });
		}
        
	}


}

