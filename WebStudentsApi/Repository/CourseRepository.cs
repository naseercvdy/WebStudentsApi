using Dapper;
using System.Data.SqlClient;
using WebStudentsApi.Interfaces;
using WebStudentsApi.Models;
namespace WebStudentsApi.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IConfiguration configuration;
        public CourseRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<IEnumerable<Course>> GetAllCourse()
        {
            var sql = "SELECT * FROM tbl_Course where Status=1";
            using (var connection = new SqlConnection(configuration.GetConnectionString("StudentAppCon")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Course>(sql);
                return result.ToList();
            }
        }
        public async Task<int> AddCourse(Course entity)
        {
            try
            {
                var sql = "INSERT INTO dbo.tbl_Course(CourseCode,CourseName,UserID,DataOfStamp,Status)VALUES(@courseCode,@courseName,'system',getdate(),1)";
                using (var connection = new SqlConnection(configuration.GetConnectionString("StudentAppCon")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql, entity);
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public async Task<int> DeleteCourse(long id)
        {
            try
            {
                var sql = "Update s set S.Status=2 from tbl_Course s left outer join tbl_Students c on s.CourseID=c.CourseID where StudentsID is null and s.CourseID  = @Id";
                using (var connection = new SqlConnection(configuration.GetConnectionString("StudentAppCon")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql, new { Id = id });
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Course> GetCourseByID(long id)
        {
            var sql = "SELECT * FROM tbl_Course WHERE CourseID = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("StudentAppCon")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Course>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateCourse(Course entity)
        {
             
            var sql = "UPDATE tbl_Course SET CourseCode = @courseCode, CourseName = @courseName, LMD = getdate(), LMU = 'System'  WHERE CourseID = @courseID";
            using (var connection = new SqlConnection(configuration.GetConnectionString("StudentAppCon")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
