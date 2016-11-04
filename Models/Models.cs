using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

public class Gram : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    public string ImageURL { get; set; }
    [Required]
    public DateTime createdAt { get; set; }
    [Required]
    public List<Like> Likes { get; set; }
    [Required]
    [StringLengthAttribute(250)]
    public List<Comment> Comments { get; set; }
    [StringLength(250)]
    public string Message { get; set; } 
    public string Title { get; set; }
    public Gram() {
        Id = new Random().Next();
    }

}

public class Like : HasId {
    [Required]
    public int Id { get; set; }
    [Required]
    public DateTime createdAt { get; set; }
    int GramId { get; set; }
    public Like() {
        Id = new Random().Next();
    }
}

public class Comment : HasId {
    [Required]
    public int Id { get; set; }
    [Required] 
    [StringLength(250)]
    public string Message { get; set; }
    [Required]
    public DateTime createdAt { get; set; }
    int GramId { get; set; }
    public Comment() {
        Id = new Random().Next();
    }
}
