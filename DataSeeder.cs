using ConsoleApp3.Entities;

namespace ConsoleApp3
{
    internal class DataSeeder
    {
        internal (List<Artist> artists, List<Genre> genres, List<Song> songs, List<CollectionOfSongs> collections) InitializationDataMusicCatalog()
        {
            // имитация существующих данных
            var artist1 = new Artist("Artist 1", new DateOnly(2001, 1, 1));
            var artist2 = new Artist("Artist 2", new DateOnly(2002, 2, 2));
            var artist3 = new Artist("Artist 3", new DateOnly(2003, 3, 3));
            var artist4 = new Artist("Artist 4", new DateOnly(2004, 4, 4));
            var artist5 = new Artist("Artist 5", new DateOnly(2005, 5, 5));

            var genre1 = new Genre("Genre 1");
            var genre2 = new Genre("Genre 2");
            var genre3 = new Genre("Genre 3");
            var genre4 = new Genre("Genre 4");
            var genre5 = new Genre("Genre 5");

            var song1 = new Song("Song 1", new List<Genre> { genre1, genre2 }, artist1, new DateOnly(2011, 1, 1));
            var song2 = new Song("Song 2", new List<Genre> { genre1, genre3 }, artist1, new DateOnly(2012, 1, 1));
            var song3 = new Song("Song 3", new List<Genre> { genre1 }, artist1, new DateOnly(2013, 1, 1));
            var song4 = new Song("Song 4", new List<Genre> { genre3, genre2 }, artist2, new DateOnly(2014, 1, 1));
            var song5 = new Song("Song 5", new List<Genre> { genre4 }, artist2, new DateOnly(2015, 1, 1));
            var song6 = new Song("Song 6", new List<Genre> { genre1, genre2 }, artist3, new DateOnly(2016, 1, 1));
            var song7 = new Song("Song 7", new List<Genre> { genre3, genre2 }, artist3, new DateOnly(2017, 1, 1));
            var song8 = new Song("Song 8", new List<Genre> { genre3, genre5 }, artist4, new DateOnly(2018, 1, 1));
            var song9 = new Song("Song 9", new List<Genre> { genre5 }, artist5, new DateOnly(2019, 1, 1));

            Album album1 = new Album("Album 1", artist1);
            album1.Songs.Add(song1);
            album1.Songs.Add(song2);
            album1.Songs.Add(song3);
            Album album2 = new Album("Album 2", artist2);
            album2.Songs.Add(song4);
            album2.Songs.Add(song5);
            Album album3 = new Album("Album 3", artist3);
            album3.Songs.Add(song6);
            album3.Songs.Add(song7);
            Album album4 = new Album("Album 4", artist4);
            album4.Songs.Add(song8);
            Album album5 = new Album("Album 5", artist5);
            album5.Songs.Add(song9);
            CollectionOfSongs collectionOfSongs1 = new CollectionOfSongs("COS 1");
            collectionOfSongs1.Songs.Add(song1);
            collectionOfSongs1.Songs.Add(song2);
            collectionOfSongs1.Songs.Add(song3);
            collectionOfSongs1.Songs.Add(song7);
            collectionOfSongs1.Songs.Add(song9);
            CollectionOfSongs collectionOfSongs2 = new CollectionOfSongs("COS 2");
            collectionOfSongs2.Songs.Add(song5);
            collectionOfSongs2.Songs.Add(song6);
            CollectionOfSongs collectionOfSongs3 = new CollectionOfSongs("COS 3");
            collectionOfSongs3.Songs.Add(song1);
            collectionOfSongs3.Songs.Add(song5);
            collectionOfSongs3.Songs.Add(song9);

            var artists = new List<Artist>()
            {
                artist1, artist2, artist3, artist4, artist5,
            };

            var genres = new List<Genre>()
            {
                genre1, genre2, genre3, genre4, genre5,
            };

            var songs = new List<Song>()
            {
                song1, song2, song3, song4, song5, song6, song7, song8, song9,
            };

            var collections = new List<CollectionOfSongs>()
            {
                album1, album2, album3, album4, album5,
                collectionOfSongs1, collectionOfSongs2, collectionOfSongs3,
            };

            return (artists, genres, songs, collections);
        }
    }
}
