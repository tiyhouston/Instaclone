using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Comment : HasId
{
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(250, MinimumLength = 10)]
    public string Message { get; set; }
    [Required]
    public DateTime createdAt { get; set; }
    [Required]
    public int GramId { get; set; }
    public string ByUser { get; set; }
}

public class Like : HasId {
    [Required]
    public int Id { get; set; }
    
    [Required]
    public int GramId {get;set;}
    [Required]
    public DateTime createdAt { get; set; }
    public string ByUser { get; set; }
}

public class Gram : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    public string ImageURL { get; set; }
    [Required]
    public DateTime createdAt { get; set; }
    
    [StringLength(250, MinimumLength = 10)]
    public string Message { get; set; }
    [Required]
    public string Title { get; set; }
    public List<Like> Likes { get; set; }
    public List<Comment> Comments { get; set; }
}

// colocate DbSet declarations with classes
public partial class DB : DbContext {
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Gram> Grams { get; set; }
}

public partial class Handler {
    public void RegisterRepos(IServiceCollection services){
        Repo<Like>.Register(services, "Likes");
        Repo<Comment>.Register(services, "Comments");
        Repo<Gram>.Register(services, "Grams",
            d => d.Include(b => b.Comments));
    }
}