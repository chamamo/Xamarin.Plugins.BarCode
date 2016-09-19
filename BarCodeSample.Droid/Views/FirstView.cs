using Android.App;
using Android.OS;
using BarCodeSample.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace BarCodeSample.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }
    }
}