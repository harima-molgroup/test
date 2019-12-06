// 1. https://dotnetfiddle.net/ を開く
// 2. 下記のコードで差し替え
// 3. Run!

using System;

public class Program
{
	public static void Main()
	{
		string msg = "weeeeeeeeeeeeeeeeeey!";
		
		Console.WriteLine("--- 1. 静的メソッド ---");
		Parent.PrintStatic("[Parent] " + msg);
		Child.PrintStatic("[Chile] " + msg);
		Clone.PrintStatic("[Clone] " + msg);
		Console.WriteLine("");
		
		Console.WriteLine("--- 2. 継承 ---");
		var parent = new Parent();
		parent.Print("var " + msg);
		
		var child = new Child();
		child.Print("var " + msg);
		
		var clone = new Clone();
		clone.Print("var " + msg);
		Console.WriteLine("");
		
		Console.WriteLine("--- 3. ポリモーフィズム ---");
		Parent polyParent = new Parent();
		polyParent.Print("poly " + msg);
		
		Parent polyChild = new Child();
		polyChild.Print("poly " + msg);
		
		Parent polyClone = new Clone();
		polyClone.Print("poly " + msg);
	}
}

public class Parent
{
	public static void PrintStatic(string message)
	{
		Console.WriteLine("PrintStatic( " + message + " )");
	}

	public virtual void Print(string message)
	{
		Console.WriteLine("Print( [Parent] " + message + " )");
	}
}

public class Child : Parent
{
	public override void Print(string message)
	{
		Console.WriteLine("Print( [Child] " + message + " )");
	}
}

public class Clone : Parent
{
}