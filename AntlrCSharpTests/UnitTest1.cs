using Antlr4.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace AntlrCSharpTests
{
    [TestClass]
    public class CalculatorTests
    {
        private CalculatorParser Setup(string text)
        {
            AntlrInputStream inputStream = new AntlrInputStream(text);
            CalculatorLexer lexer = new CalculatorLexer(inputStream);
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);
            CalculatorParser parser = new CalculatorParser(tokenStream);
            return parser;
        }

        [TestMethod]
        public void TestAddition()
        {
            CalculatorParser parser = Setup("2 + 3");
            CalculatorParser.ProgContext context = parser.prog();
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            int result = visitor.Visit(context);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestSubtraction()
        {
            CalculatorParser parser = Setup("5 - 2");
            CalculatorParser.ProgContext context = parser.prog();
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            int result = visitor.Visit(context);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestMultiplication()
        {
            CalculatorParser parser = Setup("4 * 2");
            CalculatorParser.ProgContext context = parser.prog();
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            int result = visitor.Visit(context);

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void TestDivision()
        {
            CalculatorParser parser = Setup("8 / 2");
            CalculatorParser.ProgContext context = parser.prog();
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            int result = visitor.Visit(context);

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestParentheses()
        {
            CalculatorParser parser = Setup("(1 + 2) * 3");
            CalculatorParser.ProgContext context = parser.prog();
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            int result = visitor.Visit(context);

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void TestInvalidExpression()
        {
            CalculatorParser parser = Setup("2 +");
            var context = parser.prog();

            Assert.IsInstanceOfType(context, typeof(CalculatorParser.ProgContext));
            // Assuming there's some error handling in your parser for invalid inputs
        }
    }
}
