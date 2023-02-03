using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Scribble.Blog.Models;

public interface IBlogEntityRepository
{
    void Create(BlogEntity blog);
    void Delete(Guid id);
    BlogEntity Get(Guid id);
    List<BlogEntity> GetBlogs();
    void Update(BlogEntity blog);
}
public class BlogRepository : IBlogEntityRepository
{
    string connectionString = null;
    public BlogRepository(string conn)
    {
        connectionString = conn;
    }
    public List<BlogEntity> GetBlogs()
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            return db.Query<BlogEntity>("SELECT * FROM dbo.Blogs").ToList();
        }
    }

    public BlogEntity Get(Guid id)
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            return db.Query<BlogEntity>("SELECT * FROM dbo.Blogs WHERE Id = @id", new { id }).FirstOrDefault();
        }
    }

    public void Create(BlogEntity blog)
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            var sqlQuery = "INSERT GuidO blogs (Title, Content) VALUES(@Title, @Content)";
            db.Execute(sqlQuery, blog);

            string _sqlQuery = "INSERT Guid dbo.Blogs (Title, Content) VALUES(@Title, @Content); SELECT CAST(SCOPE_IDENTITY() as Guid)";
            Guid? blogId = db.Query<Guid>(_sqlQuery, blog).FirstOrDefault();
            blog.Id = blogId.Value;
        }
    }

    public void Update(BlogEntity blog)
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            var sqlQuery = "UPDATE dbo.Blogs SET Title = @Title, Content = @Content WHERE Id = @Id";
            db.Execute(sqlQuery, blog);
        }
    }

    public void Delete(Guid id)
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            var sqlQuery = "DELETE FROM dbo.Blogs WHERE Id = @id";
            db.Execute(sqlQuery, new { id });
        }
    }
}