

namespace ExaminationSystem
{
    public class MCQQuestions : QuestionBase
    {
        public override string Header { get; } ="MCQ Question";
        public MCQQuestions(string _body ="",double _marks =0):base(_body,_marks)
        {
            AnswerList = new Answers[3];
        }
        public override string ToString()
        {
            return $"{Header}     Marks({Marks})\n {Body}\n" +
                   $"1.{AnswerList[0].AnswerText}\t\t 2.{AnswerList[1].AnswerText} \t\t {AnswerList[2].AnswerText}";
        }
        public static MCQQuestions AddMCQQuestion()
        {
            MCQQuestions question = new MCQQuestions();
            Console.WriteLine(question.Header);
            Console.WriteLine("Please Enter The Body Of Question:");
            question.Body = Console.ReadLine();
            Console.WriteLine("Please Enter The Marks Of Question:");
            question.Marks = double.Parse(Console.ReadLine());

            for(int i = 0; i< question.AnswerList?.Length; i++)
            {
                question.AnswerList[i] = new Answers();
                Console.WriteLine($"Please Enter The Choice Number {i + 1}");
                question.AnswerList[i].AnswerText = Console.ReadLine();
                question.AnswerList[i].AnswerId = i + 1;
            }
            question.RightAnswer =new Answers();
            string answer = "";
            do
            {
                Console.WriteLine($"Please Enter The Right Answer For the Question");
                answer = Console.ReadLine();
            } while (!(answer is string));
            question.RightAnswer.AnswerText = answer;
            return question ;
        }
    }
}
