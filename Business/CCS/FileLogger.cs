﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CCS
{
    public class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Loged into file");
        }
    }

    public class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged into database");
        }
    }
}
