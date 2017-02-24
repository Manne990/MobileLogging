using Android.App;
using Android.Widget;
using Android.OS;
using MobileLogging.Common.Interface;
using MobileLogging.Android.Log;
using System;

namespace MobileLogging.Android
{
    [Activity(Label = "MobileLogging", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private static IManneLogger logger = new NLogManager().GetLog();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate 
            {
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
                catch (Exception ex)
                {
                    logger.Fatal("Fatal!", ex.Message, ex);
                }
            };
        }
    }
}