using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ActiproSoftware.SyntaxEditor.Addons.CSharp;
using ActiproSoftware.SyntaxEditor;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace MMCSharpTestCoverage
{
    [TestClass]
    public class MMCSharpTestCoverage : ISemanticParseDataTarget
    {
        private Dictionary<string, int> astTypeCoverageCount = new Dictionary<string, int>();

        [TestMethod]
        public void CalculateCoverage()
        {
            SemanticParserService.Start();
            ISemanticParserServiceProcessor language = new CSharpSyntaxLanguage();
            InitializeTypes();

            string[] files = Directory.GetFiles(@"I:\Mono\mcs\tests", "*.cs", SearchOption.AllDirectories);

            foreach (String file in files)
            {
                ProcessFile(file, language);
            }
                        
            SemanticParserService.Stop();
            PrintAstNodes(false);
            System.Console.Out.WriteLine("Not covered\n=============================================================");
            PrintAstNodes(true);
        }

        private void InitializeTypes()
        {
            var assembly = Assembly.GetAssembly(typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.AccessorDeclaration));
            foreach (Type type in assembly.GetTypes())
            {
                if (type.Namespace == "ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast")
                {
                    if (typeof(IAstNode).IsAssignableFrom(type)
                        && !type.IsAbstract
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.DictionaryAccessExpression) // VB only
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.AddressOfExpression) // VB only
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.ClassAccess) // VB only
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.StandardModuleDeclaration) // VB only
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.ExitStatement) // VB only
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.EventMemberSpecifier) // VB only
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.BranchStatement) // VB only
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.WithStatement) // VB only
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.RaiseEventStatement) // VB only
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.ModifyEventHandlerStatement) // VB only
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.UnstructuredErrorOnErrorStatement) // VB only
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.UnstructuredErrorResumeNextStatement) // VB only
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.UnstructuredErrorErrorStatement) // VB only
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.ArrayRedimClause) // VB only
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.ArrayEraseStatement) // VB only
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.ArrayRedimStatement) // VB only
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.GetXmlNamespaceExpression) // XML stuff
                        && type != typeof(ActiproSoftware.SyntaxEditor.Addons.DotNet.Ast.RegionPreProcessorDirective) // Region stuff
                        )
                    {
                        astTypeCoverageCount.Add(type.FullName, 0);
                    }
                }
            }
        }

        private void ProcessFile(string filename, ISemanticParserServiceProcessor language)
        {
            // Get the text
            StreamReader reader = File.OpenText(filename);
            string text = reader.ReadToEnd();
            reader.Close();

            // Make a request to the parser service (it runs in a separate thread)
            SemanticParserServiceRequest request = new SemanticParserServiceRequest(
                SemanticParserServiceRequest.LowPriority,
                filename,
                text,
                new TextRange(0, text.Length),
                SemanticParseFlags.None,
                language,
                this
                );

            SemanticParserService.Parse(request);
            SemanticParserService.WaitForParse(request.ParseHashKey, int.MaxValue);


        }

        void ISemanticParseDataTarget.NotifySemanticParseComplete(SemanticParserServiceRequest request)
        {
            Console.Out.WriteLine(String.Format("{0} is parsed", request.Filename));
            ICompilationUnit compilationUnit = (ICompilationUnit)request.SemanticParseData;

            ProcessAstNode(compilationUnit.RootNode);
            //ProcessFileResult(request.Filename);
        }

        private void ProcessFileResult(string file)
        {
            try
            {
                // Create the C# compiler
                using (CSharpCodeProvider compiler = new CSharpCodeProvider())
                {
                    var path = Path.GetDirectoryName(file);
                    var filename = string.Format("{0}.exe", Path.GetFileNameWithoutExtension(file));

                    // input params for the compiler
                    CompilerParameters compilerParams = new CompilerParameters();
                    compilerParams.GenerateExecutable = true;
                    compilerParams.ReferencedAssemblies.Add("system.dll");
                    compilerParams.OutputAssembly = Path.Combine(path, "output", filename);

                    var compilerResult = compiler.CompileAssemblyFromFile(compilerParams, file);

                    var processStartInfo = new ProcessStartInfo(compilerParams.OutputAssembly) { WindowStyle = ProcessWindowStyle.Hidden };
                    var process = Process.Start(processStartInfo);
                    process.WaitForExit();
                    Console.Out.WriteLine(String.Format("Exit code: {0}", process.ExitCode));
                }
            }
            catch (Exception)
            {
                Console.Out.WriteLine("Failed");
            }
        }

        private void ProcessAstNode(IAstNode astNode)
        {
            if (astTypeCoverageCount.ContainsKey(astNode.GetType().FullName))
            {
                astTypeCoverageCount[astNode.GetType().FullName] += 1;
            }
            else
            {
                Console.Out.WriteLine(String.Format("Couldn't find {0}", astNode.GetType().FullName));
            }            

            foreach (IAstNode childNode in astNode.ChildNodes)
            {
                ProcessAstNode(childNode);
            }
        }

        public string Guid
        {
            get
            {
                return System.Guid.NewGuid().ToString();
            }
        }

        private void PrintAstNodes(bool onlyNotCovered)
        {
            foreach (KeyValuePair<string, int> keyValuePairString in astTypeCoverageCount)
            {
                if (!(onlyNotCovered && (keyValuePairString.Value) > 0))
                {
                    System.Console.Out.WriteLine(String.Format("{0} = {1} used", keyValuePairString.Key, keyValuePairString.Value));
                }
            }
        }
    }
}