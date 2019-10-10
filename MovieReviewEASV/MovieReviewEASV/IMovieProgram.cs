using System;
using System.Collections.Generic;

namespace MovieReview
{
    public interface IMovieProgram
    {

        int GetReviews(int reviewerId);
         int GetAvgGradeByReviewer(int reviewerId);
         int GetReviewersSpecificGrade(int reviewerId, int grade);
         int GetMoviesNumberOfReviews(int movieId);
         int GetAvgMovieRating(int movieId);
         int GetMoviesExactRating(int movieId, int grade);
         int GetHighestReviewsMovies();
         int GetHighestReviewer();
         int GetTopAverageMovie();
         List<int> GetReviewersReviewedMovie(int reviewerId);
         List<int> GetReviewersFromMovie(int movieId);

    }
}
