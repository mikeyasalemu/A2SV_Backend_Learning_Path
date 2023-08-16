using Task.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using Task.Models;
namespace Task.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CommentManagerController: ControllerBase
{
    public readonly AppDbContext _context;
    public CommentManagerController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult Get(){
        var comments = _context.Comments.ToList();
        return Ok(comments);
    }

    [HttpPost]
    public IActionResult Post( Comment comment){
        _context.Comments.Add(comment);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = comment.ID }, comment);
    }

    [HttpPut]
    [Route("{id:int}")]
    public IActionResult Put(int id, [FromBody] Comment updatedFields) {

        var existingComment = _context.Comments.SingleOrDefault(com => com.ID == id);
        if(existingComment == null){
            _context.Comments.Add(updatedFields);
            return CreatedAtAction(nameof(Get), new { id = updatedFields.ID }, updatedFields);
        }

        updatedFields.ID = existingComment.ID;
        _context.Entry(existingComment).CurrentValues.SetValues(updatedFields);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult Delete(int id) {
        var comment = _context.Comments.SingleOrDefault(comment => comment.ID == id);
        if(comment == null){
            return NotFound();
        }

        _context.Comments.Remove(comment);
        _context.SaveChanges();
        return NoContent();
    }




}























/*  public readonly AppDbContext _context;
    public CommentManagerController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("/GetComment")]
    public ActionResult GetComment()
    {
        return Ok("Hello, Hi Mikeyas!!");
    }
    // see as query??
    [HttpGet]
    [Route("/GetCommentById/{Id:int}")]
    public ActionResult GetCommentById(int Id)
    {
        return Ok("Hello, Hi Mikeyas!!");
    }

    [HttpPost]
    [Route("/CreateComment")]
    public ActionResult CreateComment([FromBody] Comment newComment)
    {

        // return Created(nameof(GetCommentById), newComment.ID);
        return CreatedAtAction(nameof(GetCommentById), new { id = newComment.ID }, newComment);
    }

    [HttpDelete]
    [Route("/DeleteComment/{ID:int}")]
    public ActionResult DeleteComment(int ID)
    {

        return Ok("Deleted!!!");
    }

    [HttpPut]
    [Route("/UpdateComment/{ID:int}")]
    public ActionResult UpdateComment(int ID, [FromBody] Comment updateComment)
    {

        return Ok("Updated!!!");
    }*/