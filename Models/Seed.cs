using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


public static class Seed
{
    public static void Initialize(DB db, bool isDevEnvironment)
    {
        if(isDevEnvironment){
            db.Database.EnsureDeleted(); // delete then, ...
        }

        db.Database.EnsureCreated(); // create the tables!!
        // db.Database.Migrate(); // ensure migrations are registered (sqlite/postgres only, won't work with in-memory db)
        
        if(db.Posts.Any() || db.Likes.Any() || db.Comments.Any()) return;

        Post p = new Post { ImageUrl = "http://bjstlh.com/data/wallpapers/165/WDF_2048218.png", Likes = new List<Like>(), Comments = new List<Comment>() };
        Like l = new Like {}
        Comment c = new Comment {}

        Action createLikeList = () => {
            Like likes = new Like { Summary="Todo items", Likes = new List<Like>() };

            for(var i = 0; i < 10; i++)
                todo.Cards.Add(new Card { Title = $"Test Card {i}", Content = $"Test Content {i}",  });
            
            b.Lists.Add(todo);
        };

        for(var j = 0; j<3; j++)
            createList();
        
        db.Posts.Add(p);
        db.Likes.Add(l);
        db.Comments.Add(c);
        db.SaveChanges(); 
        Console.WriteLine("----------CARDS SEEDED-------------");
    }
}