using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IReviwerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviverId);
        ICollection<Reviewer> GetReviewersByReviewer(int reviewerId);
        bool ReviewerExists(int reviewerId);
    }
}
