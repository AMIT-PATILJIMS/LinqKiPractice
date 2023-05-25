using System;
using System.Linq;

namespace LINQPrac 
{
    public class Singer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Concert
    {
        public int SingerId { get; set; }
        public int ConcertCount { get; set; }
        public int Year { get; set; }
    }


    public class Program
    {
        public static IEnumerable<Singer> GetSingers()
        {
            return new List<Singer>()
            {
              new Singer(){Id = 1, FirstName = "Freddie", LastName = "Mercury"}
            , new Singer(){Id = 2, FirstName = "Elvis", LastName = "Presley"}
            , new Singer(){Id = 3, FirstName = "Chuck", LastName = "Berry"}
            , new Singer(){Id = 4, FirstName = "Ray", LastName = "Charles"}
            , new Singer(){Id = 5, FirstName = "David", LastName = "Bowie"}
            };
        }

        public static IEnumerable<Concert> GetConcerts()
        {
            return new List<Concert>()
            {
                new Concert(){SingerId = 1, ConcertCount = 53, Year = 1979}
                , new Concert(){SingerId = 1, ConcertCount = 74, Year = 1980}
                , new Concert(){SingerId = 1, ConcertCount = 38, Year = 1981}
                , new Concert(){SingerId = 2, ConcertCount = 43, Year = 1970}
                , new Concert(){SingerId = 2, ConcertCount = 64, Year = 1968}
                , new Concert(){SingerId = 3, ConcertCount = 32, Year = 1960}
                , new Concert(){SingerId = 3, ConcertCount = 51, Year = 1961}
                , new Concert(){SingerId = 3, ConcertCount = 95, Year = 1962}
                , new Concert(){SingerId = 4, ConcertCount = 42, Year = 1950}
                , new Concert(){SingerId = 4, ConcertCount = 12, Year = 1951}
                , new Concert(){SingerId = 5, ConcertCount = 53, Year = 1983}
            };
        }
        public static void Main()
        {
            var singers = GetSingers();
            var conserts = GetConcerts();

            //when we want to traverse from last in List or array
            var result = singers.Last(s => s.LastName == "Berry");


            // The Index is 0 based so to fetch 3 element we use 2
            var elementAtIndex = singers.ElementAt(2);

            /*
             * If there’s no element at the specified index then an ArgumentOutOfRangeException is thrown. To avoid that you can use the ElementAtOrDefault operator instead
              */

            var elementAtIndexType2 = singers.ElementAtOrDefault(100);


            // Get minimum element from the List
            IEnumerable<int> Container = new List<int> { 54, 23, 76, 123, 93, 7, 3489 };

            var x = Container.Min();

            //Applying these in array of string gives us alphabetically minumum value.
            var lstOfNames = new string[]{"ACDC", "Queen", "Aerosmith", "Iron Maiden", "Megadeth", "Metallica", "Cream", "Oasis", "Abba", "Blur", "Chic", "Eurythmics", "Genesis", "INXS", "Midnight Oil", "Kent", "Madness", "Manic Street Preachers"          , "Noir Desir", "The Offspring", "Pink Floyd", "Rammstein", "Red Hot Chili Peppers", "Tears for Fears"                      , "Deep Purple"};
            //here the output is "Abba"
            var smallestNameInAlphabetically = lstOfNames.Min();


            /*
             * Most Important : Joins in LINQ
             */

            var resultInJoin = singers.Join(conserts, s => s.Id, c => c.SingerId, (s,c) => new {
                id = s.Id,
                SingerName = string.Concat(s.FirstName, " ", s.LastName),
                concertCount = c.ConcertCount,
                year = c.Year
            });

            /*
             * Joins with group by
             * */

            var resultInJoinWithGroupBy = singers.Join(conserts, s => s.Id, c => c.SingerId, (s, c) => new {
                id = s.Id,
                SingerName = string.Concat(s.FirstName, " ", s.LastName),
                concertCount = c.ConcertCount,
                year = c.Year
            }).GroupBy(x => x.year);

            foreach (var row in resultInJoin)
            {
                Console.WriteLine(row.id);
            }

            Console.WriteLine(elementAtIndex.FirstName + " " + elementAtIndex.LastName);
        }
    }
}
