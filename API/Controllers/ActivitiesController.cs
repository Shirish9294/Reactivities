using API.Dtos;
using API.Services.Interface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return Ok(_response);
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
                return BadRequest(_response);
            }
            return Ok(_response);
        }
    }
}