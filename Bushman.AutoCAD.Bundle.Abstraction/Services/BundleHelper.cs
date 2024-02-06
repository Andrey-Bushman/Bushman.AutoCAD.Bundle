using Bushman.AutoCAD.Bundle.Abstraction.Models;
using System.Collections.Generic;

namespace Bushman.AutoCAD.Bundle.Abstraction.Services {
    public static class BundleHelper {

        private static readonly Dictionary<OS, IReadOnlyDictionary<BundleLocation, string>> _dict =
            new Dictionary<OS, IReadOnlyDictionary<BundleLocation, string>>();

        static BundleHelper() {

            var win32 = new Dictionary<BundleLocation, string>();
            _dict.Add(OS.Win32, win32);

            var win64 = new Dictionary<BundleLocation, string>();
            _dict.Add(OS.Win64, win64);

            var mac = new Dictionary<BundleLocation, string>();
            _dict.Add(OS.Mac, mac);

            foreach (var win in new[] { win32, win64, }) {
                win.Add(BundleLocation.GeneralInstallationFolder, @"%PROGRAMFILES%\Autodesk\ApplicationPlugins");
                win.Add(BundleLocation.AllUsersProfileFolder, @"%ALLUSERSPROFILE%\Autodesk\ApplicationPlugins");
                win.Add(BundleLocation.UserProfileFolder, @"%APPDATA%\Autodesk\ApplicationPlugins");
            }

            mac.Add(BundleLocation.GeneralInstallationFolder, @"/Applications/Autodesk/ApplicationAddins");
            mac.Add(BundleLocation.AllUsersProfileFolder, null);
            mac.Add(BundleLocation.UserProfileFolder, @"~/Library/Application Support/Autodesk/ApplicationAddins");
        }

        public static string GetBundlesLocation(OS os, BundleLocation location) {

            if (_dict.ContainsKey(os) && _dict[os].ContainsKey(location)) return _dict[os][location];
            else return null;
        }
    }
}
