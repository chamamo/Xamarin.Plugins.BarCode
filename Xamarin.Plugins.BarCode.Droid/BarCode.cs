using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Nio;
using Xamarin.Plugins.BarCode.Abstractions;
using ZXing;
using ZXing.Common;
using ZXing.Mobile;
using Stream = Android.Media.Stream;

namespace Xamarin.Plugins.BarCode
{
    public class BarCode : BarCodeBase, IBarCode
    {
        public BarCode()
        {
            var def = ZXing.Mobile.MobileBarcodeScanningOptions.Default;

            BarCodeReadConfiguration.Default = new BarCodeReadConfiguration
            {
                AutoRotate = def.AutoRotate,
                CharacterSet = def.CharacterSet,
                DelayBetweenAnalyzingFrames = def.DelayBetweenAnalyzingFrames,
                InitialDelayBeforeAnalyzingFrames = def.InitialDelayBeforeAnalyzingFrames,
                PureBarcode = def.PureBarcode,
                TryHarder = def.TryHarder,
                TryInverted = def.TryInverted,
                UseFrontCameraIfAvailable = def.UseFrontCameraIfAvailable
            };
        }
       

        public async Task<BarCodeResult> ReadAsync(BarCodeReadConfiguration config = null, CancellationToken cancelToken = new CancellationToken())
        {
            var scanner = new MobileBarcodeScanner() { UseCustomOverlay = false };
            cancelToken.Register(scanner.Cancel);
            config = config ?? BarCodeReadConfiguration.Default;
            var result = await scanner.Scan(this.GetXingConfig(config));
            return (String.IsNullOrWhiteSpace(result?.Text)
                ? BarCodeResult.Fail
                : new BarCodeResult(result.Text, FromXingFormat(result.BarcodeFormat))
            );
        }

        protected static BarCodeFormat FromXingFormat(ZXing.BarcodeFormat format)
        {
            return (BarCodeFormat)Enum.Parse(typeof(BarCodeFormat), format.ToString());
        }


        private MobileBarcodeScanningOptions GetXingConfig(BarCodeReadConfiguration cfg)
        {
            var opts = new MobileBarcodeScanningOptions
            {
                AutoRotate = cfg.AutoRotate,
                CharacterSet = cfg.CharacterSet,
                DelayBetweenAnalyzingFrames = cfg.DelayBetweenAnalyzingFrames,
                InitialDelayBeforeAnalyzingFrames = cfg.InitialDelayBeforeAnalyzingFrames,
                PureBarcode = cfg.PureBarcode,
                TryHarder = cfg.TryHarder,
                TryInverted = cfg.TryInverted,
                UseFrontCameraIfAvailable = cfg.UseFrontCameraIfAvailable
            };

            if (cfg.Formats != null && cfg.Formats.Count > 0)
            {
                opts.PossibleFormats = cfg.Formats
                    .Select(x => (BarcodeFormat)(int)x)
                    .ToList();
            }
            return opts;
        }
    }
}