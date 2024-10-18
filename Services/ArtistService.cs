using ConsoleApp3.Entities;


namespace ConsoleApp3.Services
{
    internal class ArtistService
    {
        private readonly List<Artist> _artists;
        private readonly FunctionsMusicCatalog _functionsMusicCatalog;

        internal Artist? ChoiceArtist()
        {
            Console.WriteLine("Выберите исполнителя:");
            Console.WriteLine("\n\t0: Добавить нового исполнителя");
            _functionsMusicCatalog.PrintNameObjectCollection(_artists);
            var i = _artists.Count + 1;
            var str = Console.ReadLine();
            if (str == "0")
            {
                return AddArtist();
            }
            else if (int.TryParse(str, out var input))
            {
                if (input > 0 && input < i)
                {
                    return _artists[input - 1];
                }
            }

            return null;
        }
        internal Artist AddArtist()
        {
            string artistName = "";
            DateOnly dateBirthday = new DateOnly();

            var isCorrectName = false;
            while (!isCorrectName)
            {
                var str = _functionsMusicCatalog.InputName("артиста");
                isCorrectName = str == null ? false : true;
                artistName = str ?? "";
            }

            var isCorrectDate = false;
            while (!isCorrectDate)
            {
                var date = _functionsMusicCatalog.InputDate("рождения артиста");
                isCorrectDate = date == null ? false : true;
                dateBirthday = date ?? new DateOnly();
            }
            Artist artist = new Artist(artistName, dateBirthday);
            _artists.Add(artist);

            return artist;
        }
        internal List<Artist> SearchArtistsByName(string name)
        {
            var list = new List<Artist>();
            foreach (var artist in _artists)
            {
                if (artist.Name.Contains(name))
                {
                    list.Add(artist);
                }
            }
            return list;
        }

        internal ArtistService(List<Artist> artists, FunctionsMusicCatalog functionsMusicCatalog)
        {
            _artists = artists;
            _functionsMusicCatalog = functionsMusicCatalog;
        }
    }
}
