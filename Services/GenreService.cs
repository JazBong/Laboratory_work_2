using ConsoleApp3.Entities;

namespace ConsoleApp3.Services
{
    internal class GenreService
    {
        private readonly List<Genre> _genres;
        private readonly FunctionsMusicCatalog _functionsMusicCatalog;

        internal List<Genre> ChoiceGenres()
        {
            List<Genre> genreList = [];
            Console.WriteLine("Выберите жанры, разделитель пробел:");
            Console.WriteLine("\n\t0: Добавить новый жанр");
            _functionsMusicCatalog.PrintNameObjectCollection(_genres);
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
        internal Genre AddGenre()
        {
            var isCorrectData = false;
            string genreName = "";

            while (!isCorrectData)
            {
                var str = _functionsMusicCatalog.InputName("жанра");
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

        internal GenreService(List<Genre> genres, FunctionsMusicCatalog functionsMusicCatalog)
        {
            _genres = genres;
            _functionsMusicCatalog = functionsMusicCatalog;
        }
    }
}
