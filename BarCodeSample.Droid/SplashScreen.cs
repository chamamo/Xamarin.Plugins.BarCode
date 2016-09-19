using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace BarCodeSample.Droid
{
    [Activity(
		Label = "BarCodeSample.Droid"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Unspecified)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}