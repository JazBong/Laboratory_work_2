namespace ConsoleApp3
{
    internal class FunctionsMusicCatalog
    {
        private List<Artist> _artists;
        private List<Genre> _genres;
        private List<Song> _songs;
        private List<CollectionOfSongs> _collections;

        private string? InputName(string title)
        {
            Console.WriteLine($"Введите название {title}:");
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            return null;
        }
        private DateOnly? InputDate(string title)
        {
            var date = DateOnly.FromDateTime(DateTime.Now);

            Console.WriteLine($"Введите дату {title} в формате ГГГГ-ММ-ДД");
            if (DateOnly.TryParse(Console.ReadLine(), out DateOnly inputDate) && inputDate <= date)
            {
                return inputDate;
            }

            return null;

            /*Console.WriteLine($"Введите год {title}");
            if (int.TryParse(Console.ReadLine(), out int year) && year > 0 && year <= dt.Year)
            {
                Console.WriteLine($"Введите месяц {title}");
                if (int.TryParse(Console.ReadLine(), out int month)
                    && month > 0 && month <= 12 && (year != dt.Year || (year == dt.Year && month < dt.Month)))
                {
                    Console.WriteLine($"Введите день {title}");
                    if (int.TryParse(Console.ReadLine(), out int day)
                    && day > 0 && day <= 31 && (year != dt.Year || (year == dt.Year && month != dt.Month)))
                    {
                        return new DateOnly(year, month, day);
                    }
                }

            }*/

            //Console.WriteLine($"Введите год {title}");
            //if (!int.TryParse(Console.ReadLine(), out int year) || year > dt.Year)
            //{
            //    return null;
            //}
            //Console.WriteLine($"Введите месяц {title}");
            //if (!int.TryParse(Console.ReadLine(), out int month) || month > 12 || (year == dt.Year && month > dt.Month))
            //{
            //    return null;
            //}
            //Console.WriteLine($"Введите день {title}");
            //if (!int.TryParse(Console.ReadLine(), out int day) ||
            //    (year == dt.Year && month == dt.Month && day > dt.Day))
            //{
            //    return null;
            //}

            //return new DateOnly(year, month, day);
            //return null;
        }
        private CollectionOfSongs CreateCollectionOfSongs()
        {
            string collectionOfSongsName = "";
            List<Song> songs = new List<Song>();

            var isCorrectCollectionOfSongsName = false;
            while (!isCorrectCollectionOfSongsName)
            {
                var str = InputName("коллекции");
                if (str != null)
                {
                    collectionOfSongsName = str;
                    isCorrectCollectionOfSongsName = true;
                }
                else
                {
                    Console.WriteLine("Uncorrect input!");
                }
            }

            var isCorrectSongs = false;
            while (!isCorrectSongs)
            {
                var s = ChoiceSongs();
                if (s != null && s.Count != 0)
                {
                    songs = s;
                    isCorrectSongs = true;
                }
                else
                {
                    Console.WriteLine("Uncorrect input!");
                }
            }

            return new CollectionOfSongs(collectionOfSongsName, songs);

        }

        internal void PrintNameObjectCollection<T>(List<T> objs)
        {
            var i = 1;
            foreach (var obj in objs)
            {
                if (obj is Artist artist)
                {
                    Console.WriteLine($"\t\t{i}: {artist.Name}");
                }
                else if (obj is Genre genre)
                {
                    Console.WriteLine($"\t\t{i}: {genre.Name}");
                }
                else if (obj is Song song)
                {
                    Console.WriteLine($"\t\t{i}: {song.Name}");
                }
                else if (obj is CollectionOfSongs col)
                {
                    Console.WriteLine($"\t\t{i}: {col.Name}");
                }
                else
                {
                    Console.WriteLine("Unknowing type");
                    break;
                }
                i++;
            }
        }

        internal Artist? ChoiceArtist()
        {
            Console.WriteLine("Выберите исполнителя:");
            Console.WriteLine("\n\t0: Добавить нового исполнителя");
            PrintNameObjectCollection(_artists);
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
        internal List<Genre> ChoiceGenres()
        {
            List<Genre> genreList = [];
            Console.WriteLine("Выберите жанры, разделитель пробел:");
            Console.WriteLine("\n\t0: Добавить новый жанр");
            PrintNameObjectCollection(_genres);
            var i = _genres.Count + 1;
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                bool containsInvalidChars = input.Any(c => !char.IsDigit(c) && c != ' ');
                if (!containsInvalidChars)
                {
                    List<int> numbers = new List<int>();
                    string[] genres = input.Split(' ');
                    foreach (var g in genres)
                    {
                        if (int.TryParse(g, out int number))
                        {
                            if (number > 0 && number < i)
                            {
                                if (!numbers.Contains(number))
                                {
                                    numbers.Add(number);
                                    genreList.Add(_genres[number - 1]);
                                }
                            }
                            else if (number == 0)
                            {
                                genreList.Add(AddGenre());
                            }
                        }
                    }
                }
            }

            return genreList;
        }
        internal List<Song> ChoiceSongs()
        {
            List<Song> songsList = [];
            Console.WriteLine("Выберите песни, разделитель пробел:");
            Console.WriteLine("\n\t0: Добавить новую песню");
            PrintNameObjectCollection(_songs);
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

        internal Artist AddArtist()
        {
            string artistName = "";
            DateOnly dateBirthday = new DateOnly();

            var isCorrectName = false;
            while (!isCorrectName)
            {
                var str = InputName("артиста");
                isCorrectName = str == null ? false : true;
                artistName = str ?? "";
            }

            var isCorrectDate = false;
            while (!isCorrectDate)
            {
                var date = InputDate("рождения артиста");
                isCorrectDate = date == null ? false : true;
                dateBirthday = date ?? new DateOnly();
            }
            Artist artist = new Artist(artistName, dateBirthday);
            _artists.Add(artist);

            return artist;
        }
        internal Genre AddGenre()
        {
            var isCorrectData = false;
            string genreName = "";

            while (!isCorrectData)
            {
                var str = InputName("жанра");
                if (str != null)
                {
                    genreName = str;
                    isCorrectData = true;
                }
                else
                {
                    Console.WriteLine("Uncorrect input!");
                }
            }
            var genre = new Genre(genreName);
            _genres.Add(genre);

            return genre;
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
                var str = InputName("песни");
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
                var date = InputDate("создания песни");
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
                var ar = ChoiceArtist();
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
                var g = ChoiceGenres();
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
        internal CollectionOfSongs AddCollectionOfSongs()
        {
            var CollectionOfSongs = CreateCollectionOfSongs();
            _collections.Add(CollectionOfSongs);

            return CollectionOfSongs;
        }
        internal Album AddAlbum()
        {
            string albumName = "";
            Artist artist = null;
            List<Song> songs = new List<Song>();

            var isCorrectAlbumName = false;
            while (!isCorrectAlbumName)
            {
                var str = InputName("альбома");
                if (str != null)
                {
                    albumName = str;
                    isCorrectAlbumName = true;
                }
                else
                {
                    Console.WriteLine("Uncorrect input!");
                }
            }

            var isCorrectArtist = false;
            while (!isCorrectArtist)
            {
                var art = ChoiceArtist();
                if (art != null)
                {
                    artist = art;
                    isCorrectArtist = true;
                }
                else
                {
                    Console.WriteLine("Uncorrect input!");
                }
            }

            var isCorrectSongs = false;
            while (!isCorrectSongs)
            {
                Console.WriteLine($"\t#: Окончание создания альбома\n\t0: Добавить новую песню в альбом");
                var input = Console.ReadLine();
                if (input == "#" && songs.Count != 0)
                {
                    isCorrectSongs = true;
                }
                else if (input == "0")
                {
                    songs.Add(AddSong());
                }
                else
                {
                    Console.WriteLine("Uncorrect input!");
                }
            }
            var album = new Album(albumName, songs, artist);
            _collections.Add(album);

            return album;
        }

        internal List<Artist> SearchArtistByName(string name)
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
        internal List<CollectionOfSongs> SearchCollectionsOfSongsByName(string name)
        {
            var list = new List<CollectionOfSongs>();
            foreach (var col in _collections)
            {
                if (col.Name.Contains(name))
                {
                    list.Add(col);
                }
            }
            return list;
        }
        internal List<Song> SearchSongByNameAndArtist(string name)
        {
            var songs = new List<Song>();
            Artist artist = null;

            var isCorrectArtist = false;
            while (!isCorrectArtist)
            {
                var ar = ChoiceArtist();
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

        internal FunctionsMusicCatalog(List<Artist> artists, List<Genre> genres,
            List<Song> songs, List<CollectionOfSongs> collections)
        {
            _artists = artists;
            _genres = genres;
            _collections = collections;
            _songs = songs;
        }
    }
}
