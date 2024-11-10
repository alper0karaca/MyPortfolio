using System.ComponentModel.DataAnnotations;

namespace Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Surname { get; set; } 
    public string UserName { get; set; } 
    public string Password { get; set; } 
    public string? Email { get; set; } 
    public string? Phone { get; set; } 
    public string? UserImageUrl { get; set; } 
    public int UserRoleId { get; set; }
    public bool CanSaveFile { get; set; } 
    public string? Description { get; set; } 
    public byte Status { get; set; } 
    public bool Control { get; set; } 
    public DateTime CreateDate { get; set; } 
    
}