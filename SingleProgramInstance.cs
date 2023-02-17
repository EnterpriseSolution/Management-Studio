#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  SingleProgramInstance.cs 
// Date: 2015/08/19 14:13
// Reference: http://www.cnblogs.com/JamesLi2015
#endregion
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Reflection;

namespace ManagementStudio
{
	//SingleProgamInstance uses a mutex synchronization object
	// to ensure that only one copy of process is running at
	// a particular time.  It also allows for UI identification
	// of the intial process by bring that window to the foreground.
	internal sealed class SingleProgramInstance : IDisposable
	{

		//Win32 API calls necesary to raise an unowned processs main window
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1414:MarkBooleanPInvokeArgumentsWithMarshalAs"), DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1414:MarkBooleanPInvokeArgumentsWithMarshalAs"), DllImport("user32.dll")]
		private static extern bool ShowWindowAsync(IntPtr hWnd,int nCmdShow);
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1414:MarkBooleanPInvokeArgumentsWithMarshalAs"), DllImport("user32.dll")]
		private static extern bool IsIconic(IntPtr hWnd);

		private const int SW_HIDE = 0;
		private const int SW_SHOWNORMAL = 1;
		private const int SW_NORMAL = 1;
		private const int SW_SHOWMINIMIZED = 2;
		private const int SW_SHOWMAXIMIZED = 3;
		private const int SW_MAXIMIZE = 3;
		private const int SW_SHOWNOACTIVATE = 4;
		private const int SW_SHOW = 5;
		private const int SW_MINIMIZE = 6;
		private const int SW_SHOWMINNOACTIVE = 7;
		private const int SW_SHOWNA = 8;
		private const int SW_RESTORE = 9;
		private const int SW_SHOWDEFAULT = 10;
		private const int SW_FORCEMINIMIZE = 11;
		private const int SW_MAX = 11;

		//private members
		private Mutex _processSync;
		private bool _owned;

		public SingleProgramInstance()
		{
			//Initialize a named mutex and attempt to
			// get ownership immediatly
			_processSync = new Mutex(
				true, // desire intial ownership
				Assembly.GetExecutingAssembly().GetName().Name,
				out _owned);
		}

		public SingleProgramInstance(string identifier)
		{
			//Initialize a named mutex and attempt to
			// get ownership immediately.
			//Use an addtional identifier to lower
			// our chances of another process creating
			// a mutex with the same name.
			_processSync = new Mutex(
				true, // desire intial ownership
				Assembly.GetExecutingAssembly().GetName().Name + identifier,
				out _owned);
		}

		~SingleProgramInstance()
		{
			//Release mutex (if necessary)
			//This should have been accomplished using Dispose()
			Release();
		}

		public bool IsSingleInstance
		{
			//If we don't own the mutex than
			// we are not the first instance.
			get {return	_owned;}
		}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public void RaiseOtherProcess()
		{
            try
            {
                Process proc = Process.GetCurrentProcess();
                // Using Process.ProcessName does not function properly when
                // the name exceeds 15 characters. Using the assembly name
                // takes care of this problem and is more accruate than other
                // work arounds.
                //string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                string assemblyName = Assembly.GetEntryAssembly().GetName().Name;
                foreach (Process otherProc in Process.GetProcessesByName(assemblyName))
                {
                    //ignore this process
                    if (proc.Id != otherProc.Id)
                    {
                        // Found a "same named process".
                        // Assume it is the one we want brought to the foreground.
                        // Use the Win32 API to bring it to the foreground.
                        IntPtr hWnd = otherProc.MainWindowHandle;
                        if (IsIconic(hWnd))
                        {
                            ShowWindowAsync(hWnd, SW_RESTORE);
                        }
                        SetForegroundWindow(hWnd);
                        return;
                    }
                }
            }
            catch
            {
            }
		}

        public void KillProcess()
        {
            try
            {
                Process proc = Process.GetCurrentProcess();
                // Using Process.ProcessName does not function properly when
                // the name exceeds 15 characters. Using the assembly name
                // takes care of this problem and is more accruate than other
                // work arounds.
                //string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                string assemblyName = Assembly.GetEntryAssembly().GetName().Name;
                foreach (Process otherProc in Process.GetProcessesByName(assemblyName))
                {
                    //ignore this process
                    if (proc.Id != otherProc.Id)
                    {
                        // Found a "same named process".
                        otherProc.Kill();
                        otherProc.Close();
                        otherProc.Dispose();
                        return;
                    }
                }
            }
            catch
            {
            }
        }

		private void Release()
		{
			if (_owned)
			{
				//If we owne the mutex than release it so that
				// other "same" processes can now start.
				_processSync.ReleaseMutex();
				_owned = false;
			}
		}

	#region Implementation of IDisposable
		public void Dispose()
		{
			//release mutex (if necessary) and notify
			// the garbage collector to ignore the destructor
            Release();
            ((IDisposable)this._processSync).Dispose();
			GC.SuppressFinalize(this);
		}
	#endregion
	}
}

