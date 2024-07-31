using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CalculatorParser;

namespace Calculator
{
  public class BasicCalculatorVisitor : CalculatorBaseVisitor<int>
  {
    public override int VisitInt(CalculatorParser.IntContext context)
    {
      return int.Parse(context.INT().GetText());
    }

    public override int VisitAddSub(CalculatorParser.AddSubContext context)
    {
      int left = Visit(context.expr(0));
      int right = Visit(context.expr(1));
      if (context.op.Type == CalculatorParser.ADD)
      {
        return left + right;
      }
      else
      {
        return left - right;
      }
    }

    public override int VisitMulDiv(CalculatorParser.MulDivContext context)
    {
      int left = Visit(context.expr(0));
      int right = Visit(context.expr(1));
      if (context.op.Type == CalculatorParser.MUL)
      {
        return left * right;
      }
      else
      {
        return left / right;
      }
    }

    public override int VisitPower(CalculatorParser.PowerContext context)
    {
      int baseValue = Visit(context.expr(0));
      int exponent = Visit(context.expr(1));
      return (int)Math.Pow(baseValue, exponent);
    }

    public override int VisitNegate(CalculatorParser.NegateContext context)
    {
      return -Visit(context.expr());
    }
    public override int VisitSin(CalculatorParser.SinContext context)
    {
      return (int)Math.Sin(Visit(context.expr()));
    }

    public override int VisitCos(CalculatorParser.CosContext context)
    {
      return (int)Math.Cos(Visit(context.expr()));
    }

    public override int VisitTan(CalculatorParser.TanContext context)
    {
      return (int)Math.Tan(Visit(context.expr()));
    }
    public override int VisitLog(CalculatorParser.LogContext context)
    {
      return (int)Math.Log10(Visit(context.expr()));
    }

    public override int VisitLn(CalculatorParser.LnContext context)
    {
      return (int)Math.Log(Visit(context.expr()));
    }

    public override int VisitExp(CalculatorParser.ExpContext context)
    {
      return (int)Math.Exp(Visit(context.expr()));
    }
    public override int VisitFactorial(CalculatorParser.FactorialContext context)
    {
      int value = Visit(context.expr());
      return Factorial(value);
    }

    private int Factorial(int n)
    {
      if (n <= 1) return 1;
      return n * Factorial(n - 1);
    }

    public override int VisitParens(CalculatorParser.ParensContext context)
    {
      return Visit(context.expr());
    }
  }
}