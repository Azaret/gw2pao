using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GW2PAO.ViewModels;
using GW2PAO.Views;
using NLog;

namespace GW2PAO.Utility
{
    public static class UpdateChecker
    {
        /// <summary>
        /// Default logger
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Runs a check for a new update and notifies the user if a new version is available.
        /// With the exception of notifying the user, this is performed on a seperate thread
        /// </summary>
        public static void CheckForUpdateAndNotify()
        {
            Task.Factory.StartNew(async () =>
                {
                    logger.Info("Checking for new version");

                    Version latestVersion = await GetLatestVersion();

                    // Get the assembly version and compare
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                    Version myVersion = new Version(fvi.ProductVersion);

                    if (latestVersion > myVersion)
                    {
                        logger.Info("New version available: {0}", latestVersion);

                        // Notify the user
                        Threading.BeginInvokeOnUI(() =>
                            new NewVersionNotificationView(new NewVersionNotificationViewModel(latestVersion.ToString(2))).Show());
                    }
                    else
                    {
                        logger.Info("No new version available");
                    }
                });
        }

        private static Task<string> DownloadVersion()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"https://raw.githubusercontent.com/SamHurne/gw2pao/master/latest_version.txt");
                return client.GetStringAsync("");
            }
        }

        /// <summary>
        /// Synchronous check to retrieve the version of the latest released of the software
        /// Based on http://www.hanselman.com/blog/HowToAutomaticallyNotifyTheUserThatItsTimeToUpgradeAWindowsApp.aspx
        /// </summary>
        /// <returns>The version of the latest release</returns>
        private static async Task<Version> GetLatestVersion()
        {
            var versionString = await DownloadVersion();
            if (!string.IsNullOrWhiteSpace(versionString))
            {
                return new Version(versionString);
            }
            else
            {
                return new Version();
            }
        }
    }
}
