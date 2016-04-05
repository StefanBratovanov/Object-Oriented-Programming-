

namespace _03_StudentClass
{
    public class Student
    {
        private string name;
        private int age;
        public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs eventArgs);
        public event PropertyChangedEventHandler PropertyChanged;


        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Name", this.Name, value);
                this.OnPropertyChanged(this, args);

                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Age", this.Age, value);
                this.OnPropertyChanged(this, args);

                this.age = value;
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(sender, args);
            }
        }
    }
}
