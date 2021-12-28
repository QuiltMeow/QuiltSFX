using Ionic.Zip;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuiltSFX
{
    public class SFXMaker
    {
        public CompilerParameters compilerParameter
        {
            get;
            private set;
        }

        public CSharpCodeProvider codeProvider
        {
            get;
            private set;
        }

        public SFXMaker()
        {
            reset();
        }

        public void reset()
        {
            compilerParameter = new CompilerParameters()
            {
                GenerateExecutable = true
            };
            addInternalReference();
            addResourceFile("DotNetZip.dll");

            codeProvider = new CSharpCodeProvider();
        }

        public void addReference(string file)
        {
            compilerParameter.ReferencedAssemblies.Add(file);
        }

        private void addInternalReference()
        {
            // 預設參考
            addReference("Microsoft.CSharp.dll");
            addReference("System.dll");
            addReference("System.Core.dll");
            addReference("System.Data.dll");
            addReference("System.Data.DataSetExtensions.dll");
            addReference("System.Deployment.dll");
            addReference("System.Drawing.dll");
            addReference("System.Windows.Forms.dll");
            addReference("System.Xml.dll");
            addReference("System.Xml.Linq.dll");

            // 壓縮函式庫
            addReference(typeof(ZipFile).Assembly.Location);
        }

        public void addResourceFile(string file)
        {
            compilerParameter.EmbeddedResources.Add(file);
        }

        public static string getDefine(params string[] define)
        {
            ISet<string> element = new HashSet<string>();
            foreach (string data in define)
            {
                if (string.IsNullOrWhiteSpace(data))
                {
                    continue;
                }
                element.Add(data);
            }
            if (element.Count <= 0)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder().Append("/define:");
            foreach (string data in element)
            {
                sb.Append(data).Append(";");
            }
            sb.Length -= 1;
            return sb.ToString();
        }

        public void compile(string savePath, string icon, bool password, bool noPack, bool console, bool uac, string[] sourceFile)
        {
            List<string> file = new List<string>();
            file.Add("SFXLibrary.cs");
            file.Add(Version.FILE_NAME);
            file.AddRange(sourceFile);

            StringBuilder option = new StringBuilder().Append("/target:").Append(console ? "exe" : "winexe");
            if (icon != null)
            {
                option.Append(" /win32icon:").Append("\"").Append(icon).Append("\"");
            }

            string define = getDefine(password ? "HAS_PASSWORD" : null, noPack ? "NO_PACK" : null);
            if (define != null)
            {
                option.Append(" ").Append(define);
            }

            if (uac)
            {
                option.Append(" /win32manifest:package.manifest");
            }

            compilerParameter.CompilerOptions = option.ToString();
            compilerParameter.OutputAssembly = savePath;

            CompilerResults result = codeProvider.CompileAssemblyFromFile(compilerParameter, file.ToArray());
            CompilerErrorCollection errorCollection = result.Errors;
            if (errorCollection.HasErrors)
            {
                StringBuilder ex = new StringBuilder();
                foreach (CompilerError error in errorCollection)
                {
                    ex.AppendLine(error.ToString());
                }
                throw new Exception(ex.ToString());
            }
        }
    }
}