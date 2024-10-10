namespace ConsoleApp3
{
    internal class CollectionOfSongs
    {
        internal string Name { get; private set; }
        internal List<Song> Songs { get; private set; }
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
