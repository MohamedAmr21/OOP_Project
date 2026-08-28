// User - Abstract Base Class
abstract class User
{
    public int Id { get; set; }
    public string Name { get; set; }

    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public abstract void DisplayInfo();
}

// Student Class
class Student : User
{
    public int Age { get; set; }

    public Student(int id, string name, int age)
        : base(id, name)
    {
        Age = age;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine(
            $"Student ID: {Id}, Name: {Name}, Age: {Age}"
        );
    }
}

// Admin Class
class Admin : User
{
    public Admin(int id, string name)
        : base(id, name)
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Admin ID: {Id}, Name: {Name}");
    }
}

// Course Class
class Course
{
    public int CourseId { get; set; }
    public string Name { get; set; }
    public int CreditHours { get; set; }

    public Course(int courseId, string name, int creditHours)
    {
        CourseId = courseId;
        Name = name;
        CreditHours = creditHours;
    }

    public void DisplayCourse()
    {
        Console.WriteLine(
            $"Course ID: {CourseId}, Name: {Name}, Credit Hours: {CreditHours}"
        );
    }
}

// Enrollment Class
class Enrollment
{
    public Student Student { get; set; }
    public Course Course { get; set; }
    public string Grade { get; set; }

    public Enrollment(Student student, Course course)
    {
        Student = student;
        Course = course;
        Grade = "Not Assigned";
    }

    public void DisplayEnrollment()
    {
        Console.WriteLine(
            $"Student: {Student.Name}, " +
            $"Course: {Course.Name}, " +
            $"Grade: {Grade}"
        );
    }
}

// Student Management System
class StudentManagementSystem
{
    private List<Student> students = new List<Student>();
    private List<Course> courses = new List<Course>();
    private List<Enrollment> enrollments = new List<Enrollment>();


    // Student Management


    public void AddStudent(Student student)
    {
        students.Add(student);
        Console.WriteLine("Student added successfully.");
    }

    public void ViewStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        foreach (Student student in students)
        {
            student.DisplayInfo();
        }
    }

    public Student FindStudent(int studentId)
    {
        foreach (Student student in students)
        {
            if (student.Id == studentId)
            {
                return student;
            }
        }

        return null;
    }

    public void UpdateStudent(int studentId, string name, int age)
    {
        Student student = FindStudent(studentId);

        if (student != null)
        {
            student.Name = name;
            student.Age = age;

            Console.WriteLine("Student updated successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    public void DeleteStudent(int studentId)
    {
        Student student = FindStudent(studentId);

        if (student != null)
        {
            students.Remove(student);

            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }


    // Course Management


    public void AddCourse(Course course)
    {
        courses.Add(course);
        Console.WriteLine("Course added successfully.");
    }

    public void ViewCourses()
    {
        if (courses.Count == 0)
        {
            Console.WriteLine("No courses found.");
            return;
        }

        foreach (Course course in courses)
        {
            course.DisplayCourse();
        }
    }

    public Course FindCourse(int courseId)
    {
        foreach (Course course in courses)
        {
            if (course.CourseId == courseId)
            {
                return course;
            }
        }

        return null;
    }

    public void UpdateCourse(
        int courseId,
        string name,
        int creditHours)
    {
        Course course = FindCourse(courseId);

        if (course != null)
        {
            course.Name = name;
            course.CreditHours = creditHours;

            Console.WriteLine("Course updated successfully.");
        }
        else
        {
            Console.WriteLine("Course not found.");
        }
    }

    public void DeleteCourse(int courseId)
    {
        Course course = FindCourse(courseId);

        if (course != null)
        {
            courses.Remove(course);

            Console.WriteLine("Course deleted successfully.");
        }
        else
        {
            Console.WriteLine("Course not found.");
        }
    }


    // Enrollment


    public void EnrollStudent(int studentId, int courseId)
    {
        Student student = FindStudent(studentId);
        Course course = FindCourse(courseId);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        if (course == null)
        {
            Console.WriteLine("Course not found.");
            return;
        }

        Enrollment enrollment =
            new Enrollment(student, course);

        enrollments.Add(enrollment);

        Console.WriteLine("Student enrolled successfully.");
    }


    // Grade Management


    public void AssignGrade(
        int studentId,
        int courseId,
        string grade)
    {
        foreach (Enrollment enrollment in enrollments)
        {
            if (enrollment.Student.Id == studentId &&
                enrollment.Course.CourseId == courseId)
            {
                enrollment.Grade = grade;

                Console.WriteLine("Grade assigned successfully.");
                return;
            }
        }

        Console.WriteLine("Enrollment not found.");
    }
    // Report:
    // Students in a Cours

    public void ViewStudentsInCourse(int courseId)
    {
        Course course = FindCourse(courseId);

        if (course == null)
        {
            Console.WriteLine("Course not found.");
            return;
        }

        Console.WriteLine(
            $"\nStudents enrolled in {course.Name}:"
        );

        bool found = false;

        foreach (Enrollment enrollment in enrollments)
        {
            if (enrollment.Course.CourseId == courseId)
            {
                Console.WriteLine(
                    $"ID: {enrollment.Student.Id}, " +
                    $"Name: {enrollment.Student.Name}"
                );

                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No students enrolled.");
        }
    }
    // Report:
    // Student Academic Record

    public void ViewStudentRecord(int studentId)
    {
        Student student = FindStudent(studentId);

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.WriteLine(
            $"\nAcademic Record for {student.Name}"
        );

        foreach (Enrollment enrollment in enrollments)
        {
            if (enrollment.Student.Id == studentId)
            {
                Console.WriteLine(
                    $"Course: {enrollment.Course.Name}, " +
                    $"Credit Hours: {enrollment.Course.CreditHours}, " +
                    $"Grade: {enrollment.Grade}"
                );
            }
        }
    }
}

class Program
{
    static void Main()
    {
        StudentManagementSystem system =
            new StudentManagementSystem();

        // Create Students
        Student student1 =
            new Student(1, "Ahmed", 20);

        Student student2 =
            new Student(2, "Mohamed", 21);

        system.AddStudent(student1);
        system.AddStudent(student2);

        // Create Courses

        Course course1 =
            new Course(101, "C# Programming", 3);

        Course course2 =
            new Course(102, "Database", 3);

        system.AddCourse(course1);
        system.AddCourse(course2);

        // View Students

        Console.WriteLine("\n--- Students ---");

        system.ViewStudents();
        // View Courses
        

        Console.WriteLine("\n--- Courses ---");

        system.ViewCourses();

        // Enroll Students
   

        Console.WriteLine("\n--- Enrollment ---");

        system.EnrollStudent(1, 101);
        system.EnrollStudent(1, 102);
        system.EnrollStudent(2, 101);

        // Assign Grades


        Console.WriteLine("\n--- Grades ---");

        system.AssignGrade(1, 101, "A");
        system.AssignGrade(1, 102, "B+");
        system.AssignGrade(2, 101, "A-");

        // Students in Course
        system.ViewStudentsInCourse(101);

        // Student Academic Record

        system.ViewStudentRecord(1);

        // Update Student

        Console.WriteLine("\n--- Update Student ---");

        system.UpdateStudent(1, "Ahmed Ali", 21);

        system.ViewStudents();

        // Delete Student
        system.DeleteStudent(2);

        Console.ReadKey();
    }
}