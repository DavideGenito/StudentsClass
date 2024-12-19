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

        public void addStudent(PascalStudent student)
        {
            bool inserted = false;
            int count = 0;
            while (!inserted && count < _students.Length)
            {
                if (_students[count] == null)
                {
                    _students[count] = student;
                    inserted = true;
                }
                count++;
            }
            if (!inserted)
            {
                throw new ArgumentException("No available slots for a new student");
            }
        }

        private int _numResult(Result result)
        {
            int count = 0;
            foreach (PascalStudent student in _students)
            {
                if (student != null && student.scrutiny() == result) count++;
            }
            return count;
        }

        private PascalStudent[] _resultStudent(Result result)
        {
            PascalStudent[] positions = new PascalStudent[_numResult(result)];

            int count = 0;

            for (int i = 0; i < _students.Length; i++)
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
                if (student == null || student.average() == 0)
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
            int i = 0;

            while (i < _students.Length && _students[i] == null)
            {
                i++;
            }

            if (i == _students.Length)
                throw new InvalidOperationException("No valid students available");

            PascalStudent result = _students[i];

            for (int j = i + 1; j < _students.Length; j++)
            {
                if (_students[j] != null)
                {
                    if (_students[i].average() < result.average())
                    {
                        result = _students[i];
                    }
                    else if (_students[i].average() == result.average())
                    {
                        if (string.Compare(_students[i].Surname, result.Surname) < 0)
                        {
                            result = _students[i];
                        }
                        else if (string.Compare(_students[i].Surname, result.Surname) == 0)
                        {
                            if (string.Compare(_students[i].Name, result.Name) <= 0) result = _students[i];
                        }
                    }
                }
            }
            return result;
        }

        public PascalStudent highestAverageStudent()
        {
            int i = 0;

            while (i < _students.Length && _students[i] == null)
            {
                i++;
            }

            if (i == _students.Length)
                throw new InvalidOperationException("No valid students available");

            PascalStudent result = _students[i];

            for (int j = i + 1; j < _students.Length; j++)
            {
                if (_students[j] != null)
                {
                    if (_students[i].average() > result.average())
                    {
                        result = _students[i];
                    }
                    else if (_students[i].average() == result.average())
                    {
                        if (string.Compare(_students[i].Surname, result.Surname) > 0)
                        {
                            result = _students[i];
                        }
                        else if (string.Compare(_students[i].Surname, result.Surname) == 0)
                        {
                            if (string.Compare(_students[i].Name, result.Name) >= 0) result = _students[i];
                        }
                    }
                }
            }
            return result;
        }

        public PascalStudent bestMark(int subject)
        {
            if (subject < 1 || subject > 13) throw new ArgumentOutOfRangeException("Subject not valid");

            int i = 0;

            while (i < _students.Length && _students[i] == null)
            {
                i++;
            }

            if (i == _students.Length)
                throw new InvalidOperationException("No valid students available");

            PascalStudent result = _students[i];

            for (int j = i + 1; j < _students.Length; j++)
            {
                if (result.markOfSubject(subject) < _students[j].markOfSubject(subject)) result = _students[j];
            }

            return result;
        }

        public int howManyAverage(int averageSearch)
        {
            int result = 0;
            foreach (PascalStudent student in _students)
            {
                if(student.average() == averageSearch) result++;
            }
            return result;
        }
    }
}
