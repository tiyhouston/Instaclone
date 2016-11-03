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
        
        if(db.Likes.Any() || db.Comments.Any()) return;

        Post p = new Post { ImageURL = "", Id = 0, Likes = new List<Like>(), Comments = new List<Comment>() };
        
        Action createLike = () => {
            Like l = new Like { Id = 0, };
            

         for(var i = 0; i < 10; i++)
                l.Likes.Add(new Like { Id = 0, });
                
            
            p.Post.Add(post);
        
        Action createComment = () => {
            Comment c = new Comment { Id = 0, Message = "", };
        
        for(var i = 0; i < 10; i++)
        c.Comments.Add(new Comment { Id = 0, Message = "Test Comment"});
        }
 //      };

  //      for(var j = 0; j<3; j++)
  //          createList();
        
        db.Posts.Add(p);
        db.Likes.Add(l);
        db.Comments.Add(c);
        db.SaveChanges(); 
        Console.WriteLine("----------CARDS SEEDED-------------");
    }
}