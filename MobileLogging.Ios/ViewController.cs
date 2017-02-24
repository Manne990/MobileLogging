using System;
using MobileLogging.Common.Interface;
using MobileLogging.Ios.Log;
using UIKit;

namespace MobileLogging.Ios
{
    public partial class ViewController : UIViewController
    {
        private static IManneLogger logger = new NLogManager().GetLog();

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            logger.Trace("Trace!");
            logger.Debug("Debug!");
            logger.Info("Info!");
            logger.Warn("Warn!");
            logger.Error("Error!", "Error Message...");

            try
            {
                var i = 0;
                var j = 1 / i;

                System.Diagnostics.Debug.WriteLine(j);
            }
            catch(Exception ex)
            {
                logger.Fatal("Fatal!", ex.Message, ex);
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
