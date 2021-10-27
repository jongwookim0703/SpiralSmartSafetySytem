using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;

namespace testestestsettest
{
    public class Common
    {
        public static string LogInId = string.Empty;
        public static string LogInName = string.Empty;
        public static string DbPath = "Data Source=hangaramit.iptime.org; Initial Catalog=SpiralDB;User ID=spa;Password=spiral_0904";

        public static int ProcessNo = 0;

        public static MqttClient Client;
    }
}

