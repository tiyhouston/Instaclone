using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;



public class Like {
    [Required]
    public int Id { get; set; }
    [Required]
    public DateTime createdAt { get; set; }
    [Required]
    public int GramId { get; set; }
    public Like() {
        Id = new Random().Next();
    }
}

public class Comment {
    [Required]
    public int Id { get; set; }
    [Required] 
    [StringLength(250)]
    public string Message { get; set; }
    [Required]
    public DateTime createdAt { get; set; }
    [Required]
    public int GramId { get; set; }
    public Comment() {
        Id = new Random().Next();
    }
}
