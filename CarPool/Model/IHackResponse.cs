using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class IHackResponse
    {
        HackResType ResType { get; }

        HackRspCode ResCode { get; }
        
        string ResDesc { get; }
       
        dynamic Body { get; set; }
    }
}
