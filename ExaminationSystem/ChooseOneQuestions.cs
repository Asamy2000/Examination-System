

namespace ExaminationSystem
{
    public class ChooseOneQuestions : QuestionBase
    {
        public override string Header { get; } = "Choose One Question";

        public ChooseOneQuestions(string _body = "", double _marks = 0) : base(_body, _marks)
        {
            AnswerList = new Answers[3];
        }
        public override string ToString()
        {
            return $"{Header}     Marks({Marks})\n {Body}\n" +
                   $"1.{AnswerList[0].AnswerText}\t\t 2.{AnswerList[1].AnswerText} \t\t {AnswerList[2].AnswerText}";
        }
        public static ChooseOneQuestions AddChooseOneQuestion()
        {
            ChooseOneQuestions question = new ChooseOneQuestions();
            Console.WriteLine(question.Header);
            Console.WriteLine("Please Enter The Body of The Question: ");
            question.Body = Console.ReadLine();
            Console.WriteLine("Please Enter The Marks of The Question:");
            question.Marks = double.Parse(Console.ReadLine());
            for (int i = 0; i < question.AnswerList?.Length; i++) {
                question.AnswerList[i] = new Answers();
                Console.WriteLine($"Please Enter The Choice Number {i + 1}");
                question.AnswerList[i].AnswerText = Console.ReadLine();
                question.AnswerList[i].AnswerId = i + 1;
            }
            question.RightAnswer = new Answers();
            int id;
            do
            {
                Console.WriteLine($"Please Enter The Right Answer for Quesion [1,2 Or 3]");
            } while (!int.TryParse(Console.ReadLine(), out id) || id < 1 || id > 3);
            question.RightAnswer.AnswerId = id;
            question.RightAnswer.AnswerText = question.AnswerList[id - 1].AnswerText;
            return question ;
        }
        
    }
}
