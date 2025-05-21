using System.Diagnostics;

namespace DelegateDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine("Hello, World!");
            //client Developer 1 : all process list
            ProcessManager processManager = new ProcessManager();
            //  processManager.ShowProcessList();
          //  processManager.ShowProcessList(NoFilter);
          processManager.ShowProcessList(p=> true);
            //client Developer 2 : start with S

            FilterDelegate filter = new FilterDelegate(FilterByNames);
            processManager.ShowProcessList(filter);
            //processManager.ShowProcessList("S");

            //client Developer 3 
            // processManager.ShowProcessList(100*1024*1024);
          //  filter = new FilterDelegate(FilterBySize);
            processManager.ShowProcessList(FilterBySize);

            // Anonymous Delegate

            processManager.ShowProcessList(delegate { return true; });

            processManager.ShowProcessList(delegate (Process process) { return process.ProcessName.StartsWith("S"); });

            processManager.ShowProcessList(delegate (Process process) { return process.WorkingSet64 >= 100 * 1024 * 1024; });

            // Lambda statement : Anonymous Method

            processManager.ShowProcessList((Process process) => { return process.ProcessName.StartsWith("S"); });

            //Anonymous delegate => Lambda statement => Lambda Expression

            processManager.ShowProcessList(p => 
             p.ProcessName.StartsWith("S")
            );
            processManager.ShowProcessList(p =>
            p.WorkingSet64 >= 100 * 1024 * 1024
           );

        }

        //client 1

        //commented for using Anonymous Delegate
        //public static bool NoFilter(Process process)
        //{
        //    return true;
        //}

        // client 2

        public static bool FilterByNames(Process process)
        {
            if(process.ProcessName.StartsWith("S"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //client 3

        public static bool FilterBySize(Process process)
        {
            return process.WorkingSet64 >= 100 * 1024 * 1024;
            
             
        }

    }



    //dev1

    // declare

    public delegate bool FilterDelegate(Process process);


    class ProcessManager // OCP : Open for extension, closed for modification
    {
        //public void ShowProcessList()
        //{
        //    foreach (var process in Process.GetProcesses())
        //    {
        //        Console.WriteLine(process.ProcessName);
        //    }

        //}

        //public void ShowProcessList(string startWith)
        //{
        //    foreach (var process in Process.GetProcesses())
        //    {
        //        if (process.ProcessName.StartsWith(startWith))
        //        {
        //            Console.WriteLine(process.ProcessName);
        //        }

        //    }

        //}
        //public void ShowProcessList(long size)
        //{
        //    foreach (var process in Process.GetProcesses())
        //    {
        //        if (process.WorkingSet64>=size)
        //        {
        //            Console.WriteLine(process.ProcessName);
        //        }
        //    }
        //}

        public void ShowProcessList(FilterDelegate filter)
        {
            foreach (var process in Process.GetProcesses())
            {
                if (filter(process))
                {
                    Console.WriteLine(process.ProcessName);
                }

            }

        }

    }
}
