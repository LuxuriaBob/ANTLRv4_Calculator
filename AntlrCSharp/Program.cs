using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
 
namespace Calculator
{
  class Program
  {
        /*
        static void Main(string[] args)
        {
          StreamReader inputStream = new StreamReader(Console.OpenStandardInput());
          AntlrInputStream input = new AntlrInputStream(inputStream.ReadToEnd());
          CalculatorLexer lexer = new CalculatorLexer(input);
          CommonTokenStream tokens = new CommonTokenStream(lexer);
          CalculatorParser parser = new CalculatorParser(tokens);
          IParseTree tree = parser.prog();
          Console.WriteLine(tree.ToStringTree(parser));
          BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
          Console.WriteLine(visitor.Visit(tree));
        }
        */

        static void Main(string[] args)
        {
            Console.WriteLine("Enter an expression:");
            string input = Console.ReadLine();

            try
            {
                AntlrInputStream inputStream = new AntlrInputStream(input);
                CalculatorLexer lexer = new CalculatorLexer(inputStream);
                CommonTokenStream tokens = new CommonTokenStream(lexer);
                CalculatorParser parser = new CalculatorParser(tokens);
                var tree = parser.prog();
                BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
                int result = visitor.Visit(tree);
                Console.WriteLine($"Result: {result}");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}