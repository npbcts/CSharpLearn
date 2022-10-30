
Console.WriteLine("What`s your name?");
var firstName = Console.ReadLine();
Random rnd = new Random();
Console.WriteLine($"Hello {firstName}! Your are the {rnd.Next(2,9)}th stutens in school!");  // {Environment.NewLine}
Console.WriteLine("Press any key to exit... ");
Console.ReadKey(true);
