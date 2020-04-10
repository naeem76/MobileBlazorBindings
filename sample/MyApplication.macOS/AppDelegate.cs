﻿using AppKit;
using Foundation;

namespace MyApplication.macOS
{
    [Register("AppDelegate")]
    public class AppDelegate : Xamarin.Forms.Platform.MacOS.FormsApplicationDelegate
    {
        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;
            var rect = new CoreGraphics.CGRect(200, 1000, 1024, 768);
            MainWindow = new NSWindow(rect, style, NSBackingStore.Buffered, false)
            {
                Title = "My Application",
                TitleVisibility = NSWindowTitleVisibility.Visible,
            };
        }

        public override NSWindow MainWindow { get; }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Not sure this should really be here, but it's useful for being able to cmd+q at this stage of development
            NSApplication.SharedApplication.MainMenu = MakeMainMenu();

            Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            base.DidFinishLaunching(notification);
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }

        private NSMenu MakeMainMenu()
        {
            // top bar app menu
            NSMenu menubar = new NSMenu();
            NSMenuItem appMenuItem = new NSMenuItem();
            menubar.AddItem(appMenuItem);

            NSMenu appMenu = new NSMenu();
            appMenuItem.Submenu = appMenu;

            // add separator
            NSMenuItem separator = NSMenuItem.SeparatorItem;
            appMenu.AddItem(separator);

            // add quit menu item
            string quitTitle = string.Format("Quit {0}", "MyApplication.macOS");
            var quitMenuItem = new NSMenuItem(quitTitle, "q", delegate
            {
                NSApplication.SharedApplication.Terminate(menubar);
            });
            appMenu.AddItem(quitMenuItem);

            return menubar;
        }
    }
}
