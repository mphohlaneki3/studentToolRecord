namespace studentToolRecord
{
   
    
        class Program
        {
            // Global variables
            static String programName = "Student Record Tool";
            static int totalStudents = 0;

            static void Main(string[] args)
            {
                ShowWelcome();
                RunProgram();
            }

            static void ShowWelcome()
            {
                Console.WriteLine("================================");
                Console.WriteLine("     " + programName);
                Console.WriteLine("================================");
                Console.WriteLine();
            }

            static void RunProgram()
            {
                // ── STUDENT DATA ─────────────────────────────────────
                // Stores the names of up to 5 students
                string[] studentNames = new string[5];

                // Stores the age of each student
                int[] studentAges = new int[5];

                // Stores the percentage mark of each student
                double[] studentMarks = new double[5];

                // ── ADD 3 STUDENTS ────────────────────────────────────
                AddStudent(studentNames, studentAges, studentMarks,
                           "Mpho", 20, 74.5);
                AddStudent(studentNames, studentAges, studentMarks,
                           "Lerato", 21, 88.0);
                AddStudent(studentNames, studentAges, studentMarks,
                           "Thabo", 19, 51.3);

                // ── DISPLAY ALL RECORDS ───────────────────────────────
                Console.WriteLine("── STUDENT RECORDS ──");
                Console.WriteLine();
                DisplayAllStudents(studentNames, studentAges, studentMarks);

                // ── GRADE SUMMARY ─────────────────────────────────────
                Console.WriteLine();
                Console.WriteLine("── GRADE SUMMARY ──");
                Console.WriteLine();
                DisplayGradeSummary(studentMarks);

                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }

            static void AddStudent(string[] names, int[] ages,
                                   double[] marks, string name,
                                   int age, double mark)
            {
                if (totalStudents < 5)
                {
                    names[totalStudents] = name;
                    ages[totalStudents] = age;
                    marks[totalStudents] = mark;
                    totalStudents++;
                    Console.WriteLine(name + " added successfully.");
                }
                else
                {
                    Console.WriteLine("Record list is full.");
                }
            }

            static void DisplayAllStudents(string[] names, int[] ages,
                                           double[] marks)
            {
                // Bug zone: check this loop carefully
                for (int i = 0; i < totalStudents; i++) // changed <= to <, because <= made the looprun one extra time and show an empty student that was never added
                {
                    Console.WriteLine("Name  : " + names[i]);
                    Console.WriteLine("Age   : " + ages[i]);
                    Console.WriteLine("Mark  : " + marks[i] + "%");
                    Console.WriteLine("Grade : " + GetGrade(marks[i]));
                    Console.WriteLine();
                }
            }

            static string GetGrade(double mark)
            {
                // Bug zone: check the conditions — do they make sense?
                if (mark >= 80) //Fixed,it was greater or equals to 75 meaning if a student got more or 75 it will return a distinction
                    return "Distinction";
                if (mark >= 60)
                    return "Merit";
                if (mark >= 50)
                    return "Pass";
                else
                    return "Fail";
            }

            static void DisplayGradeSummary(double[] marks)
            {
                int distinctions = 0;
                int merits = 0;
                int passes = 0;
                int fails = 0;

                for (int i = 0; i < totalStudents; i++)
                {
                    // Bug zone: check each condition
                    if (marks[i] >= 75)
                        distinctions++;
                    else if (marks[i] >= 60) //The equal sign and the greater sign was swapped
                        merits++;
                    else if (marks[i] >= 50)
                        passes++;
                    else
                        fails++;
                }

                Console.WriteLine("Distinctions : " + distinctions);
                Console.WriteLine("Merits       : " + merits);
                Console.WriteLine("Passes       : " + passes);
                Console.WriteLine("Fails        : " + fails);
            }
        }
    }





