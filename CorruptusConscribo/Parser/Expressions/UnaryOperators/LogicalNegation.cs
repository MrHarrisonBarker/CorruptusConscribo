using CorruptusConscribo.Parser;

namespace CorruptusConscribo
{
    public class LogicalNegation : UnaryOperator
    {
        public LogicalNegation(Scope scope) : base(scope,"!", GenTemplate())
        {
        }

        private static string GenTemplate()
        {
            // Compare the working register to 0
            // Set ZF (Zero flag) to result
            const string comparison = "cmpq\t$0,%rax\n";

            // Clear the working register for later
            const string clearWorkingRegister = "movq\t$0,%rax\n";

            // Set AL register based on the ZF flag
            const string setAlRegister = "sete\t%al";

            return comparison + clearWorkingRegister + setAlRegister;
        }
    }
}