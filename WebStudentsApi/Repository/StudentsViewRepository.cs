using Dapper;
using System.Data.SqlClient;
using WebStudentsApi.Interfaces;
using WebStudentsApi.Models;
namespace WebStudentsApi.Repository
{
    public class StudentsViewRepository : IStudentsViewRepository
    {
        private readonly IConfiguration configuration;
        public StudentsViewRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IEnumerable<ViewStudents>> GetAllStudents()
        {
            var sql = "SELECT StudentsID, NameEn, NameAr, PhoneNumber,S.CourseID, Email, Age, DateOfRegistration, Address, City, CourseName FROM tbl_Students(nolock) S left outer join tbl_Course t On S.CourseID = t.CourseID where s.Status = 1";
            using (var connection = new SqlConnection(configuration.GetConnectionString("StudentAppCon")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ViewStudents>(sql);
                return result.ToList();
            }
        }

         
    }
}
