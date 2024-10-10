namespace ConsoleApp3
{
    internal class Album : CollectionOfSongs
    {
        internal Artist Artist { get; private set; }
        internal Album(string name, Artist artist) : base(name)
        {
            Artist = artist;
        }
        internal Album(string name, List<Song> songs, Artist artist) : base(name, songs)
        {
            Artist = artist;
        }
        internal void SetArtist(Artist artist)
        {
            Artist = artist;
        }
    }
}
