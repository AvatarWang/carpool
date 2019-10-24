using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ScheduParam
    {
        public string userId { get; set; }
        public string startAddress { get; set; }
        public string endAddress { get; set; }
        public string startLat { get; set; }
        public string startLon { get; set; }
        public string endLat { get; set; }
        public string endLon { get; set; }
        public string startTime { get; set; }

        public string status { get; set; }

        public string count { get; set; }
        public string price { get; set; }
        public string type { get; set; }
        public string remark { get; set; }

    }
}
