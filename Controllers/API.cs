using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[Route("/api/gram")]
public class GramController : CRUDController<Gram> {
    public GramController(IRepository<Gram> r) : base(r){}

 //   [HttpGet("search")]
/*    public IActionResult Search([FromQuery]string term, int listId = -1){
        return Ok(r.Read(dbset => dbset.Where(gram => 
            gram.Title.IndexOf(term) != -1
            || gram.Content.IndexOf(term) != -1
        ))); 
    } */
}

[Route("/api/comment")]
public class CommentController : CRUDController<Comment> {
    public CommentController(IRepository<Comment> r) : base(r){}
}

[Route("/api/like")]
public class LikeController : CRUDController<Like> {
    public LikeController(IRepository<Like> r) : base(r){}
}
