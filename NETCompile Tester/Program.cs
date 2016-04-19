using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NETCompile;

namespace NETCompile_Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Compiler1.Compile("HelloWorld.exe", Compiler1.Target.EXE, Compiler1.Platform.x86, new string[] { "",""}, new string[] { "", "" }, false, @"C:\Users\Luca\Desktop\helloworld.cs", Compiler1.Language.CSharp);
        }
    }
}
