using System;

class MathConstants
{
    public const double Pi = 3.14159;
    public const int SpeedOfLight = 299792458;
}

class ProgramConstant
{
    static void MainConst()
    {
        Console.WriteLine("Value of Pi: " + MathConstants.Pi);
        Console.WriteLine("Speed of Light: " + MathConstants.SpeedOfLight);
    }
}