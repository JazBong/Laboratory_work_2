namespace ConsoleApp3.Entities
{
    internal class Genre : Interfaces.IHaveName
    {
        public string Name { get; init; }
        internal Genre(string name)
        {
            Name = name;
        }
    }
}
