using WebStudentsApi.Models;
namespace WebStudentsApi.Interfaces
{
    public interface IStudentsGeneric<T> where T : class
    {
 

        Task<int> AddStudents(T entity);
        Task<int> DeleteStudents(long id);
        Task<T> GetStudentsByID(long id);
        Task<int> UpdateStudents(T entity);
        Task<int> UnAssignCourse(long id);
        Task<int> AssignCourse(long studentsID,long CourseID);

    }
    public interface IStudentsViewGeneric<T> where T : class
    {
        Task<IEnumerable<ViewStudents>> GetAllStudents();
       

    }
    public interface ICourseGeneric<T> where T : class
    {
        Task<IEnumerable<Course>> GetAllCourse();
        Task<int> AddCourse(T entity);
        Task<int> DeleteCourse(long id);
        Task<T> GetCourseByID(long id);
        Task<int> UpdateCourse(T entity);

    }
}
