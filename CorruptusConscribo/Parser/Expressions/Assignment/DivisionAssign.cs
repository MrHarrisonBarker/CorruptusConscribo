namespace CorruptusConscribo.Parser
{
    public class DivisionAssign : Assignment
    {
        public DivisionAssign(Scope scope) : base(scope, "/=","cqo\nidiv\t%rbx")
        {
        }

        public override string Template()
        {
            return $"{RightExpression.Template()}\nmovq\t%rax,%rbx\n{LeftExpression.Template()}\n{AssignmentTemplate}\n{LeftExpression.Save()}";
            
            // var retrieve = $"\nmovq\t{varIndex}(%rbp),%rax";
            // const string div = "\nidiv\t%rbx";
            // var assign = $"\nmovq\t%rax,{varIndex}(%rbp)";
            //
            // return $"{Expression.Template()}" +
            //        "\nmovq\t%rax,%rbx" +
            //        retrieve +
            //        "\ncqo" +
            //        div +
            //        assign;
        }
    }
}