using AutoMapper;
using BSBookingQuery.Domain.DTOs;
using BSBookingQuery.Domain.Entities;
using BSBookingQuery.Domain.Interfaces;
using BSBookingQuery.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BSBookingQuery.Controllers
{
    [Route("[controller]/[action]")]
    public class CommentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<JsonResult> GetAllComments()
        {
            var comments = await _unitOfWork.Comments.GetAllComments();
            return Json(comments);
        }

        [HttpPost]
        public int AddComment([FromBody] CommentDto commentDto)
        {
            CommentHistory entity = _mapper.Map<CommentHistory>(commentDto);
            _unitOfWork.Comments.Add(entity);
            return _unitOfWork.Complete();
        }
    }
}
