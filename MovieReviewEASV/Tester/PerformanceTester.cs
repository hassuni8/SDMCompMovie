using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieReview;

namespace Tester
{
   
    [TestClass]
    public class PerformanceTester
    {
        static readonly MovieProgram movieProgram = new MovieProgram("ratings.json");

        const double MAXTIME = 4;

        /*
         * Den første test går ikke igennem, medmindre jeg bruger den her til at fjerne tiden til at starte op.
         */
        [TestMethod]
        public void StartTest()
        {
            Stopwatch sw = Stopwatch.StartNew(); ;
            movieProgram.GetReviews(1);
            sw.Stop();

            var seconds = sw.ElapsedMilliseconds / 1000.0;

            Assert.IsTrue(seconds <= MAXTIME);
        }

        [TestMethod]
        public void PerformanceTestGetReviews()
        {
            Stopwatch sw = Stopwatch.StartNew(); ;
            movieProgram.GetReviews(1);
            sw.Stop();

            var seconds = sw.ElapsedMilliseconds / 1000.0;

            Assert.IsTrue(seconds <= MAXTIME);
        }

        [TestMethod]
        public void PerformanceTestGetAvgGradeByReviewer()
        {
            Stopwatch sw = Stopwatch.StartNew();
            movieProgram.GetAvgGradeByReviewer(1);
            sw.Stop();

            var seconds = sw.ElapsedMilliseconds / 1000.0;

            Assert.IsTrue(seconds <= MAXTIME);
        }

        [TestMethod]
        public void PerformanceTestGetReviewersSpecificGrade()
        {
            Stopwatch sw = Stopwatch.StartNew(); ;
            movieProgram.GetReviewersSpecificGrade(2, 4);
            sw.Stop();

            var seconds = sw.ElapsedMilliseconds / 1000.0;

            Assert.IsTrue(seconds <= MAXTIME);
        }

        [TestMethod]
        public void PerformanceTestGetMoviesNumberOfReviews()
        {
            Stopwatch sw = Stopwatch.StartNew(); ;
            movieProgram.GetMoviesNumberOfReviews(1488844);
            sw.Stop();

            var seconds = sw.ElapsedMilliseconds / 1000.0;

            Assert.IsTrue(seconds <= MAXTIME);
        }

        [TestMethod]
        public void PerformanceTestGetAvgMovieRating()
        {
            Stopwatch sw = Stopwatch.StartNew(); ;
            movieProgram.GetAvgMovieRating(1488844);
            sw.Stop();

            var seconds = sw.ElapsedMilliseconds / 1000.0;

            Assert.IsTrue(seconds <= MAXTIME);
        }

        [TestMethod]
        public void PerformanceTestGetMoviesExactRating()
        {
            Stopwatch sw = Stopwatch.StartNew(); ;
            movieProgram.GetMoviesExactRating(1488844, 3);
            sw.Stop();

            var seconds = sw.ElapsedMilliseconds / 1000.0;

            Assert.IsTrue(seconds <= MAXTIME);
        }

        [TestMethod]
        public void PerformanceTestGetHighestReviewsMovies()
        {
            Stopwatch sw = Stopwatch.StartNew(); ;
            movieProgram.GetHighestReviewsMovies();
            sw.Stop();

            var seconds = sw.ElapsedMilliseconds / 1000.0;

            Assert.IsTrue(seconds <= MAXTIME);
        }


    }
}


