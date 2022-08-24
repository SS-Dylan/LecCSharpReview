namespace LecCSharpReview.Models;

public class Employee
{
    public string Name { get; set; } = String.Empty;

    /// <summary>
    /// Virtual means this method is overridable from the base class (which is this class, as well).
    /// </summary>
    /// <returns></returns>
    public virtual string Talk()
    {
        return $"{Name}: blah blah blah";
    }
}
