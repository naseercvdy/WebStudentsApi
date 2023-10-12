using Dapper;
using System.Data.SqlClient;
using WebStudentsApi.Interfaces;
using WebStudentsApi.Models;

namespace WebStudentsApi.Repository
{
    public class StudentsRepository : IStudentsRepository
    {

        private readonly IConfiguration configuration;
        public StudentsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddStudents(Students entity)
        {
            try
            {
                var sql = "INSERT INTO dbo.tbl_Students( NameEn, NameAr, PhoneNumber, Email, Age, DateOfRegistration, Address, City, CourseID, UserID, DateOfStamp, Status)VALUES( @nameEn, @nameAr, @phoneNumber, @email, @age, getdate(), @address, @city, @courseID, 'system', getdate(), 1)";
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

        public async Task<Students> GetStudentsByID(long id)
        {
            var sql = "SELECT * FROM tbl_Students WHERE StudentsID = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("StudentAppCon")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Students>(sql, new { Id = id });
                return result;
            }
        }
        public async Task<int> DeleteStudents(long id)
        {
            try
            {
                var sql = "Update  tbl_Students set Status=2 ,LMD=GETDATE(),LMU='SYSTEM' where StudentsID= @Id";
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

        public async Task<int> UpdateStudents(Students entity)
        {
            try
            {
                var sql = "UPDATE tbl_Students SET NameEn=@nameEn,	NameAr=@nameAr,	PhoneNumber=@phoneNumber,	Email=@email,	Age=@age, Address=@address,	City=@city,	CourseID=@courseID, LMD = getdate(), LMU = 'System'  WHERE StudentsID = @studentsID";
                using (var connection = new SqlConnection(configuration.GetConnectionString("StudentAppCon")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql, entity);
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            
        }

        public async Task<int> UnAssignCourse(long id)
        {
            try
            {
                var sql = "Update  tbl_Students set CourseID=0 ,LMD=GETDATE(),LMU='SYSTEM' where StudentsID= @Id";
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
        public async Task<int> AssignCourse(long Studentsid,long courseId)
        {
            try
            {
                var sql = "Update  tbl_Students set CourseID=@CourseID ,LMD=GETDATE(),LMU='SYSTEM' where StudentsID= @Id";
                using (var connection = new SqlConnection(configuration.GetConnectionString("StudentAppCon")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql, new { Id = Studentsid, CourseID = courseId });
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
    }

}
