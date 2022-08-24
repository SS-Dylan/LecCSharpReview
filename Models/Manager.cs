namespace LecCSharpReview.Models;

/// <summary>
/// Manager inherets from employee
/// </summary>
public class Manager : Employee
{
    /// <summary>
    /// This is where "virtual" comes into play.
    /// Simply typing "override " gives the methods that can be overridden.
    /// </summary>
    /// <returns></returns>
    public override string Talk()
    {
        return $"{Name}: GET BACK TO WORK!";
    }
}

