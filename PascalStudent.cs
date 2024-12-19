namespace MarksAndStudent
{
    public enum Result
    {
        ADMITTED,
        NOTADMITTED,
        SUSPENDED
    }
    public class PascalStudent:IComparable<PascalStudent>
    {
        private int[] _marks;
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public PascalStudent(bool isBiennium, string name, string surname)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
            if (string.IsNullOrWhiteSpace(surname)) throw new ArgumentNullException("surname");

            if (isBiennium)
                _marks = new int[13];
            else
                _marks = new int[10];

            Name = name;
            Surname = surname;
        }

        public void addMark(int mark)
        {
            if (mark <= 0 || mark > 10) throw new ArgumentOutOfRangeException("Mark not valid");

            bool insert = false;
            int count = 0;

            while (!insert)
            {
                if (_marks[count] == 0)
                {
                    _marks[count] = mark;
                    insert = true;
                }
                count++;
            }
        }

        public double average()
        {
            int sum = 0;
            int count = 0;
            foreach (int mark in _marks)
            {
                if (mark == 0)
                    count++;
                else
                    sum += mark;
            }
            if (count == _marks.Length)
                return 0;
            else
                return (double)sum / (_marks.Length - count);
        }

        public int numberOfInsufficiencies()
        {
            int count = 0;
            foreach (int mark in _marks)
            {
                if (mark < 6 && mark != 0)
                {
                    count++;
                }
            }
            return count;
        }

        public int pointToSufficiency()
        {
            int sum = 0;
            foreach (int mark in _marks)
            {
                if (mark < 6 && mark != 0)
                {
                    sum += (6 - mark);
                }
            }
            return sum;
        }

        public Result scrutiny()
        {
            // point in insufficiencies < 4 suspended, like if you have a 4 and a 5 you are suspended
            // point in insufficiencies > 3 not admitted, so if you have a 3 and a 5 you are not admitted
            if (pointToSufficiency() <= 3)
                return Result.SUSPENDED;
            else if (pointToSufficiency() > 3)
                return Result.NOTADMITTED;
            else
                return Result.ADMITTED;

        }

        public int markOfSubject(int subject)
        {
            if (subject < 1 || subject > _marks.Length) throw new ArgumentOutOfRangeException("Subject not valid");
            return _marks[subject-1];
        }

        /// <summary>
        /// ordinamento degli studenti per media (per primo lo studente con la media più alta) (a parità di media per cognome)
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(PascalStudent? other)
        {
            if (other== null || (!(other is PascalStudent ))) throw new ArgumentException("tipo di dato sbagliato");

            if (average()>other.average())
            {
                return -1;
            }
            else
            {
                if (average() == other.average())
                {
                    return Surname.CompareTo(other.Surname);
                }
                else
                {
                    return 1;
                }

            }


        }
    }
}
