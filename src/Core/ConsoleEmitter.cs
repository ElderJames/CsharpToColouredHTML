﻿using System.Text;
using Microsoft.CodeAnalysis.Classification;

namespace Core;

public class ConsoleEmitter : IEmitter
{
    private readonly StringBuilder _sb = new StringBuilder();

    public string Text { get; private set; }

    public void Emit(List<Node> nodes)
    {
        Text = "";
        _sb.Clear();

        foreach (var node in nodes)
        {
            EmitNode(node);
        }

        Text = _sb.ToString();
    }

    public void EmitNode(Node node)
    {
        if (node.ClassificationType == ClassificationTypeNames.ClassName)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else if (node.ClassificationType == ClassificationTypeNames.NamespaceName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else if (node.ClassificationType == ClassificationTypeNames.Identifier)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else if (node.ClassificationType == ClassificationTypeNames.Keyword)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else if (node.ClassificationType == ClassificationTypeNames.StringLiteral)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        else if (node.ClassificationType == ClassificationTypeNames.LocalName)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        else if (node.ClassificationType == ClassificationTypeNames.MethodName)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else if (node.ClassificationType == ClassificationTypeNames.Punctuation)
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (node.ClassificationType == ClassificationTypeNames.Operator)
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (node.ClassificationType == ClassificationTypeNames.ControlKeyword)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        else
        {
            Console.ResetColor();
        }

        _sb.Append(node.TextWithTrivia);
        Console.Write(node.TextWithTrivia);
        Console.ResetColor();
    }
}
