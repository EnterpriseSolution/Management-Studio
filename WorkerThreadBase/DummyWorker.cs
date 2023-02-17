#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  DummyWorker.cs 
// Date: 2015/08/19 14:13
// Reference: http://www.cnblogs.com/JamesLi2015
#endregion
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementStudio
{
    public class DummyWorker:WorkerThreadBase
    {
        protected override void Work()
        {
            //a relatively long task
            System.Threading.Thread.Sleep(10000);

            if (StopRequested)
            {
                return;
            }

            //a relatively long task
            System.Threading.Thread.Sleep(5000);

            Console.WriteLine("Dummy worker completed.");
        }
    }
}
