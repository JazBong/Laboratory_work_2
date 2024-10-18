using ConsoleApp3.Entities;
using ConsoleApp3.Services;

namespace ConsoleApp3
{
    internal class MusicCatalog
    {
        internal List<Artist> Artists { get; private set; }
        internal List<Genre> Genres { get; private set; }
        internal List<Song> Songs { get; private set; }
        internal List<CollectionOfSongs> Collections { get; private set; }
        internal FunctionsMusicCatalog funcWorkWithCatalog;


        internal void Work()
        {
            var isWork = true;
            while (isWork)
            {
                Console.WriteLine($"\nВыберите действие:\n\n\t0: Окончание работы с каталогом\n\n\t1: Вывод всех имеющихся Артистов\n\t2: Вывод всех имеющихся Жанров" +
                $"\n\t3: Вывод всех имеющихся Песен\n\t4: Вывод всех имеющихся Плейлистов\n\n\t5: Добавление нового Артиста\n\t6: Добавление нового Жанра" +
                $"\n\t7: Добавление новой Песни\n\t8: Добавление нового Сборника\n\t9: Добавление нового Альбома\n\n\t10: Поиск Артиста по имени\n\t11: Поиск Плейлистов по имени" +
                $"\n\t12: Поиск Песен по имени и Артисту");

                if (int.TryParse(Console.ReadLine(), out var act))
                {
                    switch (act)
                    {
                        case 0:
                            isWork = false;
                            break;

                        case 1:
                            funcWorkWithCatalog.PrintNameObjectCollection(Artists);
                            break;

                        case 2:
                            funcWorkWithCatalog.PrintNameObjectCollection(Genres);
                            break;

                        case 3:
                            funcWorkWithCatalog.PrintNameObjectCollection(Songs);
                            break;

                        case 4:
                            funcWorkWithCatalog.PrintNameObjectCollection(Collections);
                            break;

                        case 5:
                            funcWorkWithCatalog.ArtistService.AddArtist();
                            break;

                        case 6:
                            funcWorkWithCatalog.GenreService.AddGenre();
                            break;

                        case 7:
                            funcWorkWithCatalog.SongService.AddSong();
                            break;

                        case 8:
                            funcWorkWithCatalog.CollectionsOfSongsService.AddCollectionOfSongs();
                            break;

                        case 9:
                            funcWorkWithCatalog.CollectionsOfSongsService.AddAlbum();
                            break;

                        case 10:
                            Console.WriteLine($"\nВведите имя или часть имени для поиска Артиста");
                            var inputNameArtist = Console.ReadLine();
                            if (!string.IsNullOrEmpty(inputNameArtist))
                            {
                                funcWorkWithCatalog.PrintNameObjectCollection(funcWorkWithCatalog.ArtistService.SearchArtistsByName(inputNameArtist));
                            }
                            break;
                        case 11:
                            Console.WriteLine($"\nВведите имя или часть имени для поиска Плейлиста");
                            var inputName = Console.ReadLine();
                            if (!string.IsNullOrEmpty(inputName))
                            {
                                funcWorkWithCatalog.PrintNameObjectCollection(funcWorkWithCatalog.CollectionsOfSongsService.SearchCollectionsOfSongsByName(inputName));
                            }
                            break;

                        case 12:
                            Console.WriteLine($"\nВведите имя или часть имени песни");
                            var inputNameSong = Console.ReadLine();
                            if (!string.IsNullOrEmpty(inputNameSong))
                            {
                                funcWorkWithCatalog.PrintNameObjectCollection(funcWorkWithCatalog.SongService.SearchSongsByNameAndArtist(inputNameSong));
                            }
                            break;


                        default:
                            Console.WriteLine("Uncorrect input!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Uncorrect input!");
                }
            }
        }
        internal MusicCatalog()
        {
            DataSeeder dataSeeder = new DataSeeder();
            (Artists, Genres, Songs, Collections) = dataSeeder.InitializationDataMusicCatalog();
            funcWorkWithCatalog = new FunctionsMusicCatalog(Artists, Genres, Songs, Collections);
        }
    }
}
