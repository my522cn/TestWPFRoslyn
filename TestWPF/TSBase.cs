using System;

namespace TestWPF
{
    public class TSBase
    {
        public string Logger { get; set; }
        public bool PanelResult { get; set; }

        public (bool result, string log) Test(string testname)
        {
            Logger += $"{testname} test passed (B)";
            return (true, $"{testname} test passed");
        }

        public virtual void Run()
        {
            Logger = "Test Sequence is null";
        }
    }
}

