/* using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

public abstract class CRUDController<T> : Controller where T: class, HasId {

    protected IRepository<T> r; //double check this 
    public CRUDController(IRepository<T> r){ // double check this
        this.r = r;

    }
    [HttpPost]

    public IActionResult C([FromBody] T item) { // need to fill in info after FromBody
        if(!ModelState.IsValid)
            return BadRequest(ModelState.ToErrorObject());

        return Ok(r.Create(item)); // double check r

    }

    [HttpGet("{id}")]
    
    public IActionResult R(int id = -1) {
        if(id == -1)
            return Ok(r.Read());

    var item = r.Read(id);
    if(item == null)
        return NotFound();

    return Ok(item);

    }

    [HttpPut("{id}")]
    public IActionResult U(int id, [FromBody] T item) {
        if(item.Id !=id || !ModelState.IsValid || !r.Update(item))
            return BadRequest();
    
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult D(int id){
        T item = r.Delete(id);
        if(item == null)
            return NotFound();
    
        return Ok(item);
    
    }
} */