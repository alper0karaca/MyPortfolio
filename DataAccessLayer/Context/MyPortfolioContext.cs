using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context;

public class MyPortfolioContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //var connectionString = "server=104.247.167.130; port=3306; user=alperka4_alper0karaca; password=Macbook/M2; database=alperka4_MyPortfolioDb;";
        // local için
        var connectionString = "server=localhost; port=3306; user=root; database=MyPortfolioDb;";
        
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));
        
        optionsBuilder.UseMySql(connectionString, serverVersion);
        
    }
    
    public DbSet<About> Abouts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; } 
    public DbSet<Blog> Blogs { get; set; }

}