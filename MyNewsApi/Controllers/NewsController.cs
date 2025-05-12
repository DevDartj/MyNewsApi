using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyNewsApi.Data;
using MyNewsApi.DTOs;
using MyNewsApi.Models;

namespace MyNewsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE: POST api/news
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewsDto newsDto)
        {
            var news = new News
            {
                Title = newsDto.Title,
                Content = newsDto.Content,
                PublishedAt = DateTime.UtcNow,
                CategoryId = newsDto.CategoryId   // Associa la news alla categoria corretta
            };

            await _context.News.AddAsync(news);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = news.Id }, news);
        }

        // READ: Get all news
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var newsList = await _context.News.ToListAsync();
            return Ok(newsList);
        }

        // READ: GET api/news/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return Ok(news);
        }

        // UPDATE: PUT api/news/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] NewsDto newsDto)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            news.Title = newsDto.Title;
            news.Content = newsDto.Content;
            news.CategoryId = newsDto.CategoryId; // Se vuoi permettere anche l'aggiornamento della categoria

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: DELETE api/news/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}