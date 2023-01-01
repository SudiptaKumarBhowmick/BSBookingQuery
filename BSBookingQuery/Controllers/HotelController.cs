using AutoMapper;
using BSBookingQuery.Domain.DTOs;
using BSBookingQuery.Domain.Entities;
using BSBookingQuery.Domain.Interfaces;
using BSBookingQuery.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BSBookingQuery.Controllers
{
    [Route("[controller]/[action]")]
    public class HotelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetAllHotels()
        {
            var hotels = await _unitOfWork.Hotels.GetAllHotels();
            return Json(hotels);
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> GetHotelById(int id)
        {
            var hotel = await _unitOfWork.Hotels.Get(id);
            return Json(hotel);
        }

        [HttpPost]
        public int AddHotel([FromBody] HotelDto hotelDto)
        {
            Hotel entity = _mapper.Map<Hotel>(hotelDto);

            entity.HotelId = GenerateAutoHotelId.GenerateHotelId(entity.Name);

            _unitOfWork.Hotels.Add(entity);
            return _unitOfWork.Complete();
        }

        [HttpPut("{id}")]
        public async Task<int> UpdateHotel(int id, [FromBody] HotelDto hotelDto)
        {
            var entity = await _unitOfWork.Hotels.Get(id);

            if (entity != null)
            {
                _mapper.Map(hotelDto, entity);

                _unitOfWork.Hotels.Update(entity);
                return _unitOfWork.Complete();
            }

            return 0;
        }

        [HttpDelete("{id}")]
        public async Task<int> DeleteHotel(int id)
        {
            var entity = await _unitOfWork.Hotels.Get(id);

            if (entity != null)
            {
                _unitOfWork.Hotels.Delete(entity);
                return _unitOfWork.Complete();
            }

            return 0;
        }

        [HttpGet]
        public ActionResult Single()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetHotelsBySearchParam([FromBody] SearchParamDto searchParam)
        {
            var entity = await _unitOfWork.Hotels.GetHotelsBySearchParam(searchParam);
            return Json(entity);
        }

    }
}
