using Microsoft.Extensions.DependencyInjection;

// ツールの基本クラス
abstract class ToolBase
{
    public abstract int Run(string arg);
}

// 各種ツールの実装
class Tool1 : ToolBase
{
    public override int Run(string arg)
    {
        Console.WriteLine($"Tool1 is running with {arg}.");
        return 1;
    }
}

class Tool2 : ToolBase
{
    private readonly SomeClass someClass;

    public Tool2(SomeClass someClass)
    {
        this.someClass = someClass;
    }

    public override int Run(string arg)
    {
        Console.WriteLine($"Tool2 is running with {arg}. {someClass}.");
        return 2;
    }
}

// 特定のツールには必要なクラス
class SomeClass { }

// ツールを呼ぶ汎用クラス
class ToolInvoker
{
    private IServiceProvider serviceProvider;
    public ToolInvoker(SomeClass someClass)
    {
        serviceProvider = new ServiceCollection()
            .AddSingleton<SomeClass>(someClass)
            .AddSingleton<Tool1>()
            .AddSingleton<Tool2>()
            .BuildServiceProvider();
    }

    public int Run<T>(string arg) where T : ToolBase
    {
        var tool = serviceProvider.GetRequiredService<T>();
        return tool.Run(arg);
    }
}