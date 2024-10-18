
namespace ConsoleApp3.Entities
{
    internal class Artist : Interfaces.IHaveName
    {
        public string Name { get; init; }

        internal DateOnly Birthday { get; init; }

        internal Artist(string name, DateOnly birthday)
        {
            Name = name;
            Birthday = birthday;
        }
    }
}
