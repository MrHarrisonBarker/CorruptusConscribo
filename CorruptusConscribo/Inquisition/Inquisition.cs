using System;
using System.Collections.Generic;
using CorruptusConscribo.Parser;

namespace CorruptusConscribo.Inquisition
{
    public class FuncDeclareAndCalls
    {
        public Function Definition { get; set; }
        public Function Declaration { get; set; }
        public List<FunctionCall> Calls { get; set; }
    }

    public class Inquisition
    {
        private Parser.Program Program { get; set; }
        private Dictionary<string, FuncDeclareAndCalls> Functions = new();

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
            Program.Functions.ForEach(TraverseProgram);
            FunctionParameterValid();

            return true;
        }

        private void FunctionParameterValid()
        {
            foreach (var value in Functions.Values)
            {
                foreach (var functionCall in value.Calls)
                {
                    if (functionCall.Params.Count != value.Declaration.Params.Count) throw new CompileException("param err");
                }
            }
        }

        private void TraverseProgram(ASTNode node)
        {
            var nodeType = node.GetType();

            if (typeof(Function) == nodeType)
            {
                var func = (Function) node;
                Console.WriteLine($"Found function {func}");

                if (Functions.ContainsKey(func.Name)) throw new CompileException($"{func.Name} has already been initialised");

                Functions[func.Name] = new FuncDeclareAndCalls()
                {
                    Declaration = func.Block == null ? func : null,
                    Definition = func.Block != null ? func : null,
                    Calls = new List<FunctionCall>()
                };

                if (func.Block != null) TraverseProgram(func.Block);
            }

            if (typeof(Block) == nodeType)
            {
                var block = (Block) node;
                Console.WriteLine($"Found block {block}");

                foreach (var slice in block.Slices)
                {
                    TraverseProgram(slice);
                }
            }

            if (typeof(FunctionCall) == nodeType)
            {
                var funcCall = (FunctionCall) node;

                var func = Functions[funcCall.FunctionId];
                func.Calls.Add(funcCall);

                Console.WriteLine($"Found function call {funcCall}");
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
                Console.WriteLine($"Found statement {statement}");

                if (statement.Slices != null) statement.Slices.ForEach(TraverseProgram);
            }
        }
    }
}