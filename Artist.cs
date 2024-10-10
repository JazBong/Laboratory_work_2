namespace ConsoleApp3
{
    internal class Artist
    {
        internal string Name { get; private set; }

        internal DateOnly Birthday { get; }

        internal Artist(string name, DateOnly birthday)
        {
            Name = name;
            Birthday = birthday;
        }
    }
}
