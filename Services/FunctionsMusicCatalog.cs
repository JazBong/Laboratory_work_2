using ConsoleApp3.Entities;

namespace ConsoleApp3.Services
{
    internal class FunctionsMusicCatalog
    {
        internal ArtistService ArtistService { get; }
        internal GenreService GenreService { get; }
        internal SongService SongService { get; }
        internal CollectionsOfSongsService CollectionsOfSongsService { get; }

        internal string? InputName(string title)
        {
            Console.WriteLine($"Введите название {title}:");
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            return null;
        }
        internal DateOnly? InputDate(string title)
        {
            var date = DateOnly.FromDateTime(DateTime.Now);

            Console.WriteLine($"Введите дату {title} в формате ГГГГ-ММ-ДД");
            if (DateOnly.TryParse(Console.ReadLine(), out DateOnly inputDate) && inputDate <= date)
            {
                return inputDate;
            }

            return null;
        }

        internal void PrintNameObjectCollection<T>(List<T> objs) where T : Interfaces.IHaveName
        {
            if (objs != null)
            {
                var i = 1;
                foreach (var obj in objs)
                {
                    Console.WriteLine($"\t\t{i}: {obj.Name}");
                    i++;
                }
            }

        }

        internal FunctionsMusicCatalog(List<Artist> artists, List<Genre> genres,
            List<Song> songs, List<CollectionOfSongs> collections)
        {
            ArtistService = new ArtistService(artists, this);
            GenreService = new GenreService(genres, this);
            SongService = new SongService(songs, this);
            CollectionsOfSongsService = new CollectionsOfSongsService(collections, this);
        }
    }
}
