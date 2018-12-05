using Xamarin.Forms;
using FFImageLoading.Forms;

namespace Sample.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            mainImage1.CacheKeyFactory = new DefaultCacheFactory("image1");
        }
	}

    public class DefaultCacheFactory : ICacheKeyFactory
    {
        string _key;
        public DefaultCacheFactory(string key)
        {
            _key = key;
        }

        public string GetKey(ImageSource imageSource, object bindingContext)
        {
            return _key;
        }
    }
}

