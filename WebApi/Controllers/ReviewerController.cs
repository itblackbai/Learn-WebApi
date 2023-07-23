using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : Controller
    {
        private readonly IReviwerRepository _reviwerRepository;
        private readonly IMapper _mapper;

        public ReviewerController(IReviwerRepository reviwerRepository , IMapper mapper)
        {
            _reviwerRepository = reviwerRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult GetReviewers()
        {
            var reviews = _mapper.Map<List<ReviewerDto>>(_reviwerRepository.GetReviewers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpGet("{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewer(int reviewerId)
        {
            if (!_reviwerRepository.ReviewerExists(reviewerId))
                return NotFound();

            var reviewer = _mapper.Map<ReviewerDto>(_reviwerRepository.GetReviewer(reviewerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }



        [HttpGet("{reviewerId}/reviews")]
        public IActionResult GetReviewsByAreviewer(int reviewerId)
        {
            if (!_reviwerRepository.ReviewerExists(reviewerId))
                return NotFound();

            var reviewer = _mapper.Map<List<ReviewDto>>(_reviwerRepository.GetReviewsByReviewer(reviewerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReviewer([FromBody] ReviewerDto reviewerCreate)
        {
            if (reviewerCreate == null)
                return BadRequest(ModelState);

            var country = _reviwerRepository.GetReviewers().
                Where(c => c.LastName.Trim().ToUpper() == reviewerCreate.LastName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (country != null)
            {
                ModelState.AddModelError("", "Reviewer already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewerMap = _mapper.Map<Reviewer>(reviewerCreate);

            if (!_reviwerRepository.CreateReviwer(reviewerMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }


            return Ok("Successfully created");

        }

        [HttpPut("reviwerId")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateReviwer(int reviwerId, [FromBody] ReviewerDto updatedReviwer)
        {
            if (updatedReviwer == null)
                return BadRequest(ModelState);

            if (reviwerId != updatedReviwer.Id)
                return BadRequest(ModelState);

            if (!_reviwerRepository.ReviewerExists(reviwerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviwerMap = _mapper.Map<Reviewer>(updatedReviwer);

            if (!_reviwerRepository.UpdateReviewer(reviwerMap))
            {
                ModelState.AddModelError("", "Something went wrong updating rewiver");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
