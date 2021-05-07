namespace CorruptusConscribo.Parser.Expressions.BinaryOperators
{
    public class Equal: BinaryOperator
    {
        // TODO: al register might be wrong, maybe just use rax
        public Equal() : base("==", "cmpq\t%rax,%rcx\nmovq\t$0,%rax\nsete\t%al")
        {
        }
    }
}