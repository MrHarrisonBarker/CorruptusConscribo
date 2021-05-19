using System;
using System.Collections.Generic;
using System.Linq;
using CorruptusConscribo.Parser;

namespace CorruptusConscribo.Inquisition
{
    public class Inquisition
    {
        private Parser.Program Program { get; set; }
        private readonly Dictionary<string, FuncDeclareAndCalls> Functions = new();
        private Dictionary<string, string> Globals = new();

        public Inquisition(Parser.Program program)
        {
            Program = program;
        }

        public bool IsClean()
        {
            return FunctionsValid();
        }

        // validates the declaration and calling of functions in the program
        private bool FunctionsValid()
        {
            Program.TopLevelBlocks.ForEach(TraverseProgram);
            FunctionParameterValid();
            UniqueIdentifiers();

            return true;
        }

        private void UniqueIdentifiers()
        {
            foreach (var global in Globals.Keys)
            {
                if (Functions.Keys.Any(x => x == global)) throw new CompileException($"something called {global} already exists!");
            }
        }

        private void FunctionParameterValid()
        {
            foreach (var function in Functions.Values)
            {
                if (function.Definition != null && function.Declaration != null && function.Definition.Params.Count != function.Declaration.Params.Count)
                    throw new CompileException("the function declaration doesn't match the definition");

                foreach (var functionCall in function.Calls)
                {
                    if (function.Declaration == null && function.Definition == null) throw new CompileException("function is never defined or declared");

                    if (function.Declaration != null && function.Definition != null &&
                        (functionCall.Args.Count != function.Definition.Params.Count || functionCall.Args.Count != function.Declaration.Params.Count))
                        throw new CompileException("function call argument mismatch");

                    // if there is no declaration check the definition
                    if (function.Declaration == null && function.Definition != null)
                    {
                        if (functionCall.Args.Count != function.Definition.Params.Count) throw new CompileException("param err");
                    }
                    else if (function.Declaration != null && function.Definition == null)
                    {
                        if (functionCall.Args.Count != function.Declaration.Params.Count) throw new CompileException("param err");
                    }
                }
            }
        }

        private void TraverseProgram(ASTNode node)
        {
            var nodeType = node.GetType();

            if (typeof(Function) == nodeType)
            {
                var func = (Function) node;
                
                // Console.WriteLine($"Found function {func}");

                // if function is declaration
                if (func.Block == null)
                {
                    if (Functions.ContainsKey(func.Identifier) && Functions[func.Identifier].Declaration != null) throw new CompileException($"{func.Identifier} has already been declared");
                }
                else
                {
                    if (Functions.ContainsKey(func.Identifier) && Functions[func.Identifier].Definition != null) throw new CompileException($"{func.Identifier} has already been defined");
                }

                if (Functions.ContainsKey(func.Identifier))
                {
                    Functions[func.Identifier] = new FuncDeclareAndCalls
                    {
                        Declaration = func.Block == null ? func : Functions[func.Identifier].Declaration,
                        Definition = func.Block != null ? func : Functions[func.Identifier].Definition,
                        Calls = new List<FunctionCall>()
                    };
                }
                else
                {
                    Functions[func.Identifier] = new FuncDeclareAndCalls
                    {
                        Declaration = func.Block == null ? func : null,
                        Definition = func.Block != null ? func : null,
                        Calls = new List<FunctionCall>()
                    };
                }

                if (func.Block != null) TraverseProgram(func.Block);
            }

            if (typeof(Block) == nodeType)
            {
                var block = (Block) node;
                
                // Console.WriteLine($"Found block {block}");

                foreach (var slice in block.Slices)
                {
                    TraverseProgram(slice);
                }
            }

            if (typeof(FunctionCall) == nodeType)
            {
                var funcCall = (FunctionCall) node;
                
                // Console.WriteLine($"Found function call {funcCall}");

                if (Functions.ContainsKey(funcCall.FunctionId))
                {
                    var func = Functions[funcCall.FunctionId];
                    func.Calls.Add(funcCall);
                }
                else
                {
                    Functions.Add(funcCall.FunctionId, new FuncDeclareAndCalls
                    {
                        Calls = new List<FunctionCall> {funcCall}
                    });
                }
            }

            if (typeof(GlobalVariable) == nodeType)
            {
                var global = (GlobalVariable) node;

                Globals[global.Identifier] = "Global";
            }

            if (nodeType.IsSubclassOf(typeof(Statement)))
            {
                var properties = node.GetType().GetProperties();

                foreach (var property in properties)
                {
                    var val = property.GetValue(node);
                    if (val != null && val.GetType().IsSubclassOf(typeof(Expression))) TraverseProgram((Expression) val);
                }

                var statement = (Statement) node;
                
                // Console.WriteLine($"Found statement {statement}");

                if (statement.Slices != null) statement.Slices.ForEach(TraverseProgram);
            }
        }
    }
}