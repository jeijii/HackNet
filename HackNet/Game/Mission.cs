﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackNet.Game
{
    public class Mission
    {
        internal string IPaddress { get; set; }
        internal string Objective { get; set; }
        internal int numOfFirewall { get; set; }
        internal int numOfPorts { get; set; }

        public Mission()
        {

        }

        public List<string> scanMission(Mission mission)
        {
            List<string> scanList = new List<string>();
            scanList.Add("");




            return scanList;
        }
    }
}