using AutoMapper;
using BSBookingQuery.Domain.DTOs;
using BSBookingQuery.Domain.Entities;
using BSBookingQuery.Domain.Interfaces;
using BSBookingQuery.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BSBookingQuery.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccountController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> LogIn([FromBody]LogInDto logInDto)
        {
            var entity = await _unitOfWork.Accounts.LogIn(logInDto);
            return Json(entity);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Register([FromBody]RegisterDto registerDto)
        {
            var entity = await _unitOfWork.Accounts.Register(registerDto);
            _unitOfWork.Complete();
            return Json(entity);
        }

        [HttpGet]
        public JsonResult GetAllUserTypes()
        {
            var entity = _unitOfWork.Accounts.GetAllUserTypes();
            return Json(entity);
        }

    }
}
