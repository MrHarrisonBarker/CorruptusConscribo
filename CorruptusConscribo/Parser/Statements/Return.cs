namespace CorruptusConscribo.Parser
{
    public class Return : Statement
    {
        private Expression Expression { get; }
        public Return(Expression expression)
        {
            Expression = expression;
        }

        public override string Template()
        {
            return $"{Expression.Template()}\nret";
        }

        public override string ToString()
        {
            return $"\tReturn {Expression.ToString()}";
        }
    }
}