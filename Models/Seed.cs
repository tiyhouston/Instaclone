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
        // db.Database.Migrate(); // ensure migrations are registered

        if(db.Grams.Any() || db.Likes.Any() || db.Comments.Any()) return;

        var g = new List<Gram> {
            // Tacos 1
            new Gram {
                ImageURL = "https://media0.giphy.com/media/xT0GqGg0jNU9uRyJr2/200w.gif#1",
                Message = "Taco Tuesday, y'all",
                Title = "Tacos",
                Likes = new List<Like>{ new Like {ByUser="pistoleros"} },
                Comments = new List<Comment>()
            },
            // Tacos 2
            new Gram {
                ImageURL = "https://media0.giphy.com/media/xT0GqGg0jNU9uRyJr2/200w.gif#1",
                Message = "Taco Wednesday??",
                Title = "Moar Tacos?",
                Likes = new List<Like>{ new Like {ByUser="pistoleros"} },
                Comments = new List<Comment>()
            },
            // Tacos 3
            new Gram {
                ImageURL = "https://media0.giphy.com/media/xT0GqGg0jNU9uRyJr2/200w.gif#1",
                Message = "Taco Thursday",
                Title = "Tacos err'day, err'day, err'day",
                Likes = new List<Like>(),
                Comments = new List<Comment> { new Comment { ByUser = "TheLunchGods", Message = "You might have an addiction to tacos." } }
            },
            // .NET Ninjas
            new Gram {
                ImageURL = "http://bjstlh.com/data/wallpapers/165/WDF_2048218.png",
                Message = "We are the .NET ninjas!",
                Title = "Ninjas!!!!",
                Likes = new List<Like>{ new Like {ByUser="ninja73"} },
                Comments = new List<Comment>()
            },
            // Mobile Mafia
            new Gram {
                ImageURL = "https://files.slack.com/files-pri/T03FAV5N3-F2VHHAW1Z/mobile_mafia.jpg",
                Message = "Mafia!!, Mafia!!, Mafia!!...",
                Title = "Mobile Mafia",
                Likes = new List<Like>{ new Like {ByUser="MafiaDon"} },
                Comments = new List<Comment>() { new Comment { ByUser = "MafiaDon", Message = "Love the logo!" } }
            },
            // Cat with pancakes
            new Gram {
                ImageURL = "https://giphy.com/gifs/aOqVDcqUQt1BK",
                Message = "Pancakes...yum!",
                Title = "Pancakes!!",
                Likes = new List<Like>(),
                Comments = new List<Comment> { new Comment { ByUser = "CatLover", Message = "We should go to IHOP!" } }
            },
            // Hockey fist bump
            new Gram {
                ImageURL = "https://giphy.com/gifs/child-glass-hertl-KFJVHPJ3xvykE",
                Message = "Fist bump, dude.",
                Title = "Fist bump",
                Likes = new List<Like>(),
                Comments = new List<Comment> { new Comment { ByUser = "SharksFan", Message = "Yay!!" } }
            },
            // Cat on computer
            new Gram {
                ImageURL = "https://giphy.com/gifs/JIX9t2j0ZTN9S",
                Message = "Must.Finish.This.Project",
                Title = "Project's Due Tomorrow",
                Likes = new List<Like>{ new Like { ByUser="pistoleros"} },
                Comments = new List<Comment>()
            },
            // TIY
            new Gram {
                ImageURL = "http://landing.theironyard.com/images/home/tiy-logo.png",
                Message = "Join us for Iron Pints!",
                Title = "TIY",
                Likes = new List<Like>{ new Like {ByUser="pistoleros"} },
                Comments = new List<Comment>()
            },
            // PI
            new Gram {
                ImageURL = "https://giphy.com/gifs/ge-animation-pi-day-msEJZmK2rjmyk",
                Message = "Pineapples and Pirates!",
                Title = "Pi",
                Likes = new List<Like>(),
                Comments = new List<Comment> { new Comment { ByUser = "TheLunchGods", Message = "You might have an addiction to pineapple." } }
            }

        };

        foreach(var i in g) db.Grams.Add(i);
        db.SaveChanges();
        Console.WriteLine("----------DB SEEDED-------------");
    }
}