#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  CopyInfo.cs 
// Date: 2015/08/19 14:13
// Reference: http://www.cnblogs.com/JamesLi2015
#endregion
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementStudio
{
    public class CopyInfo
    {
        private string _source;
        private bool _recursive;
        private string _destination;

        public CopyInfo(string source,string destination,bool recursive)
        {
            _source = source;
            _destination = destination;
            _recursive = recursive;
        }

        public string Source
        {
            get { return _source; }            
        }
        
        public string Destination
        {
            get { return _destination; }            
        }

        public bool Recursive
        {
            get { return _recursive; }            
        }
    }
}
