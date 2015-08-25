using System;
using System.Collections.Specialized;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace Paperwallz
{
    class Imgur
    {
        private WebClient client;
        public string ClientID { get; private set; }
        private const string endPoint = "https://api.imgur.com/3/";

        public Imgur(string clientId)
        {
            ClientID = clientId;
            InitWebClient();
        }

        private void InitWebClient()
        {
            client = new WebClient { BaseAddress = endPoint };
            client.Headers[HttpRequestHeader.Authorization] = "Client-ID " + ClientID;
        }

        private static string ImageToBase64String(System.Drawing.Image image)
        {
            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            return Convert.ToBase64String(ms.ToArray());
        }

        public struct Image
        {
            public readonly string ID, Title, Description, Type, DeleteHash;
            public readonly int Width, Height, Size;
            public readonly DateTime UploadTime;
            public readonly Uri Link;

            public Image(string response)
            {
                var model = new JavaScriptSerializer().Deserialize<dynamic>(response);

                ID = model["data"]["id"];
                Title = model["data"]["title"];
                Description = model["data"]["description"];
                Type = model["data"]["type"];
                DeleteHash = model["data"]["deletehash"];
                Width = model["data"]["width"];
                Height = model["data"]["height"];
                Size = model["data"]["size"];
                UploadTime = new DateTime(1970, 1, 1).AddSeconds(model["data"]["datetime"]);
                Link = new Uri(model["data"]["link"]);
            }
        }

        private Image InternalUpload(object imageSource, bool url, string title, string description)
        {
            string response = null;

            try
            {
                var data = new NameValueCollection()
                {
                    {
                        "image", url ? (string)imageSource : ImageToBase64String((System.Drawing.Image)imageSource)
                    },
                    {
                        "title", title
                    },
                    {
                        "description", description
                    },
                    {
                        "type", url ? "URL" : "base64"
                    }
                };

                response = Encoding.ASCII.GetString(client.UploadValues("image", data));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }

            return new Image(response);
        }

        public Image Upload(System.Drawing.Image image, string title, string description)
        {
            return InternalUpload(image, false, title, description);
        }

        public Image Upload(string url, string title, string description)
        {
            return InternalUpload(url, true, title, description);
        }

        public static bool operator ==(Imgur a, Imgur b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (((object)a == null) || ((object)b == null))
                return false;

            return a.ClientID == b.ClientID;
        }

        public static bool operator !=(Imgur a, Imgur b)
        {
            return !(a == b);
        }

    }
}