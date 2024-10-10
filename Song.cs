namespace ConsoleApp3
{
    internal class Song
    {
        internal string Name { get; private set; }
        internal List<Genre> Genres { get; private set; }
        internal Artist Artist { get; private set; }
        internal DateOnly ReleaseDate { get; private set; }

        internal Song(string name, List<Genre> genres, Artist artist, DateOnly releaseDate)
        {
            Name = name;
            Genres = genres;
            Artist = artist;
            ReleaseDate = releaseDate;
        }
    }
}
