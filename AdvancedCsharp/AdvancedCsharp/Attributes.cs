using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class DebugInfoAttribute : Attribute
{
    public int BugNo { get; }
    public string Developer { get; }
    public string LastReview { get; }
    public string? Message { get; set; }

    public DebugInfoAttribute(int bugNo, string developer, string lastReview)
    {
        BugNo = bugNo;
        Developer = developer;
        LastReview = lastReview;
    }
}

[DebugInfo(45, "Zara Ali", "12/8/2012", Message = "Return type mismatch")]
[DebugInfo(49, "Nuha Ali", "10/10/2012", Message = "Unused variable")]
public class MyClass
{
    public void Display() => Console.WriteLine("Hello");
}
