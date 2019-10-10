using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieReview;
namespace Tester
{
    [TestClass]
    public class UnitTest1
    {
        //1
        [TestMethod]
        public void TestGetReviews()
        {
            MovieProgram movieProgram = new MovieProgram();
            movieProgram.Data("MovieReviewEASV/Test.json");
            Assert.AreEqual(4, movieProgram.GetReviews(1));
        }

        [TestMethod]
        public void TestTestIsNegative()
        {
            MovieProgram movieProgram = new MovieProgram();
            movieProgram.Data("MovieReviewEASV/Test.json");
            Assert.IsFalse(movieProgram.GetReviews(1) < 0);
        }

        //2
        [TestMethod]
        public void TestGetAvgGradeByReviewer()
        {
            MovieProgram movieProgram = new MovieProgram();
            movieProgram.Data("MovieReviewEASV/Test.json");
            Assert.AreEqual(4, movieProgram.GetAvgGradeByReviewer(1));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Missing grades from reviewer.")]
        public void TestGetAvgGradeByReviewerException()
        {
            MovieProgram movieProgram = new MovieProgram();
            movieProgram.Data("TestJsons/Test.json");
            movieProgram.GetAvgGradeByReviewer(4);
        }

        // opgave 3
        [TestMethod]
        public void TestGetReviewersSpecificGrade()
        {
            MovieProgram movieProgram = new MovieProgram();
            movieProgram.Data("TestJsons/Test.json");
            Assert.AreEqual(3, movieProgram.GetReviewersSpecificGrade(2, 4));
        }

        //4
        [TestMethod]
        public void TestNumberOfReviewsByMovie()
        {
            MovieProgram movieProgram = new MovieProgram();
            movieProgram.Data("TestJsons/Test.json");
            Assert.AreEqual(1, movieProgram.GetMoviesNumberOfReviews(1488844));
        }

        //5
        [TestMethod]
        public void TestGetAvgMovieRating()
        {
            MovieProgram movieProgram = new MovieProgram();
            movieProgram.Data("TestJsons/Test.json");
            Assert.AreEqual(3, movieProgram.GetAvgMovieRating(1488844));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Movie hasnt been rated")]

        public void TestGetAvgMovieRatingException()
        {
            MovieProgram movieProgram = new MovieProgram();
            movieProgram.Data("TestJsons/Test.json");
            movieProgram.GetAvgMovieRating(885014);

        }

        //6
        [TestMethod]
        public void TestGetMoviesExactRating()
        {
            MovieProgram movieProgram = new MovieProgram();
            movieProgram.Data("TestJsons/Test.json");
            Assert.AreEqual(1, movieProgram.GetMoviesExactRating(1488844, 3));
        }

        //7
        [TestMethod]
        public void TestGetHighestReviewsMovies()
        {
            MovieProgram movieProgram = new MovieProgram();
            movieProgram.Data("TestJsons/Test.json");
            Assert.AreEqual(822109, movieProgram.GetHighestReviewsMovies());
        }

        //8
        [TestMethod]
        public void TestGetHighestReviewer()
        {
            MovieProgram movieProgram = new MovieProgram();
            movieProgram.Data("TestJsons/Test.json");
            Assert.AreEqual(2, movieProgram.GetHighestReviewer());
        }

        //10
        [TestMethod]
        public void TestReviewerTopReviewedMovie()
        {
            MovieProgram movieProgram = new MovieProgram();
            movieProgram.Data("TestJsons/Test.json");
            Assert.AreEqual(822109, movieProgram.GetReviewersReviewedMovie(1).First());
        }

        [TestMethod]
        public void TestReviewedMovieByDateAtSameGrade()
        {
            MovieProgram movieProgram = new MovieProgram();
            movieProgram.Data("TestJsons/Test.json");
            Assert.AreEqual(885013, movieProgram.GetReviewersReviewedMovie(1).ElementAt(1));
        }

        [TestMethod]
        public void TestLowestReviewedMovie()
        {
            MovieProgram movieProgram = new MovieProgram();
            movieProgram.Data("TestJsons/Test.json");
            Assert.AreEqual(1488844, movieProgram.GetReviewersReviewedMovie(1).Last());
        }

        //10
        [TestMethod]
        public void TestHighestReviewerByMovie()
        {
            MovieProgram movieProgram = new MovieProgram();
            movieProgram.Data("TestJsons/Test.json");
            Assert.AreEqual(1, movieProgram.GetReviewersFromMovie(822109).First());
        }

        [TestMethod]
        public void TestReviewerDateAtSameGrade()
        {
            MovieProgram movieProgram = new MovieProgram();
            movieProgram.Data("TestJsons/Test.json");
            Assert.AreEqual(2, movieProgram.GetReviewersFromMovie(822109).ElementAt(1));
        }

        [TestMethod]
        public void TestLowestReviewerOfMovie()
        {
            MovieProgram movieProgram = new MovieProgram();
            movieProgram.Data("TestJsons/Test.json");
            Assert.AreEqual(1, movieProgram.GetReviewersFromMovie(822109).Last());
        }
    }
}

