using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

public class Post : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    public string ImageURL { get; set; }
    [Required]
    public DateTime createdAt { get; set; }
    [Required]
    public List<Like> Likes { get; set; }
    [Required]
    public List<Comment> Comments { get; set; }
    public string Message { get; set; } // don't forget to add limit on this!
    public string Title { get; set; }
    public Post() {
        Id = new Random().Next();
    }

}

public class Like : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    public DateTime createdAt { get; set; }
    public Like() {
        Id = new Random().Next();
    }
}

public class Comment : HasId {
    [Required]
    public int Id { get; set; }
    [Required] // don't forget to include limit of characters here!
    public string Message { get; set; }
    [Required]
    public DateTime createdAt { get; set; }
    public Comment() {
        Id = new Random().Next();
    }

public partial class DB : DbContext {
    public DbSet<Post> Posts { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    }

}
