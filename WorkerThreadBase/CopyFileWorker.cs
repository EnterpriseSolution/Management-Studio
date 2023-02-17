#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  CopyFileWorker.cs 
// Date: 2015/08/19 14:13
// Reference: http://www.cnblogs.com/JamesLi2015
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ManagementStudio
{
    public class CopyFileWorker : WorkerThreadBase
    {
        private static CopyInfo _copyInfo;

        public CopyFileWorker(CopyInfo copyInfo)
        {
            _copyInfo = copyInfo;
        }

        protected override void Work()
        {
            copyFiles(_copyInfo);
        }

        private void copyFiles(CopyInfo copyInfo)
        {
        //check if the user called Stop
        if (StopRequested)
        {
            Console.WriteLine("User called Stop.");
            Console.WriteLine("Terminating thread while copying directory '{0}'.", copyInfo.Source);
            return;
        }

            if (!Directory.Exists(copyInfo.Destination))
            {
                Directory.CreateDirectory(copyInfo.Destination);
            }

            Console.WriteLine("CopyFiles from '{0}' to '{1}' {2}...",   copyInfo.Source,copyInfo.Destination, copyInfo.Recursive ? "recursive" : "non-recursive");

            foreach (string file in   Directory.GetFiles(copyInfo.Source))
            {
                string destination = Path.Combine(copyInfo.Destination,Path.GetFileName(file));
                File.Copy(file, destination);
            }

            if (copyInfo.Recursive)
            {
                foreach (string directory in  Directory.GetDirectories(copyInfo.Source))
                {
                    string destination = Path.Combine(copyInfo.Destination,Path.GetFileName(directory)); //get the directory name for the path               
                    copyFiles(new CopyInfo(directory,destination,copyInfo.Recursive));
                }
            }
            Console.WriteLine("CopyFiles finished.");
        }

    }
}
