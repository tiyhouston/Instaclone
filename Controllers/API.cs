using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[Route("/api/gram")]
public class GramController : CRUDController<Gram> {
    public GramController(IRepository<Gram> r) : base(r){}

<<<<<<< HEAD
   [HttpGet("search")]
    public IActionResult Search([FromQuery]string term, int listId = -1){
        return Ok(r.Read(dbset => dbset.Where(gram => 
            gram.Title.ToLower().IndexOf(term.ToLower()) != -1
            || gram.Message.ToLower().IndexOf(term.ToLower()) != -1 // returning each gram where the term is in the title or the message - was creating error because there was no 'content' property in gram
        ))); 
    } 
=======
    [HttpGet("search")]
    public IActionResult Search([FromQuery]string term, int listId = -1){
        // r.dbtable.ToList().Log();
        return Ok(r.Read(dbset => 
            dbset.Where(gram => 
                gram.Title.ToLower().IndexOf(term.ToLower()) != -1 
                || gram.Message.ToLower().IndexOf(term.ToLower()) != -1
        ))); 
    }
>>>>>>> 5b5d8b3015847dc83e632d414f277af56608986b
}

[Route("/api/comment")]
public class CommentController : CRUDController<Comment> {
    public CommentController(IRepository<Comment> r) : base(r){}
}

[Route("/api/like")]
public class LikeController : CRUDController<Like> {
    public LikeController(IRepository<Like> r) : base(r){}
}
