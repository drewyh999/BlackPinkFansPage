using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseProject
{
    public partial class Nocturnal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            weatherservice.WeatherWebService weather = new weatherservice.WeatherWebService();
           
            String[] SoulWeather;
            SoulWeather = weather.getWeatherbyCityName("首尔");

            //String weather_brief_peking = PekingWeatherdata[10];
            String weather_brief_soul = SoulWeather[10];
           // String temperature_peking = PekingWeatherdata[5];
            String temperature_soul = SoulWeather[5];

           // String peking_img_name = PekingWeatherdata[9];
            String soul_img_name = SoulWeather[9];
            Console.WriteLine(SoulWeather);
            label_soul.Text = "首尔天气：" + temperature_soul;
           

            soul_weather_img.ImageUrl = "~/img/" + soul_img_name;

            if (!IsPostBack)
            {

                if (Request.Cookies["userphone"] != null)
                {
                    container_chart.Visible = true;
                }
                else
                {
                    container_chart.Visible = false;

                }


            }


        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void register_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }
    }
}