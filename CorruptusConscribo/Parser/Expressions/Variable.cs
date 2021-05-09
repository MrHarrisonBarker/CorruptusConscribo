namespace CorruptusConscribo.Parser
{
    public class Variable : Expression
    {
        private string VariableId { get; }

        public Variable(string id)
        {
            VariableId = id;
        }

        public override string Template()
        {
            return "NOT IMPLEMENTED";
        }

        public override string ToString()
        {
            return $"{VariableId}";
        }
    }
}