using Microsoft.EntityFrameworkCore;

namespace StoringAPI.Data
{
    public class HohContext : DbContext
    {

        public HohContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<SurveyResult> SurveyResults { get; set; }
    }
}
