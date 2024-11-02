using Microsoft.AspNetCore.Http;

namespace Entities.VM;

public class AboutVM
{
    public int AboutId { get; set; }
    public string Title { get; set; }
    public string? SubDescription { get; set; }
    public string Details { get; set; }
    public string? CvUrl { get; set; }
    public IFormFile Cv { get; set; }
    
}