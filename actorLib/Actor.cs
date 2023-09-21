namespace actorLib
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public Genre Prefrence{ get; set; }
        public Actor(string name, int yearOfBirth, Genre prefence) 
        {
            Id = 0;
            Name = name;
            YearOfBirth = yearOfBirth;
            Prefrence = prefence;
        }

        public override string ToString()
        {
            return $"{Name} was born in {YearOfBirth} and loves {Prefrence}";
        }

        public void Validate()
        {
            ValidateName();
            ValidateYearOfBirth();
        }

        public void ValidateName()
        {
            if (Name == null)
            {
                throw new NullReferenceException();
            }
            if (Name.Length < 4)
            {
                throw new ArgumentException("name have to be 4 or more charectors long");
            }
        }

        public void ValidateYearOfBirth()
        {
            if (YearOfBirth < 1820)
            {
                throw new ArgumentException("YOB is lower then 1820");
            }
        }
    }
}