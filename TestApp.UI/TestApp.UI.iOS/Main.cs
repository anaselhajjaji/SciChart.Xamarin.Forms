using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Foundation;
using UIKit;

namespace TestApp.UI.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            Debug.WriteLine("Im in your codes!");
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
