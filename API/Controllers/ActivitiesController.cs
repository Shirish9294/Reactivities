using API.Dtos;
using API.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    // [ApiController]
    // [Route("api/[controller]")]
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IActivitiesRepo _repo;
        private readonly ResponseDto _response=new();
        public ActivitiesController(DataContext context,IActivitiesRepo repo)
        {
            _context=context;
            _repo=repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            try{
                _response.isSuccess=true;
                 _response.Result = await _repo.GetActivities(); 
            }
            catch(Exception ex){
                _response.isSuccess=false;
                _response.ErrorMessage=ex.Message;
                return BadRequest(_response);
            }
            return Ok(_response.Result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivitiy(Guid id)
        {
            try{
                _response.isSuccess=true;
                 _response.Result = await _repo.GetActivity(id); 
            }
            catch(Exception ex){
                _response.isSuccess=false;
                _response.ErrorMessage=ex.Message;
                return BadRequest(_response.Result);
            }
            return Ok(_response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(ActivityDto activityDto)
        {
            try
            {
                ActivityDto activity = await _repo.CreateActivity(activityDto);
                _response.Result = activity;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessage = ex.Message;
                return BadRequest(_response);
            }
            return Ok(_response.Result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity([FromRoute] Guid id,[FromBody] UpdateActivityDto activityDto)
        {
            try
            {
                UpdateActivityDto activity = await _repo.EditActivity(id, activityDto);
                _response.Result = activity;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessage = ex.Message;
                return BadRequest(_response);
            }
            return Ok(_response.Result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            try
            {
                bool isSuccess = await _repo.DeleteActivity(id);
                _response.Result = isSuccess;
                if (isSuccess == false)
                {
                    _response.isSuccess = false;
                    _response.ErrorMessage = "Invalid Id";
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessage = ex.Message;
                return BadRequest(_response);
            }
            return Ok(_response);
        }
    }
}