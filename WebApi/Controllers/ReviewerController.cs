﻿using AutoMapper;
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



        [HttpGet("{reviewerId/reviews")]
        public IActionResult GetReviewsByAreviewer(int reviewerId)
        {
            if (!_reviwerRepository.ReviewerExists(reviewerId))
                return NotFound();

            var reviewer = _mapper.Map<List<ReviewerDto>>(_reviwerRepository.GetReviewersByReviewer(reviewerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }

    }
}