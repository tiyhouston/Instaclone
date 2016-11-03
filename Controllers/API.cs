using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;


[Route("/api/gram")]
public class GramAPIController : Controller {
    private IGram grams;
    public GramAPIController(IGram p){
        grams = p;
    }

[HttpGet("{id}")]
public IActionResult Get(int Id) {
    if(Id == default(int))
        return View(grams.ReadAll());

    return View();
    }

[HttpGet("search")] //fix this
    public IActionResult Search([FromQuery]string term, int Id = -1){
        return Ok(r.Read(dbset => dbset.Where(gram =>
            post.Title.IndexOf(term) != -1)
            || GramController.Content.IndexOf(term) != -1
        ));
    }

[HttpPost]
public IActionResult Create(Gram g) {
    grams.Add(g);
        return View();
    }

public IActionResult C([FromBody] T item) {
  Console.WriteLine(ModelState);
  if(!ModelState.IsValid) 
    return BadRequest(
      new {
      Errors = ModelState.Values.Aggregate(
        new List<string>(),     
        (acc, o) => {
            foreach(var error in o.Errors)
              acc.Add(error.ErrorMessage());
            return acc;
        );
  return Ok(r.Create(item));
}

[HttpPut]
public IActionResult Update(int Id, Gram g) {
    if(Id == default(int))
        return View(grams.ReadAll());

    return View();
    }

[HttpDelete]
public IActionResult Delete(int Id) {
    if(Id == default(int))
        return View(grams.ReadAll());

    return View();
    } 
}


        





