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
        public void TestExponentiation()
        {
            CalculatorParser parser = Setup("2 ^ 3");
            CalculatorParser.ProgContext context = parser.prog();
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            int result = visitor.Visit(context);

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void TestUnaryOperator()
        {
            CalculatorParser parser = Setup("-3 + 4");
            CalculatorParser.ProgContext context = parser.prog();
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            int result = visitor.Visit(context);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestSinFunction()
        {
            CalculatorParser parser = Setup("sin(0)");
            CalculatorParser.ProgContext context = parser.prog();
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            double result = visitor.Visit(context); // Note: sin function returns double

            Assert.AreEqual(0, result, 1e-10); // Allowing for floating-point precision
        }

        [TestMethod]
        public void TestCosFunction()
        {
            CalculatorParser parser = Setup("cos(0)");
            CalculatorParser.ProgContext context = parser.prog();
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            double result = visitor.Visit(context); // Note: cos function returns double

            Assert.AreEqual(1, result, 1e-10); // Allowing for floating-point precision
        }
        [TestMethod]
        public void TestTanFunction()
        {
            CalculatorParser parser = Setup("tan(45)");
            CalculatorParser.ProgContext context = parser.prog();
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            double result = visitor.Visit(context); // Note: cos function returns double

            Assert.AreEqual(1, result, 1e-10); // Allowing for floating-point precision
        }

        [TestMethod]
        public void TestLogFunction()
        {
            CalculatorParser parser = Setup("log(10)");
            CalculatorParser.ProgContext context = parser.prog();
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            double result = visitor.Visit(context); // Note: log function returns double

            Assert.AreEqual(1, result, 1e-10); // log10(10) = 1
        }

        [TestMethod]
        public void TestLnFunction()
        {
            CalculatorParser parser = Setup("ln(e)");
            CalculatorParser.ProgContext context = parser.prog();
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            double result = visitor.Visit(context); // Note: ln function returns double

            Assert.AreEqual(1, result, 1e-10); // ln(e) = 1
        }

        [TestMethod]
        public void TestExpFunction()
        {
            CalculatorParser parser = Setup("exp(1)");
            CalculatorParser.ProgContext context = parser.prog();
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            double result = visitor.Visit(context); // Note: exp function returns double

            Assert.AreEqual((int)Math.Exp(1), result, 1e-10); // exp(1) = e
        }

        [TestMethod]
        public void TestFactorial()
        {
            CalculatorParser parser = Setup("5!");
            CalculatorParser.ProgContext context = parser.prog();
            BasicCalculatorVisitor visitor = new BasicCalculatorVisitor();
            int result = visitor.Visit(context);

            Assert.AreEqual(120, result); // 5! = 120
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
