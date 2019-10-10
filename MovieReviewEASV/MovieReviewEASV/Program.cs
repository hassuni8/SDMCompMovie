using System;

namespace MovieReview
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieProgram movieProgram = new MovieProgram();
            foreach (var review in movieProgram.reviewsMovie)
            {
                System.Console.WriteLine($"Reviewers {review.Reviewer} Movie Number: {review.Movie}, Grade: {review.Grade}, Date: {review.Date}");
            }
        }
    }
}
