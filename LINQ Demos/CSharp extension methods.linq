<Query Kind="Program" />

//C# Primer on extension methods
void Main()
{
	string name = "Dan";
	string message = name.Sleepy();
	message.Dump();
}

// Define other methods and classes here
public static class StringExtensions
{
	public static string Sleepy(this string text)
	{
		return text + " - Yawn. Are we there yet?";
	}
}
