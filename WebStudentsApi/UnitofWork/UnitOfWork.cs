using WebStudentsApi.Interfaces;

namespace WebStudentsApi.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IStudentsRepository studentsRepository , ICourseRepository sourseRepository, IStudentsViewRepository studentsViewRepository)
        {
            Students = studentsRepository;
            Course = sourseRepository;
            ViewStudents = studentsViewRepository;
        }
        public IStudentsRepository Students { get; }
        public ICourseRepository Course { get; }

        public IStudentsViewRepository ViewStudents { get; }
    }
}
