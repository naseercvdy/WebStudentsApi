using WebStudentsApi.Models;
namespace WebStudentsApi.Interfaces
{
    public interface IStudentsRepository : IStudentsGeneric<Students>
    {

    }
    public interface IStudentsViewRepository : IStudentsViewGeneric<ViewStudents>
    {

    }
    public interface ICourseRepository : ICourseGeneric<Course>
    {

    }
    public interface IUnitOfWork
    {
        IStudentsRepository Students { get; }
        ICourseRepository Course { get; }
        IStudentsViewRepository ViewStudents { get; }
    }
}
