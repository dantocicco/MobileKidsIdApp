using System;

namespace MobileKidsIdApp.Platform
{
    public interface IDownloader
    {
        void DownloadFile(string url, string folder);
        event EventHandler<DownloadEventArgs> OnFileDownloaded;
    }
}
