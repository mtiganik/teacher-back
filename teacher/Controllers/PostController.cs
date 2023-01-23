using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using teacher.Models.Dtos;
using teacher.Models.Models;
using teacher.Services.Interfaces;

namespace teacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : BaseApiController
    {
        public PostController(IServiceManager serviceManager, ILoggerManager logger, IMapper mapper) : base(serviceManager, logger, mapper)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostCreateDto post)
        {
            var postData = _mapper.Map<Post>(post);
            await _serviceManager.Post.CreatePost(postData);
            await _serviceManager.SaveAsync();
            var postReturn = _mapper.Map<PostDto>(postData);
            return Ok(postReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] PostUpdateDto post)
        {
            var postData = HttpContext.Items["post"] as Post;
            _mapper.Map(post, postData);
            await _serviceManager.SaveAsync();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int postId)
        {
            try
            {
                var post = await _serviceManager.Post.GetPost(postId);
                if (post == null) return NotFound();
                var postDto = _mapper.Map<PostDto>(post);
                return Ok(postDto);
            }catch(Exception ex)
            {
                _logger.LogError($"Somethinng went wrong in the {nameof(GetPost)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var postList = await _serviceManager.Post.GetPostList();
            var postDtoList = _mapper.Map<List<PostDto>>(postList);
            return Ok(postDtoList);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost(int postId)
        {
            try
            {
                var postToDelete = await _serviceManager.Post.GetPost(postId);
                await _serviceManager.Post.DeletePost(postToDelete);
                return Ok("Post succesfully deleted");
            }catch(Exception ex)
            {
                _logger.LogError($"Something went wrong with {nameof(DeletePost)} action {ex}");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
