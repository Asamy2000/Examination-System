

namespace ExaminationSystem
{
    #region Notes!
    /*
     * what is abstraction?
        Abstraction is a higher-level concept or a way of thinking when you start designing your application 
        from the business requirement.

        Abstraction is a process of identifying essential entities (classes) and their characteristics (class members) 
        and leaving irrelevant information from the business requirement to prepare a higher-level application design.

        Abstraction starts with identifying nouns in the business requirement or feature request. 
        A noun is a person, place, thing, or process. These nouns can be your entities. 
        After figuring out the required entities you can then collect the relevant characteristics of each entity. 
        Characteristics are information (data) and behaviors (methods) relevant to each entity.

       Business requirements =>> Abstraction ==> Classes & members
     
    * QuestionBase Created as abstract class why?
         1. to provide a template
              this class serve as template or blueprint for other classes.
              QuestionBase defines the common characteristics and properties that all specific question types should have. 
              By making it abstract, it enforces that any class deriving from it must provide implementations 
              for the abstract members (e.g., the Header property).
     
         2. to Enforce inheritance 
              By marking a class as abstract, you indicate that it is not meant to be instantiated on its own 
              but rather as a base for other classes.

              the QuestionBase class is designed to be a foundation for different types of questions (True/False, Choose One, MCQ), 
              and it's expected that other classes will inherit from it to create those specific question types.
     
          3.To Promote Code Reuse 
              Abstract classes allow you to define common functionality once in the base class and reuse it across multiple derived classes. 
              This reduces code duplication and enforces a consistent structure and behavior for all derived classes. 
              For example, properties like Body, Marks, and RightAnswer  defined in the base class [QuestionBase] and reused by all question types.
            
           4.To Enforce Constraints
              you can declare abstract methods and properties, which act as contracts. 
              Any class that inherits from the abstract class must provide concrete implementations for these abstract members. 
              This enforces that all derived classes adhere to a specific interface, ensuring that they provide required functionality.
     
     */
    #endregion
    public abstract class QuestionBase
    {
        /*
         access modifiers  used to restrict the visibility of a class member

         protected
          i can access the members with protected access modifier 
             1.within the same class 
             2.Within Derived Classes
         */
        protected string body;
        protected double marks;

        // any question has a list of answers [Aggregation relation]
        Answers[] answerList;

        // U can access this member only within the same class 
        // encapsulation hide the internal implementation from outside 
        private Answers rightAnswer;

        //abstract prop
        public abstract string Header { get; }

        // prop for each attribute 
        public string Body
        {
            get { return body; }
            set { body = value; }
        }
        public double Marks
        {
            get { return marks; }
            set { marks = value; }
        }
        public Answers RightAnswer
        {
            get { return rightAnswer; }
            set { rightAnswer = value; }
        }
        public Answers[] AnswerList
        {
            get { return answerList; }
            set
            {
                answerList = value;
            }
        }

        //indexer to get answer by id 
        public Answers this[int id] {
            get
            {
                for(int i = 0; i< answerList?.Length; i++) {
                    if (answerList[i].AnswerId == id) return answerList[i];
                }
                return new Answers();
            }
        }

        //indexer to get answer by answerText 
        public Answers this[string text]
        {
            get
            {
                for(int i=0;i < answerList?.Length;i++)
                {
                    if (answerList[i].AnswerText ==text) return answerList[i];
                }
                return new Answers();
            }
        }


        //ctor [any derived classes of QuestionBase are correctly initialized with the required data]
        public QuestionBase(string _body, double _marks )
        {
            body = _body;
            marks = _marks;
        }


        // Create question
        /*
         This method is a factory method that allows you to create an array of various question types (derived from QuestionBase) 
         based on user input. It demonstrates polymorphism, as the actual type of the questions created depends on user choices, 
         but all questions share a common base class, QuestionBase. 
         This makes it easy to work with a collection of diverse question types in a uniform way.
         
         */
        public static QuestionBase[] CreateBaseQuestions(int size)
        {
            QuestionBase[] questions = new QuestionBase[size]; 
             for(int i=0; i <questions?.Length;i++)
            {
                int questionType;
                do
                {
                    Console.WriteLine($"Please Choose The Type of the Question Number {i + 1} [1 for T/F Question, 2 for Choose one Quesion, 3 for MCQ ] ");

                } while (!int.TryParse(Console.ReadLine(),out questionType)|| questionType < 1 || questionType >3);
                
                if(questionType == 1 )
                {
                    Console.WriteLine($"The Data OF True or False Question Number {i+1}");
                    questions[i] = TFQuestions.AddTFQuestion();
                }
                else if(questionType == 2 )
                {
                    Console.WriteLine($"The Data of Choose One Question Number {i + 1}");
                    questions[i]= ChooseOneQuestions.AddChooseOneQuestion();
                     
                }
                else if(questionType == 3)
                {
                    Console.WriteLine($"The Data of MCQ Question Number {i + 1}");
                    questions[i] =MCQQuestions.AddMCQQuestion();

                }
            }
            return questions;
        }


        /*
         
         is this function violate any solid Principle 
         let's see
          
         1.SRP : multiple responsibilities 
                  this function not only creates the question it also interact with the user to gather input
                  it's best to separate these responsibilities into different functions 
               
         2.OCP : if U needs to add support for new Question types this function will be modified 
                  the code not closed for modification 
                     so we can use factory DP 
                             class QuestionFactory
                                       public static QuestionBase CreateQuestion()
         
         */
    }
}
