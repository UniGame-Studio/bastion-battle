using System;

namespace IdSourceGenerator
{
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Text;
    using System.Text;
    using System.Linq;

    [Generator]
    public class ExampleSourceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var items = context.Compilation
                .SyntaxTrees
                .SelectMany(syntaxTree => syntaxTree.GetRoot().DescendantNodes())
                .Where(x => x is IGameIdValue);
                
            foreach (var item in items)
            {
                Console.WriteLine($"SOME INFO  {item.GetType().Name}" + DateTime.Now.ToString());
            }

            context.AddSource("hello.cs", 
                SourceText.From(@"public class HelloWorld { }", Encoding.UTF8)
            );


            System.Console.WriteLine(System.DateTime.Now.ToString());

            var sourceBuilder = new StringBuilder(
            @"
            using System;
            namespace ExampleSourceGenerated
            {
                public class DemoClass1
                {
                    public string GetTestText()
                    {
                        return ""This is from source generator ""
                    }
                }
            }");

            context.AddSource("demo.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
    
}