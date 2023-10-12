namespace WebStudentsApi.Models
{
    public class Students
    {
        public long studentsID { get; set; }
        public string nameEn { get; set; }
        public string nameAr { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string age { get; set; }
        public string address { get; set; }
        public long courseID { get; set; }
        //public string UserID { get; set; }
        //public DateTime DateOfStamp { get; set; }
        //public DateTime DateOfRegistration { get; set; }
        //public DateTime LMD { get; set; }
        //public string LMU { get; set; }
        //public int Status { get; set; }
      

    }
    public class Course
    {
        public long courseID { get; set; }
        public string courseCode { get; set; }
        public string courseName { get; set; }
        
        //public string UserID { get; set; }
        //public DateTime DateOfStamp { get; set; }
        //public DateTime LMD { get; set; }
        //public string LMU { get; set; }
        //public int Status { get; set; }


    }
    public class ViewStudents
    {
        public long studentsID { get; set; }
        public string nameEn { get; set; }
        public string nameAr { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string age { get; set; }
        public string address { get; set; }
        public long courseID { get; set; }

        public string CourseName { get; set; }


    }
}
