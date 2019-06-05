using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ComponentModel;

namespace SendInject.Model
{
    /// <summary>
    /// プロセスリストを取得管理するクラス
    /// </summary>
    public class ProcessList 
    {
        public ObservableCollection<ProcessData> ProcessCollection { get; private set; } = new ObservableCollection<ProcessData>();

        public void GetProcessList()
        {
            ProcessCollection.Clear();

            Process[] plist = Process.GetProcesses();

            /// Process Data
            foreach(Process p in plist)
            {
                try
                {
                    var process = new ProcessData
                    {
                        ProcessName = p.ProcessName + ".exe",
                        ProcessId = p.Id,
                        FilePath = p.MainModule.FileName
                    };

                    ProcessCollection.Add(process);
                }
                catch (Win32Exception)
                {
                    continue;
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
            }
        }
    }
}
