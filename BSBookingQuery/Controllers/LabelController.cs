using AutoMapper;
using BSBookingQuery.Domain.DTOs;
using BSBookingQuery.Domain.Entities;
using BSBookingQuery.Domain.Interfaces;
using BSBookingQuery.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BSBookingQuery.Controllers
{
    [Route("[controller]/[action]")]
    public class LabelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LabelController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetAllLabels()
        {
            var labels = await _unitOfWork.Labels.GetAll();
            return Json(labels);
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> GetLabelById(int id)
        {
            var label = await _unitOfWork.Labels.Get(id);
            return Json(label);
        }

        [HttpPost]
        public int AddLabel([FromBody]LabelDto labelDto)
        {
            Label entity = _mapper.Map<Label>(labelDto);

            _unitOfWork.Labels.Add(entity);
            return _unitOfWork.Complete();
        }

        [HttpPut("{id}")]
        public async Task<int> UpdateLabel(int id, [FromBody] LabelDto labelDto)
        {
            var entity = await _unitOfWork.Labels.Get(id);

            if (entity != null)
            {
                _mapper.Map(labelDto, entity);

                _unitOfWork.Labels.Update(entity);
                return _unitOfWork.Complete();
            }

            return 0;
        }

        [HttpDelete("{id}")]
        public async Task<int> DeleteLabel(int id)
        {
            var entity = await _unitOfWork.Labels.Get(id);

            if (entity != null)
            {
                _unitOfWork.Labels.Delete(entity);
                return _unitOfWork.Complete();
            }

            return 0;
        }

    }
}
