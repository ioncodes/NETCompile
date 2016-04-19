using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace NETCompile
{
    public class Compiler1  //for CSharp5 use Roslyn for CSharp6
    {
        public enum Target
        {
            DLL,
            EXE
        }

        public enum Platform
        {
            x86,
            x64
        }

        public enum Language
        {
            CSharp,
            VB
        }

        public static void Compile(string asmName, Target t, Platform p, string[] pathToReferences, string[] pathToRessources, bool allowUnsafeCode, string sourcePath, Language l)
        {
            //get the csc.exe location
            string frameworkPath = RuntimeEnvironment.GetRuntimeDirectory();
            string cscPath = "";
            string targetOption = "";
            string platformOption = "";
            string references = "";
            string ressources = "";

            string preAsm = " /out:";
            string preTarget = " /t:";
            string prePlatform = " /platform:";
            string preRef = " /r:";
            string preRes = " /res:";
            string preAllowUnsafe = " /unsafe";

            switch(t)
            {
                case Target.EXE:
                    targetOption = "exe";
                    break;
                case Target.DLL:
                    targetOption = "library";
                    break;
            }

            switch (p)
            {
                case Platform.x86:
                    platformOption = "x86";
                    break;
                case Platform.x64:
                    platformOption = "x64";
                    break;
            }

            switch (l)
            {
                case Language.CSharp:
                    cscPath = Path.Combine(frameworkPath, "csc.exe");
                    break;
                case Language.VB:
                    cscPath = Path.Combine(frameworkPath, "vbc.exe");
                    break;
            }

            if (pathToReferences[0] == "")
            {
                preRef = " "; //no references
            }
            else
            {
                foreach(string line in pathToReferences)
                {
                    if (line == pathToReferences[pathToReferences.Count() - 1])
                    {
                        references += line;
                    }
                    else
                    {
                        references += line + ",";
                    }
                }
            }

            if (pathToRessources[0] == "")
            {
                preRes = " "; //no ressources
            }
            else
            {
                foreach (string line in pathToRessources)
                {
                    if (line == pathToRessources[pathToRessources.Count() - 1])
                    {
                        ressources += line;
                    }
                    else
                    {
                        ressources += line + ",";
                    }
                }
            }

            if(allowUnsafeCode)
            {
                preAllowUnsafe += "+";
            }
            else
            {
                preAllowUnsafe += "-";
            }

            File.WriteAllText("compile.bat", "\""+cscPath+"\" "+"/nologo"+preAsm + asmName + prePlatform + platformOption +preTarget + targetOption + preRef + references + preRes + ressources + preAllowUnsafe + " \"" + sourcePath + "\"" + "\n pause");
            Process.Start("compile.bat");
        }
    }

    public class Compiler2 //for CSharp6 and compilation into memory
    {
        public enum Target
        {
            DLL,
            EXE
        }

        public enum Platform
        {
            x86,
            x64
        }

        public enum Language
        {
            CSharp,
            VB
        }

        public static void Compile(string asmName, Target t, Platform p, string[] pathToReferences, string[] pathToRessources, bool allowUnsafeCode, string sourcePath, Language l)
        {
                //get the csc.exe location
                string frameworkPath = @"C:\Roslyn\";
                string cscPath = "";
                string targetOption = "";
                string platformOption = "";
                string references = "";
                string ressources = "";

                string preAsm = " /out:";
                string preTarget = " /t:";
                string prePlatform = " /platform:";
                string preRef = " /r:";
                string preRes = " /res:";
                string preAllowUnsafe = " /unsafe";

                switch (t)
                {
                    case Target.EXE:
                        targetOption = "exe";
                        break;
                    case Target.DLL:
                        targetOption = "library";
                        break;
                }

                switch (p)
                {
                    case Platform.x86:
                        platformOption = "x86";
                        break;
                    case Platform.x64:
                        platformOption = "x64";
                        break;
                }

                switch (l)
                {
                    case Language.CSharp:
                        cscPath = Path.Combine(frameworkPath, "csc.exe");
                        break;
                    case Language.VB:
                        cscPath = Path.Combine(frameworkPath, "vbc.exe");
                        break;
                }

                if (pathToReferences[0] == "")
                {
                    preRef = " "; //no references
                }
                else
                {
                    foreach (string line in pathToReferences)
                    {
                        if (line == pathToReferences[pathToReferences.Count() - 1])
                        {
                            references += line;
                        }
                        else
                        {
                            references += line + ",";
                        }
                    }
                }

                if (pathToRessources[0] == "")
                {
                    preRes = " "; //no ressources
                }
                else
                {
                    foreach (string line in pathToRessources)
                    {
                        if (line == pathToRessources[pathToRessources.Count() - 1])
                        {
                            ressources += line;
                        }
                        else
                        {
                            ressources += line + ",";
                        }
                    }
                }

                if (allowUnsafeCode)
                {
                    preAllowUnsafe += "+";
                }
                else
                {
                    preAllowUnsafe += "-";
                }

                File.WriteAllText("compile.bat", "\"" + cscPath + "\" " + "/nologo" + preAsm + asmName + prePlatform + platformOption + preTarget + targetOption + preRef + references + preRes + ressources + preAllowUnsafe + " \"" + sourcePath + "\"" + "\n pause");
                Process.Start("compile.bat");
        }
    }
}
