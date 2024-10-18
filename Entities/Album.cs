namespace ConsoleApp3.Entities
{
    internal class Album : CollectionOfSongs
    {
        internal Artist Artist { get; init; }


        internal Album(string name, Artist artist) : base(name)
        {
            Artist = artist;
        }
        internal Album(string name, List<Song> songs, Artist artist) : base(name, songs)
        {
            Artist = artist;
        }
    }
}
