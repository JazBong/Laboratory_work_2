using ConsoleApp3.Entities;

namespace ConsoleApp3.Services
{
    internal class SongService
    {
        private readonly List<Song> _songs;
        private readonly FunctionsMusicCatalog _functionsMusicCatalog;

        internal List<Song> ChoiceSongs()
        {
            List<Song> songsList = [];
            Console.WriteLine("Выберите песни, разделитель пробел:");
            Console.WriteLine("\n\t0: Добавить новую песню");
            _functionsMusicCatalog.PrintNameObjectCollection(_songs);
            var i = _songs.Count + 1;
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                bool containsInvalidChars = input.Any(c => !char.IsDigit(c) && c != ' ');
                if (!containsInvalidChars)
                {
                    List<int> numbers = new List<int>();
                    string[] songs = input.Split(' ');

                    foreach (var song in songs)
                    {
                        if (int.TryParse(song, out int number))
                        {
                            if (number > 0 && number < i)
                            {
                                if (!numbers.Contains(number))
                                {
                                    numbers.Add(number);
                                    songsList.Add(_songs[number - 1]);
                                }
                            }
                            else if (number == 0)
                            {
                                songsList.Add(AddSong());
                            }
                        }
                    }
                }
            }

            return songsList;
        }

        internal Song AddSong()
        {
            string songName = "";
            Artist artist = null;
            List<Genre> genreList = new();
            var dateRelease = new DateOnly();

            var isCorrectName = false;
            while (!isCorrectName)
            {
                var str = _functionsMusicCatalog.InputName("песни");
                if (str != null)
                {
                    songName = str;
                    isCorrectName = true;
                }
                else
                {
                    Console.WriteLine("Uncorrect input!");
                }
            }

            var isCorrectDate = false;
            while (isCorrectDate)
            {
                var date = _functionsMusicCatalog.InputDate("создания песни");
                if (date != null)
                {
                    dateRelease = (DateOnly)date;
                    isCorrectDate = true;
                }
                else
                {
                    Console.WriteLine("Uncorrect input!");
                }
            }

            var isCorrectArtist = false;
            while (!isCorrectArtist)
            {
                var ar = _functionsMusicCatalog.ArtistService.ChoiceArtist();
                if (ar != null)
                {
                    artist = ar;
                    isCorrectArtist = true;
                }
                else
                {
                    Console.WriteLine("Uncorrect input!");
                }
            }

            var isCorrectGenres = false;
            while (!isCorrectGenres)
            {
                var g = _functionsMusicCatalog.GenreService.ChoiceGenres();
                if (g != null && g.Count != 0)
                {
                    genreList = g;
                    isCorrectGenres = true;
                }
                else
                {
                    Console.WriteLine("Uncorrect input!");
                }
            }
            var song = new Song(songName, genreList, artist!, dateRelease);
            _songs.Add(song);

            return song;
        }

        internal List<Song> SearchSongsByNameAndArtist(string name)
        {
            var songs = new List<Song>();
            Artist artist = null;

            var isCorrectArtist = false;
            while (!isCorrectArtist)
            {
                var ar = _functionsMusicCatalog.ArtistService.ChoiceArtist();
                if (ar != null)
                {
                    artist = ar;
                    isCorrectArtist = true;
                }
            }
            foreach (var song in _songs)
            {
                if (song.Artist == artist && song.Name.Contains(name))
                {
                    songs.Add(song);
                }
            }

            return songs;
        }

        internal SongService(List<Song> songs, FunctionsMusicCatalog functionsMusicCatalog)
        {
            _songs = songs;
            _functionsMusicCatalog = functionsMusicCatalog;
        }
    }
}
