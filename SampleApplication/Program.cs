using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DocomoApiSDK;

namespace SampleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiKey = string.Empty;   // set your api key if you'd like.
            if (string.IsNullOrEmpty(apiKey))
            {
                Console.Write("Please enter your api key:");
                apiKey = Console.ReadLine();
            }

            Console.WriteLine();
            Console.WriteLine("1 : Dialogue Sample");
            Console.WriteLine("2 : Knowledge QA Sample");

            Console.Write("Please select Sample Application:");
            var number = Console.ReadKey();
            Console.WriteLine();
            switch (number.KeyChar)
            {
                case '1':
                    ExecuteDialogue(apiKey);
                    break;
                case '2':
                    ExecuteKnowledgeQA(apiKey);
                    break;
                default:
                    break;
            }

            Console.WriteLine("Please enter any key:");
            Console.ReadKey();
        }

        private static void ExecuteDialogue(string apiKey)
        {
            Console.WriteLine("Start conversation with bot. Enter only 'q' if you'd like to stop conversation.");

            string context = "";
            while (true)
            {
                
                string c = Console.ReadLine();

                if ("q".Equals(c)) { break; }

                var request = new DocomoApiSDK.Dialogue.DialogueRequest();
                request.Utt = c;
                request.Context = context;

                using (var client = new HttpClient())
                {
                    var response = client.PostDialogueRequestAsync(apiKey, request).Result;
                    Console.WriteLine("utt:" + response.Utt);
                    Console.WriteLine("yomi:" + response.Yomi);
                    Console.WriteLine("context:" + response.Context);

                    context = response.Context;
                }
            }

            Console.Write("Finish conversation.");
        }

        private static void ExecuteKnowledgeQA(string apiKey)
        {
            Console.Write("Enter your question:");
            string c = Console.ReadLine();

            using (var client = new HttpClient())
            {
                var response = client.GetKnowledgeQAAsync(apiKey, c).Result;
                Console.WriteLine("Answer:" + response.Message.TextForDisplay);
            }

        }
    }
}
