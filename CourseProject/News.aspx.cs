using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CourseProject
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "http://api.avatardata.cn/ActNews/Query?key=c713702248004e0daf0e4dc5b1bfc373&keyword=BlackPink";
            HttpWebRequest request = null;
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream s = response.GetResponseStream();
            StreamReader reader = new StreamReader(s, Encoding.UTF8);
            string result = reader.ReadToEnd();
            Rootobj result_json = JsonConvert.DeserializeObject<Rootobj>(result);
            for (int i = 0; i < result_json.result.Count; i++)
            {
                //Response.Write(result_json.result[i].img + "<br/>");
                if (result_json.result[i].img.Length < 4)
                {

                    result_json.result[i].img = "img/noc_group_1.jpg";
                }
            }
            DataList1.DataSource = result_json.result;
            DataList1.DataBind();
        }

        public class NewsItem
        {
            public string title { get; set; }

            public string content { get; set; }

            public string img_width { get; set; }

            public string full_title { set; get; }
            public string pdate { set; get; }
            public string src{ set; get; }

            public string img_length { set; get; }

            public string img { set; get; }

            public string url { set; get; }
            public string pdate_src { set; get; }


        }

        public class Rootobj
        {
            public List<NewsItem> result { get; set; }
        }
    }
}