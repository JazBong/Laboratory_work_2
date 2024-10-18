using ConsoleApp3.Entities;

namespace ConsoleApp3.Services
{
    internal class CollectionsOfSongsService
    {
        private readonly List<CollectionOfSongs> _collections;
        private readonly FunctionsMusicCatalog _functionsMusicCatalog;

        private CollectionOfSongs CreateCollectionOfSongs()
        {
            string collectionOfSongsName = "";
            List<Song> songs = new List<Song>();

            var isCorrectCollectionOfSongsName = false;
            while (!isCorrectCollectionOfSongsName)
            {
                var str = _functionsMusicCatalog.InputName("коллекции");
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
                var s = _functionsMusicCatalog.SongService.ChoiceSongs();
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
                var str = _functionsMusicCatalog.InputName("альбома");
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
                var art = _functionsMusicCatalog.ArtistService.ChoiceArtist();
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
                    songs.Add(_functionsMusicCatalog.SongService.AddSong());
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

        internal CollectionsOfSongsService(List<CollectionOfSongs> collections, FunctionsMusicCatalog functionsMusicCatalog)
        {
            _collections = collections;
            _functionsMusicCatalog = functionsMusicCatalog;
        }
    }
}
