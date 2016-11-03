using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;


[RouteAttribute("/api/post")]
public class PostController : CRUDController<Post> {
    public PostController(IRepository<Post> r) : base(r){}

    [HttpGetAttribute("search")]
    public IActionResult Search([FromQuery]string term, int Id = -1){
        return Ok(r.Read(dbset => dbset.Where(post =>
            post.Title.IndexOf(term) != -1)
            || PostController.Content.IndexOf(term) != -1
        ));
    }
}

[Route("/api/like")]
public class LikeController : CRUDController<Like> {
    public LikeController(IRepository<Like> r) : base(r){}
}

        





