#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  WorkerThreadBase.cs 
// Date: 2015/08/19 14:13
// Reference: http://www.cnblogs.com/JamesLi2015
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


//class Program
//{
//    private static CopyInfo _copyInfo;
//    static void Main(string[] args)
//    {
//        string srcFolder = @"E:\Emp5.0";
//        //_copyInfo = new CopyInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),  @"c:\pictures", true);
//        _copyInfo = new CopyInfo((srcFolder), @"c:\pictures", true);


//        //Thread simpleThread = new Thread(CopyFilesProc);
//        //simpleThread.Name = "CopyFiles";
//        //simpleThread.Start();
//        //simpleThread.Join();

//        //Thread parameterizedThread = new Thread(ParameterizedCopyFilesProc);
//        //parameterizedThread.Name = "CopyFiles";
//        //parameterizedThread.Start(_copyInfo);
//        //parameterizedThread.Join();

//        DummyWorker dummyWorker = new DummyWorker();
//        dummyWorker.Start();

//        CopyFileWorker copyFileWorker = new CopyFileWorker(_copyInfo);
//        copyFileWorker.Start();

//        //wait for the two threads to finish
//        WorkerThreadBase.WaitAll(copyFileWorker, dummyWorker);

//    }

//    static void CopyFilesProc()
//    {
//        CopyFiles(_copyInfo);
//    }

//    static void ParameterizedCopyFilesProc(object state)
//    {
//        if (state is CopyInfo)
//        {
//            CopyFiles(state as CopyInfo);
//        }
//    }

//    static void CopyFiles(CopyInfo copyInfo)
//    {
//        if (!Directory.Exists(copyInfo.Destination))
//        {
//            Directory.CreateDirectory(copyInfo.Destination);
//        }

//        Console.WriteLine("CopyFiles from '{0}' to '{1}' {2}...", copyInfo.Source, copyInfo.Destination, copyInfo.Recursive ? "recursive" : "non-recursive");

//        foreach (string file in Directory.GetFiles(copyInfo.Source))
//        {
//            string destination = Path.Combine(copyInfo.Destination,
//                Path.GetFileName(file));
//            //File.Copy(file, destination);
//            File.Copy(file, destination, true);
//        }

//        if (copyInfo.Recursive)
//        {
//            foreach (string directory in Directory.GetDirectories(copyInfo.Source))
//            {
//                string destination = Path.Combine(copyInfo.Destination, Path.GetFileName(directory)); //get the directory name for the path
//                CopyFiles(new CopyInfo(directory, destination, copyInfo.Recursive));
//            }
//        }

//        Console.WriteLine("CopyFiles finished.");
//    }
//}


//   class Program
//    {
//        static Thread t1 = new Thread(thread1);
//        static Thread t2 = new Thread(thread2);

//        public static void Main(string[] args)
//        {
//            t1.Start();
//            t2.Start();
//            t1.Join();
//        }

//        public static void thread1()
//        {
//            try
//            {
//                // Do our work here, for this test just look busy. 
//                while (true)
//                {
//                    Thread.Sleep(100);
//                }
//            }
//            finally
//            {
//                Console.WriteLine("We're exiting thread1 cleanly.\n");
//                // Do any cleanup that might be needed here. 
//            }
//        }

//        public static void thread2()
//        {
//            Thread.Sleep(500);
//            t1.Abort();
//        }
//    } 


//    public abstract class WorkerThreadBase : IDisposable
//    {
//        private Thread _workerThread;
//        protected internal ManualResetEvent _stopping;
//        protected internal ManualResetEvent _stopped;
//        private bool _disposed;
//        private bool _disposing;
//        private string _name;

//        protected WorkerThreadBase(): this(null, ThreadPriority.Normal)
//        {
//        }

//        protected WorkerThreadBase(string name) : this(name, ThreadPriority.Normal)
//        {
//        }

//        protected WorkerThreadBase(string name,ThreadPriority priority) : this(name, priority, false)
//        {
//        }

//        protected WorkerThreadBase(string name,ThreadPriority priority, bool isBackground)
//        {
//            _disposing = false;
//            _disposed = false;
//            _stopping = new ManualResetEvent(false);
//            _stopped = new ManualResetEvent(false);

//            _name = name == null ? GetType().Name : name; ;
//            _workerThread = new Thread(threadProc);
//            _workerThread.Name = _name;
//            _workerThread.Priority = priority;
//            _workerThread.IsBackground = isBackground;
//        }

//        protected bool StopRequested
//        {
//            get { return _stopping.WaitOne(1, true); }
//        }

//        protected bool Disposing
//        {
//            get { return _disposing; }
//        }

//        protected bool Disposed
//        {
//            get { return _disposed; }
//        }

//        public string Name
//        {
//            get { return _name; }
//        }

//        public void Start()
//        {
//            ThrowIfDisposedOrDisposing();
//            _workerThread.Start();
//        }

//        public void Stop()
//        {
//            ThrowIfDisposedOrDisposing();
//            _stopping.Set();
//            _stopped.WaitOne();
//        }

//        public void WaitForExit()
//        {
//            ThrowIfDisposedOrDisposing();
//            _stopped.WaitOne();
//        }

//        #region IDisposable Members

//        public void Dispose()
//        {
//            dispose(true);
//        }

//        #endregion

//        public static void WaitAll(params WorkerThreadBase[] threads)
//        {
//            WaitHandle.WaitAll(
//                Array.ConvertAll<WorkerThreadBase, WaitHandle>(
//                    threads,
//                    delegate(WorkerThreadBase workerThread)
//                    { return workerThread._stopped; }));
//        }

//        public static void WaitAny(params WorkerThreadBase[] threads)
//        {
//            WaitHandle.WaitAny(
//                Array.ConvertAll<WorkerThreadBase, WaitHandle>(
//                    threads,
//                    delegate(WorkerThreadBase workerThread)
//                    { return workerThread._stopped; }));
//        }

//        protected virtual void Dispose(bool disposing)
//        {
//            //stop the thread; 
//            Stop();

//            //make sure the thread joins the main thread 
//            _workerThread.Join(1000);

//            //dispose of the waithandles 
//            DisposeWaitHandle(_stopping);
//            DisposeWaitHandle(_stopped);
//        }

//        protected void ThrowIfDisposedOrDisposing()
//        {
//            if (_disposing)
//            {
//                throw new InvalidOperationException("Properties.Resources.ERROR_OBJECT_DISPOSING");
//            }

//            if (_disposed)
//            {
//                throw new ObjectDisposedException(GetType().Name,"Properties.Resources.ERROR_OBJECT_DISPOSED");
//            }
//        }

//        protected void DisposeWaitHandle(WaitHandle waitHandle)
//        {
//            if (waitHandle != null)
//            {
//                waitHandle.Close();
//                waitHandle = null;
//            }
//        }

//        protected abstract void Work();

//        private void dispose(bool disposing)
//        {
//            //do nothing if disposed more than once 
//            if (_disposed)
//            {
//                return;
//            }

//            if (disposing)
//            {
//                _disposing = disposing;

//                Dispose(disposing);

//                _disposing = false;
//                //mark as disposed 
//                _disposed = true;
//            }
//        }

//        private void threadProc()
//        {
//            Work();
//            _stopped.Set();
//        }
//    } 

//}

namespace ManagementStudio
{
    public abstract class WorkerThreadBase : IDisposable
    {
        private Thread _workerThread;
        private ManualResetEvent _stopping;
        private ManualResetEvent _stopped;
        private bool _disposed;
        private bool _disposing;

        protected WorkerThreadBase(): this(null, ThreadPriority.Normal)
        {
        }

        protected WorkerThreadBase(string name)  : this(name, ThreadPriority.Normal)
        {
        }

        protected WorkerThreadBase(string name, ThreadPriority priority) : this(name, priority, false)
        {
        }

        protected WorkerThreadBase(string name, ThreadPriority priority,bool isBackground)
        {
            _disposing = false;
            _disposed = false;
            _stopping = new ManualResetEvent(false);
            _stopped = new ManualResetEvent(false);

            _workerThread = new Thread(threadProc);
            _workerThread.Name = name == null ? GetType().Name : name;
            _workerThread.Priority = priority;
            _workerThread.IsBackground = isBackground;
        }

        protected bool StopRequested
        {
            get { return _stopping.WaitOne(1, true); }
        }

        public void Start()
        {
            ThrowIfDisposedOrDisposing();
            _workerThread.Start();
        }

        public void Stop()
        {
            ThrowIfDisposedOrDisposing();
            _stopping.Set();
            _stopped.WaitOne();
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

        public static void StartAndWaitAll(params WorkerThreadBase[] threads)
        { 
            WaitHandle.WaitAll(
                Array.ConvertAll<WorkerThreadBase, WaitHandle>(
                    threads,
                    delegate(WorkerThreadBase workerThread)
                    { return workerThread._stopped; }));
        }

        public static void WaitAny(params WorkerThreadBase[] threads)
        {
            WaitHandle.WaitAny(Array.ConvertAll<WorkerThreadBase, WaitHandle>(
                    threads,delegate(WorkerThreadBase workerThread)
                    { return workerThread._stopped; }));
        }

        protected virtual void Dispose(bool disposing)
        {
            //do nothing if disposed more than once
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _disposing = disposing;

                //stop the thread;
                Stop();

                //make sure the thread joins the main thread
                _workerThread.Join(1000);

                //dispose of the waithandles
                disposeWaitHandle(_stopping);
                disposeWaitHandle(_stopped);

                _disposing = false;
                //mark as disposed
                _disposed = true;
            }
        }

        protected void ThrowIfDisposedOrDisposing()
        {
            if (_disposing)
            {
                throw new InvalidOperationException(
                    "ERROR_OBJECT_DISPOSING");
            }

            if (_disposed)
            {
                throw new ObjectDisposedException(
                    GetType().Name,
                    "ERROR_OBJECT_DISPOSED");
            }
        }

        protected abstract void Work();

        private void threadProc()
        {
            Work();
            _stopped.Set();
        }

        private void disposeWaitHandle(WaitHandle waitHandle)
        {
            if (waitHandle != null)
            {
                waitHandle.Close();
                waitHandle = null;
            }
        }
    }
}