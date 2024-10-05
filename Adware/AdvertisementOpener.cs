using System.Collections.Generic;
using System.Diagnostics;

namespace Adware
{
    public class AdvertisementOpener
    {
        readonly Dictionary<string, string> pageTitleParts;

        public AdvertisementOpener(Dictionary<string, string> pageTitleParts)
        {
            this.pageTitleParts = pageTitleParts;
        }

        public bool OpenUnwantedAdvertisements()
        {
            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                foreach (var pageTitlePart in pageTitleParts)
                {
                    var lowerCaseTitle = process.MainWindowTitle.ToLower();
                    if (lowerCaseTitle.Contains(pageTitlePart.Key))
                    {
                        Process.Start(pageTitlePart.Value);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
