using System;
using System.Collections.Generic;

namespace CorruptusConscribo.Parser
{
    public abstract class ASTNode
    {
        protected Scope Scope;
        // public abstract ASTNode Parse(Stack<Token> tokens);
        
        protected ASTNode(Scope scope)
        {
            Scope = scope;
        }

        // public virtual ASTNode Parse(Stack<Token> tokens)
        // {
        //     return null;
        // }
        
        public virtual string Template()
        {
            return "**NotImplemented**";
        }

        public virtual string Save()
        {
            return "**SAVE-NotImplemented**";
        }
    }
}