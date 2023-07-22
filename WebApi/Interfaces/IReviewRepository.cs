using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();

        Review GetReview(int reviewId);
        ICollection<Review> GetReviewsOfPokemon(int pokeId);
        bool ReviewExists(int reviewId);

        bool CreateReview(Review review);
        bool Save();
    }
}
