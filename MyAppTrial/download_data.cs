using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyAppTrial
{
    public class DownloadCompleteData : EventArgs
    {
        public String data { get; set; }
    }

    class download_data
    {

        public event EventHandler<DownloadCompleteData> downloadDatacomplete;

        public void get_data(String url)
        {
            DownloadDataAsync(url);
        }


        async void DownloadDataAsync(String url)
        {
            HttpClient client = new HttpClient();
            Task<string> getStringTask = client.GetStringAsync(url);
            string urlContents = await getStringTask;

            DownloadCompleteData data_to_send = new DownloadCompleteData();
            data_to_send.data = urlContents;

            DownloadDataCompleteEvent(data_to_send);

        }

        protected virtual void DownloadDataCompleteEvent(DownloadCompleteData e)
        {
            EventHandler<DownloadCompleteData> handler = downloadDatacomplete;
            if (handler != null)
            {
                handler(this, e);
            }
        }


    }
}
