using System;
using System.Text.RegularExpressions;

namespace CorruptusConscribo
{
    public abstract class Operator : Token
    {
        public abstract string Template();

        protected Operator(string name, Regex expression) : base(name, expression)
        {
        }
    }

    public class Negation : Operator
    {
        public Negation() : base(TokenLibrary.Words.Negation, new Regex("-"))
        {
        }

        public override string Template()
        {
            return "neg     %eax";
        }

        public override string ToString()
        {
            return "-";
        }
    }

    public class BitwiseComplement : Operator
    {
        public BitwiseComplement() : base(TokenLibrary.Words.BitwiseComplement, new Regex("~"))
        {
        }

        public override string Template()
        {
            return "not     %eax";
        }
        
        public override string ToString()
        {
            return "~";
        }
    }


    public class LogicalNegation : Operator
    {
        public LogicalNegation() : base(TokenLibrary.Words.LogicalNegation, new Regex("!"))
        {
        }

        public override string Template()
        {
            // Compare the working register to 0
            // Set ZF (Zero flag) to result
            const string comparison = "cmpl     $0,%eax\n";
            
            // Clear the working register for later
            const string clearWorkingRegister = "movl     $0,%eax\n";
            
            // Set AL register based on the ZF flag
            const string setALRegister = "sete     %al";
            
            return comparison + clearWorkingRegister + setALRegister;
        }
        
        public override string ToString()
        {
            return "!";
        }
    }

    public class Addition : Operator
    {
        public Addition() : base(TokenLibrary.Words.Addition, new Regex("[+]"))
        {
            
        }

        public override string Template()
        {
            throw new NotImplementedException();
        }
        
        public override string ToString()
        {
            return "+";
        }
    }
    
    public class Division : Operator
    {
        public Division() : base(TokenLibrary.Words.Division, new Regex("/"))
        {
        }

        public override string Template()
        {
            throw new NotImplementedException();
        }
        
        public override string ToString()
        {
            return "/";
        }
    }
    
    public class Multiplication : Operator
    {
        public Multiplication() : base(TokenLibrary.Words.Multiplication,new Regex("[*]"))
        {
        }

        public override string Template()
        {
            throw new NotImplementedException();
        }
        
        public override string ToString()
        {
            return "*";
        }
    }
}