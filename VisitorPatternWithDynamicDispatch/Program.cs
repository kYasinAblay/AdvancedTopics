﻿using System;
using System.Text;

namespace VisitorPatternWithDynamicDispatch
{
    public abstract class Expression
    {

    }
    public class Literal : Expression
    {
        public Literal(double value)
        {
            Value = value;
        }
        public double Value { get; }
    }
    public class Addition : Expression
    {
        public Expression Left { get; set; }
        public Expression Right { get; set; }
        public Addition(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }

    }
    public class ExpressionPrinter
    {
        //public static void Print(Expression e, StringBuilder sb)
        //{
        //    if (e.GetType() == typeof(Literal))
        //        Print((Literal)e, sb);
        //}

        //Bu satırı kapatırsam çalışmaz
        public static void Print(Literal literal, StringBuilder sb)
        {
            sb.Append(literal.Value);
        }
        public static void Print(Addition addition, StringBuilder sb)
        {
            sb.Append('(');
            Print((dynamic)addition.Left, sb);
            sb.Append('+');
            Print((dynamic)addition.Right, sb);
            sb.Append(')');
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            var e = new Addition(
                new Addition(new Literal(1), 
                             new Literal(2)
                        ), new Literal(3)
                    );
            var sb = new StringBuilder();
            ExpressionPrinter.Print((dynamic)e,sb);
            Console.WriteLine(sb);
        }
    }
}
