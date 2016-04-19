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
            Console.WriteLine("Testing with C#5");
            Compiler1.Compile("HelloWorld.exe", Compiler1.Target.EXE, Compiler1.Platform.x86, new string[] { "",""}, new string[] { "", "" }, false, @"C:\Users\ion\Desktop\helloworld.cs", Compiler1.Language.CSharp);
            Console.WriteLine("Testing with C#6");
            Compiler2.Compile("HelloWorld.exe", Compiler2.Target.EXE, Compiler2.Platform.x86, new string[] { "", "" }, new string[] { "", "" }, false, @"C:\Users\ion\Desktop\helloworld.cs", Compiler2.Language.CSharp);
        }
    }
}
