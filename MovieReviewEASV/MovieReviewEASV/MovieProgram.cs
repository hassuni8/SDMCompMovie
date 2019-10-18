using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace MovieReview
{
    public class MovieProgram : IMovieProgram
    {
        ReviewMovie reviewMovie = new ReviewMovie();

        public List<ReviewMovie> reviewsMovie;

        public MovieProgram(string fileName)
        {
            Data(fileName);
        }

        public void Data(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                reviewsMovie = JsonConvert.DeserializeObject<List<ReviewMovie>>(json);
            }
        }

        public void GetTimeInSeconds(Action ac, int repeats)
        {
            for (int i = 0; i < repeats; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                ac.Invoke();
                sw.Stop();
                Console.WriteLine("Time = {0:f5}", sw.ElapsedMilliseconds / 1000.0);
            }
        }

        //1
        public int GetReviews(int reviewerId)
        {
            int amount = 0;
            foreach (var reviewMovie in reviewsMovie)
            {
                if (reviewMovie.Reviewer == reviewerId)
                {
                    amount++;
                }
            }
            return amount;
        }

        //2
        public int GetAvgGradeByReviewer(int reviewerId)
        {
            int amount = 0;
            int sumGrade = 0;
            foreach (var reviewMovie in reviewsMovie)
            {
                if (reviewMovie.Reviewer == reviewerId)
                {
                    amount++;
                    sumGrade = sumGrade + reviewMovie.Grade;
                }
            }
            if (sumGrade == 0)
            {
                throw new Exception("No movies have been graded by this reviewer.");
            }
            int avgGrade = (sumGrade / amount);
            return avgGrade;
        }

        //3
        public int GetReviewersSpecificGrade(int reviewerId, int grade)
        {
            int amountOfGrades = 0;

            foreach (var reviewMovie in reviewsMovie)
            {
                if (reviewMovie.Reviewer == reviewerId && reviewMovie.Grade == grade)
                {
                    amountOfGrades++;
                }
            }
            return amountOfGrades;

        }

        //4
        public int GetMoviesNumberOfReviews(int movieId)
        {
            int amountOfReviews = 0;

            foreach (var reviewMovie in reviewsMovie)
            {
                if (reviewMovie.Movie == movieId)
                {
                    amountOfReviews++;
                }
            }
            return amountOfReviews;

        }

        //5
        public int GetAvgMovieRating(int movieId)
        {
            int amount = 0;
            int sumRating = 0;
            foreach (var reviewMovie in reviewsMovie)
            {
                if (reviewMovie.Movie == movieId)
                {
                    amount++;
                    sumRating = sumRating + reviewMovie.Grade;
                }
            }
            if (sumRating == 0)
            {
                throw new Exception("This movie hasnt been rated");
            }
            int avgRating = (sumRating / amount);
            return avgRating;
        }

        //6
        public int GetMoviesExactRating(int movieId, int grade)
        {
            int amountOfRatings = 0;

            foreach (var reviewMovie in reviewsMovie)
            {
                if (reviewMovie.Movie == movieId && reviewMovie.Grade == grade)
                {
                    amountOfRatings++;
                }
            }
            return amountOfRatings;
        }

        //7
        public int GetHighestReviewsMovies()
        {
            IEnumerable<ReviewMovie> BestRatedMovie = reviewsMovie.Where(r => r.Grade == 5);
            BestRatedMovie.GroupBy(r => r.Movie).OrderByDescending(gru => gru.Count());
            var topMovie = BestRatedMovie.First().Movie;
            return topMovie;
        }

        //8
        public int GetHighestReviewer()
        {
            var highestReviewer = reviewsMovie.GroupBy(r => r.Reviewer)
                .OrderByDescending(gru => gru.Count()).Select(gru => gru.Key)
                .First();
            return highestReviewer;
        }


        //9
        public int GetTopAverageMovie()
        {
            throw new NotImplementedException();
        }

        //10
        public List<int> GetReviewersReviewedMovie(int reviewerId)
        {
            var reviewList = reviewsMovie.Where(r => r.Reviewer == reviewerId)
                .OrderByDescending(r => r.Grade)
                .ThenBy(r => r.Date).ToArray();

            List<int> movies = new List<int>();
            foreach (var movie in reviewList)
            {
                movies.Add(movie.Movie);
            }

            return movies;
        }

        //11
        public List<int> GetReviewersFromMovie(int movieId)
        {
            var reviewList = reviewsMovie.Where(r => r.Movie == movieId)
                .OrderByDescending(r => r.Grade)
                .ThenBy(r => r.Date)
                .Select (r => r.Reviewer)
                .ToList();


          
            

            return reviewList;
        }
    }



    public class ReviewMovie
    {
        public int Reviewer;
        public int Movie;
        public int Grade;
        public DateTime Date;
    }
}
