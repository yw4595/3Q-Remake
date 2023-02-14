using System;

namespace RandomQuestionGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string[] questions = { "What is your favorite color?", "What is the capital of France?", "What is the largest ocean in the world?" };
            string[] answers = { "blue", "Paris", "Pacific" };
            int questionNumber, timeLimitInSeconds = 5;
            string userAnswer, playAgain;

            do
            {
                Console.Write("Choose your question (1-3): ");
                while (!int.TryParse(Console.ReadLine(), out questionNumber) || questionNumber < 1 || questionNumber > 3)
                {
                    Console.Write("Invalid input. Please enter a number between 1 and 3: ");
                }

                Console.WriteLine($"You have {timeLimitInSeconds} seconds to answer the following question:");
                Console.WriteLine(questions[questionNumber - 1]);

                // Start timer
                var timer = new System.Threading.Timer((_) =>
                {
                    Console.WriteLine("Time's up!");
                }, null, timeLimitInSeconds * 1000, System.Threading.Timeout.Infinite);

                // Read user input
                userAnswer = Console.ReadLine().ToLower();

                // Stop timer
                timer.Dispose();

                // Check user answer
                if (userAnswer == answers[questionNumber - 1])
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Wrong. The correct answer is {answers[questionNumber - 1]}");
                }

                Console.Write("Play again? (y/n): ");
                playAgain = Console.ReadLine().ToLower();
            } while (playAgain == "y");
        }
    }
}
