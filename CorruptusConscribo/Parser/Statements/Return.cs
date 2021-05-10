namespace CorruptusConscribo.Parser
{
    public class Return : Statement
    {
        private Expression Expression { get; }

        public Return(Scope scope, Expression expression) : base(scope)
        {
            Expression = expression;
        }

        public override string Template()
        {
            const string epilogue = "movq\t%rbp,%rsp\npop\t%rbp\n";

            return $"\n{Expression.Template()}\n \n{epilogue}ret";
        }

        public override string ToString()
        {
            return $"\tReturn {Expression}";
        }
    }
}