// ツール呼び出しクラス使用例
// 理想的にはアプリ全体で DI コンテナを 1 個持ちたい
var invoker = new ToolInvoker(new SomeClass());
Console.WriteLine(invoker.Run<Tool1>("arg1"));
Console.WriteLine(invoker.Run<Tool2>("arg2"));
