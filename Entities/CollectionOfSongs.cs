namespace ConsoleApp3.Entities
{
    internal class CollectionOfSongs : Interfaces.IHaveName
    {
        public string Name { get; init; }
        internal List<Song> Songs { get; init; }
        internal CollectionOfSongs(string name)
        {
            Name = name;
            Songs = new();
        }
        internal CollectionOfSongs(string name, List<Song> songs)
        {
            Name = name;
            Songs = songs;
        }
    }
}
