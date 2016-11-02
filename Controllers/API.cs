using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[Route("/api/card")]
public class CardController : CRUDController<Card> {
    public CardController(IRepository<Card> r) : base(r){}

    [HttpGet("search")]
    public IActionResult Search([FromQuery]string term, int listId = -1){
        return Ok(r.Read(dbset => dbset.Where(card => 
            card.Title.IndexOf(term) != -1)
            // && card.CardListId == listId
        ));
    }
}

[Route("/api/cardlist")]
public class CardListController : CRUDController<CardList> {
    public CardListController(IRepository<CardList> r) : base(r){}
}

[Route("/api/board")]
public class BoardController : CRUDController<Board> {
    public BoardController(IRepository<Board> r) : base(r){}

    [HttpGet("all/{id?}")]
    public IActionResult GetAll(int id = -1){
        if(id != -1){
            return Ok(r.Read(dbset => 
                dbset
                    .Where(b => b.Id == id)
                    .Include(b => b.Lists)  
                    .ThenInclude(l => l.Cards)
            ));
        }

        return Ok(r.Read(dbset => 
            dbset
                .Include(b => b.Lists)
                .ThenInclude(l => l.Cards)
                //.Include(b => b.Users)
        ));
    }
}