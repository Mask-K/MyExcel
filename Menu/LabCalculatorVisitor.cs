using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace Menu
{
    class LabCalculatorVisitor : LabCalculatorBaseVisitor<double>
    {
        //таблиця ідентифікаторів (тут для прикладу)
        //в лабораторній роботі заміните на свою!!!!
        Dictionary<string, double> tableIdentifier = new Dictionary<string, double>();
        public override double VisitCompileUnit(LabCalculatorParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }
        public override double VisitNumberExpr(LabCalculatorParser.NumberExprContext context)
        {
            
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);
            return result;
        }
        //IdentifierExpr
        public override double VisitIdentifierExpr(LabCalculatorParser.IdentifierExprContext context)
        {
            var result = context.GetText();
            double value;
            //видобути значення змінної з таблиці
            if (tableIdentifier.TryGetValue(result.ToString(), out value))
            {
                return value;
            }
            else
            {
                return 0;
            }
        }

        public override double VisitMaxExpr(LabCalculatorParser.MaxExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            Debug.WriteLine("max({0} , {1})", left, right);
            return Math.Max(left, right);
        }

        public override double VisitMinExpr(LabCalculatorParser.MinExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            Debug.WriteLine("min({0} , {1})", left, right);
            return Math.Min(left, right);
        }

        public override double VisitDecExpr(LabCalculatorParser.DecExprContext context)
        {
            var l = Visit(context.expression());
            Debug.WriteLine("dec{0}", l);
            return l - 1;
        }
        public override double VisitIncExpr(LabCalculatorParser.IncExprContext context)
        {
            var l = Visit(context.expression());
            Debug.WriteLine("inc{0}", l);
            return l + 1;
        }

        public override double VisitParenthesizedExpr(LabCalculatorParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitExponentialExpr(LabCalculatorParser.ExponentialExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            Debug.WriteLine("{0}^{1}", left, right);
            return Convert.ToDouble(System.Math.Pow(left, right));
        }

        public override double VisitAdditiveExpr(LabCalculatorParser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == LabCalculatorLexer.ADD)
            {
                Debug.WriteLine("{0}+{1}", left, right);
                return left + right;
            }
            else 
            {
            Debug.WriteLine("{0}-{1}", left, right);

                return left - right;
            }
        }
        public override double VisitMultiplicativeExpr(LabCalculatorParser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if (context.operatorToken.Type == LabCalculatorLexer.MULTIPLY)
            {
                Debug.WriteLine("{0}*{1}", left, right);
                return left * right;
            }
            else 
            {
                Debug.WriteLine("{0}/{1}", left, right);
                if (right != 0)
                {
                    return left / right;
                }
                else
                {
                    throw new DivideByZeroException("Divide by zero");
                }
            }
        }
        private double WalkLeft(LabCalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<LabCalculatorParser.ExpressionContext>(0));
        }
        private double WalkRight(LabCalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<LabCalculatorParser.ExpressionContext>(1));
        }

    }
}
