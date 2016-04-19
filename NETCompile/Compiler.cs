using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace NETCompile
{
    public class Compiler
    {
        public enum Target
        {
            DLL, EXE
        }

        public static void Compile(string asm, Target t)
        {
            //get the csc.exe location
            string frameworkPath = RuntimeEnvironment.GetRuntimeDirectory();
            string cscPath = Path.Combine(frameworkPath, "csc.exe");
            string targetOption = "";

            switch(t)
            {
                case Target.EXE:
                    targetOption = "exe";
                    break;
                case Target.DLL:
                    targetOption = "library";
                    break;
            }
        }
    }
}
