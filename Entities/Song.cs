namespace ConsoleApp3.Entities
{
    internal class Song : Interfaces.IHaveName
    {
        public string Name { get; init; }
        internal List<Genre> Genres { get; init; }
        internal Artist Artist { get; init; }
        internal DateOnly ReleaseDate { get; init; }

        internal Song(string name, List<Genre> genres, Artist artist, DateOnly releaseDate)
        {
            Name = name;
            Genres = genres;
            Artist = artist;
            ReleaseDate = releaseDate;
        }
    }
}
