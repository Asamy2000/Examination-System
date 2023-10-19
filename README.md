# Examination System

## Description

The Examination System is a simple console application that simulates an examination environment. It allows users to create and take exams for specific subjects. The program provides the ability to create practical and final exams, add questions of various types, and calculate exam grades.

## Classes

### 1. Subject

- Represents a subject within the system.
- Contains methods to create exams and manage associated exam details.
- Allows users to set the type of exam (practical or final), exam duration, and the number of questions.
- Calculates the total exam grade based on question marks.

### 2. Exam

- An abstract base class for different types of exams (practical and final).
- Stores common exam attributes, such as time, number of questions, and exam grade.
- Provides a method to display the exam and record answers.

### 3. PracticalExam

- Represents a practical exam, derived from the "Exam" class.
- Allows users to take and grade practical exams.

### 4. FinalExam

- Represents a final exam, derived from the "Exam" class.
- Allows users to take and grade final exams.

### 5. QuestionBase

- An abstract base class for different types of exam questions.
- Defines common question attributes, such as question body, marks, answer list, and right answer.
- Provides methods for question creation.

### 6. TFQuestions

- Represents True or False questions.
- Includes methods for creating and adding True or False questions.
- Allows users to set the correct answer (True or False).

### 7. MCQQuestions

- Represents Multiple Choice Questions (MCQs).
- Includes methods for creating and adding MCQ questions.
- Allows users to specify question text and multiple answer choices.

### 8. ChooseOneQuestions

- Represents Choose One questions.
- Includes methods for creating and adding Choose One questions.
- Allows users to define question text and select the correct answer among provided choices.

### Program Structure

- The program is structured as a console application.
- The entry point is the "Main" method, where users can create and take exams for a specific subject.

## Usage

1. Run the program.
2. Create a subject and define the exam (type, duration, and number of questions).
3. Choose whether to take the exam.
4. Answer the exam questions, and your grade will be calculated.
5. The program records the time taken to complete the exam.

## Installation

1. Clone or download the project from the repository.
2. Open the project in a C# development environment.
3. Build and run the program.

## Dependencies

The program has no external dependencies and can be run on any system with the .NET Core runtime installed.




