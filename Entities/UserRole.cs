using System.ComponentModel.DataAnnotations;

namespace Entities;

public class UserRole
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public byte Status { get; set; }
    public bool Control { get; set; }
    public DateTime CreateDate { get; set; }
}