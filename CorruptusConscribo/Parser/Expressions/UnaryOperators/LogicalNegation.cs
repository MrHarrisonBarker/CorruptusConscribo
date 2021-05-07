using CorruptusConscribo.Parser;

namespace CorruptusConscribo
{
    public class LogicalNegation : UnaryOperator
    {
        public LogicalNegation() : base("!", GenTemplate())
        {
        }

        private static string GenTemplate()
        {
            // Compare the working register to 0
            // Set ZF (Zero flag) to result
            const string comparison = "cmpl\t$0,rax\n";

            // Clear the working register for later
            const string clearWorkingRegister = "movl\t$0,rax\n";

            // Set AL register based on the ZF flag
            const string setAlRegister = "sete\t%al";

            return comparison + clearWorkingRegister + setAlRegister;
        }
    }
}