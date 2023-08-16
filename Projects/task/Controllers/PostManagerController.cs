using Task.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Task.Models;
using Microsoft.EntityFrameworkCore;


namespace Task.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostManagerController: ControllerBase
{

    public readonly AppDbContext _context;
    public PostManagerController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("/GetPost")]
    public ActionResult GetPost()
    {
        var posts = _context.Posts.ToList();
        return Ok(posts);
    }

    [HttpGet]
    [Route("/GetPostById/{id:int}")]
    public IActionResult GetPostById(int id)
    {
        var post =  _context.Posts.Include(p => p.Comments).FirstOrDefault(p => p.ID == id);

        if (post == null)
        {
            return NotFound();
        }


        var postWithComment = new Post
        {
            ID = post.ID,
            Title = post.Title,
            Content = post.Content,
            CreatedAt = post.CreatedAt,
            Comments = post.Comments
                            .Select(c => new Comment { ID = c.ID, Text = c.Text, CreatedAt = c.CreatedAt })
                                .ToList()
        };

        return Ok(postWithComment);
        
    }

    [HttpPost]
    public IActionResult Post([FromBody] Post post){
        _context.Posts.Add(post);
        _context.SaveChanges();
        
        return CreatedAtAction(nameof(GetPost), new { id = post.ID }, post);

    }

    [HttpPut]
    [Route("{id:int}")]
    public IActionResult Put(int id, [FromBody] Post updatedFields) {
        var existingPost = _context.Posts.SingleOrDefault(post => post.ID == id);
        if(existingPost == null){
            _context.Posts.Add(updatedFields);
            return CreatedAtAction(nameof(GetPost), new { id = updatedFields.ID }, updatedFields);
        }

        updatedFields.ID = existingPost.ID;
        _context.Entry(existingPost).CurrentValues.SetValues(updatedFields);
        _context.SaveChanges();
        
        return NoContent();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult Delete(int id) {
        var blogPost = _context.Posts.SingleOrDefault(post => post.ID == id);
        if(blogPost == null){
            return NotFound();
        }

        _context.Posts.Remove(blogPost);
        _context.SaveChanges();
        return NoContent();
    }
  
}