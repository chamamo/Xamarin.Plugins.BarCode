using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Xamarin.Plugins.BarCode;
using Xamarin.Plugins.BarCode.Abstractions;

namespace BarCodeSample.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {

        public FirstViewModel()
        {
        }
        

        public ICommand ScanCommand => new MvxCommand(async () =>
        {
            try
            {
                var result = await CrossBarCode.Current.ReadAsync();
                if (result.Success) Text = result.Code;
            }
            catch(Exception ex)
            {
                
            }
        });

        private string _text;

        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
    }
}
