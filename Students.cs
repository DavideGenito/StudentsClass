using MarksAndStudent;

namespace StudentsClass
{
    public class Students
    {
        private PascalStudent[] _students;

        public Students(int numStudents)
        {
            _students = new PascalStudent[numStudents];
        }

        private int _numResult(Result result)
        {
            int count = 0;
            foreach (PascalStudent student in _students)
            {
                if (student.scrutiny() == result) count++;
            }
            return count;
        }

        private PascalStudent[] _resultStudent(Result result)
        {
            PascalStudent[] positions = new PascalStudent[_numResult(result)];

            int count = 0;

            for (int i = 0; i < positions.Length; i++)
            {
                if (_students[i].scrutiny() == result)
                {
                    positions[count] = _students[i];
                    count++;
                }
            }

            Array.Sort(positions);

            return positions;
        }

        public int numberNotAdmitted()
        {
            return _numResult(Result.NOTADMITTED);
        }

        public PascalStudent[] studentsNotAdmitted()
        {
            return _resultStudent(Result.NOTADMITTED);
        }

        public int numberAdmitted()
        {
            return _numResult(Result.ADMITTED);
        }

        public PascalStudent[] studentsAdmitted()
        {
            return _resultStudent(Result.ADMITTED);
        }

        public int numberSuspended()
        {
            return _numResult(Result.SUSPENDED);
        }

        public PascalStudent[] studentsSuspended()
        {
            return _resultStudent(Result.SUSPENDED);
        }

        public double allStudentsAverage()
        {
            double sum = 0;
            int count = 0;
            foreach (PascalStudent student in _students)
            {
                if (student.average() == 0)
                    count++;
                else
                    sum += student.average();
            }

            if (count == _students.Length)
                return 0;
            else
                return sum / (_students.Length - count);
        }

        public PascalStudent lowestAverageStudent()
        {
            PascalStudent result = _students[0];
            bool first = true;
            foreach (PascalStudent student in _students)
            {
                if (!first)
                {
                    if (student.average() < result.average())
                    {
                        result = student;
                    }
                    else if (student.average() == result.average())
                    {
                        if(string.Compare(student.Surname, result.Surname) < 0)
                        {
                            result = student;
                        }
                        else if(string.Compare(student.Surname, result.Surname) == 0)
                        {
                            if (string.Compare(student.Name, result.Name) <= 0) result = student;
                        }
                    }
                }
                else
                {
                    first = false;
                }
            }
            return result;
        }

        public PascalStudent highestAverageStudent()
        {
            PascalStudent result = _students[0];
            bool first = true;
            foreach (PascalStudent student in _students)
            {
                if (!first)
                {
                    if (student.average() > result.average())
                    {
                        result = student;
                    }
                    else if (student.average() == result.average())
                    {
                        if (string.Compare(student.Surname, result.Surname) > 0)
                        {
                            result = student;
                        }
                        else if (string.Compare(student.Surname, result.Surname) == 0)
                        {
                            if (string.Compare(student.Name, result.Name) >= 0) result = student;
                        }
                    }
                }
                else
                {
                    first = false;
                }
            }
            return result;
        }

        public PascalStudent bestMark(int subject)
        {
            if (subject < 1 || subject > 13) throw new ArgumentOutOfRangeException("Subject not valid");
            PascalStudent result = new PascalStudent(true, "d", "d");
            bool first = true;

            for (int i = 1; i<_students.Length; i++)
            {
                if (first)

                {
                    first = false;
                }
                else
                {
                    if(result.markOfSubject(subject) < _students[i].markOfSubject(subject)) result = _students[i];
                }
            }

            return result;
        }
    }
}
