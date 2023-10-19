

namespace ExaminationSystem
{
    public class Subject
    {
        private string name;
        private int id;
        private Exam subExam;

        public string Name
        { get { return name; } set { name = value; } }
        public int Id { get { return id; } set { id = value; } }
        public Exam SubExam { get {  return subExam; } set {  subExam = value; } }

        public Subject(string _name,int _id,Exam _subExam) {
            name = _name;
            id = _id;
            subExam = _subExam;
        }

        public Subject(int _id,string _name):this(_name,_id,new PracticalExam(60,3))
        {
        
        }
        public override string ToString()
        {
            return $"Subject Name {Name}\n Subject Id {Id}\n Exam Type {SubExam}";
        }
        public void CreateExam()
        {
            int time, type;
            do
            {
                Console.WriteLine("Please Choose The Type of The Exam [1 for Practical, 2 for Final]");
            } while (!int.TryParse(Console.ReadLine(),out type) || type < 1|| type > 2);
            subExam.Type = (ExamType)type;

            do
            {
                Console.WriteLine("Please Choose The Time of The Exam in Minutes :");
            } while (!int.TryParse(Console.ReadLine(),out time)|| time < 60 || time >180);
            subExam.Time = time;
            Console.WriteLine("Please Enter Number of Questions: ");
            int numberofQuestions =int.Parse(Console.ReadLine());
            if(subExam.Type ==ExamType.practicalExam)
            {
                subExam = new PracticalExam(time, numberofQuestions);
                subExam.Questions = QuestionBase.CreateBaseQuestions(numberofQuestions);
            }
            else
            {
                subExam = new FinalExam(time, numberofQuestions);
                subExam.Questions =QuestionBase.CreateBaseQuestions(numberofQuestions);
            }
            for(int i = 0; i< subExam.Questions.Length; i++)
            {
                subExam.ExamGrade += subExam.Questions[i].Marks;
            }
        }
    }
}
