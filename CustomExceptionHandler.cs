#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  CustomExceptionHandler.cs 
// Date: 2015/08/19 14:13
// Reference: http://www.cnblogs.com/JamesLi2015
#endregion
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace ManagementStudio
{
	/// <summary>
	/// Summary description for CustomExceptionHandler.
	/// </summary>
    internal sealed class CustomExceptionHandler
	{
		public bool IsDebug = false;
		
		public CustomExceptionHandler()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Handle the exception  event
		public void OnThreadException(object sender, ThreadExceptionEventArgs t)
		{
            if (IsDebug) Debug.Assert(false, t.Exception.Message, t.Exception.StackTrace);			
            
            DialogResult result = DialogResult.Cancel;
			try
			{
                result = this.ShowThreadExceptionDialog(t.Exception);
			}
			catch
			{
				try
				{
                    result = MessageBox.Show(string.Format("{0}\r\n\r\n{1}", t.Exception.Message, t.Exception.StackTrace), "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					Application.Exit();
				}
			}

			if (result == DialogResult.Abort) Application.Exit();
		}

		private DialogResult ShowThreadExceptionDialog(Exception e)
		{
			return DialogResult.Cancel;
		}
	}
}
