using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repository
{
    public class ReviewerRepository : IReviwerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ReviewerRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Reviewer GetReviewer(int reviverId)
        {
            return _context.Reviewers.Where(r => r.Id == reviverId).Include(e => e.Reviews).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
           return _context.Reviewers.ToList();
        }

        public ICollection<Reviewer> GetReviewersByReviewer(int reviewerId)
        {
            return (ICollection<Reviewer>)_context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        }
        public bool ReviewerExists(int reviewerId)
        {
            return _context.Reviewers.Any(r => r.Id == reviewerId);
        }
    }
}
