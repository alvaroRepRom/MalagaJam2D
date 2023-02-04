using System;
using System.Collections.Generic;
using Enemy;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dialogue
{
    public class ConversationSystem : MonoBehaviour
    {
        public TextMeshProUGUI question;
        public TextMeshProUGUI response1, response2, response3, response4;

        private List<Question> dic;
        private Question currentQuestion; 

        private void Awake()
        {
            dic = new List<Question>();
            InitiateDict();
        }

        public void SetText()
        {
            int index = Random.Range(0, dic.Count);
            currentQuestion = dic[index];
            question.text = currentQuestion.questionText;
            RandomizeResponse();
        }

        public int CheckResponse(Archetipe archetipe, String responseSelectedText)
        {
            Archetipe arch = archetipe;
            foreach (var currentQuestionResponse in currentQuestion.responses)
            {
                if (responseSelectedText.Contains(currentQuestionResponse.responseText))
                {
                    arch = currentQuestionResponse.archetipe;
                    break;
                }
            }
            switch (archetipe)
            {
                case Archetipe.NERD:
                    if (arch == Archetipe.SPORTMAN) return -1;
                    if (arch == Archetipe.NERD) return 1;
                    break;
                case Archetipe.HIPPIE:
                    if (arch == Archetipe.NORMIE) return -1;
                    if (arch == Archetipe.HIPPIE) return 1;
                    break;
                case Archetipe.NORMIE:
                    if (arch == Archetipe.HIPPIE) return -1;
                    if (arch == Archetipe.NORMIE) return 1;
                    break;
                case Archetipe.SPORTMAN:
                    if (arch == Archetipe.NERD) return -1;
                    if (arch == Archetipe.SPORTMAN) return 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(archetipe), archetipe, null);
            }
            return 0;
        }

        private void InitiateDict()
        {
            dic = new List<Question>();
            CreateQuestion("Hola", "Respuesta 1", "Respuesta 2", "Respuesta 3", "Respuesta 4");
            CreateQuestion("Adios", "Cosa 1", "Cosa 2", "Cosa 3", "Cosa 4");
        }

        private void CreateQuestion(string question, 
            string nerdResponse, string hippieResponse, string normieResponse, string sportmanResponse)
        {
            List<Response> responses = new List<Response>();
            responses.Add(new Response(nerdResponse, Archetipe.NERD));
            responses.Add(new Response(hippieResponse, Archetipe.HIPPIE));
            responses.Add(new Response(normieResponse, Archetipe.NORMIE));
            responses.Add(new Response(sportmanResponse, Archetipe.SPORTMAN));
            dic.Add(new Question(question, responses));
        }

        private void RandomizeResponse()
        {
            List<Response> auxresponse = new List<Response>();
            auxresponse.AddRange(currentQuestion.responses);
            Debug.Log(auxresponse.Count);
            int index = Random.Range(0, auxresponse.Count);
            response1.text = "1 " + auxresponse[index].responseText;
            auxresponse.RemoveAt(index);
            index = Random.Range(0, auxresponse.Count);
            response2.text = "2 " + auxresponse[index].responseText;
            auxresponse.RemoveAt(index);
            index = Random.Range(0, auxresponse.Count);
            response3.text = "3 " + auxresponse[index].responseText;
            auxresponse.RemoveAt(index);
            index = Random.Range(0, auxresponse.Count);
            response4.text = "4 " + auxresponse[index].responseText;
            
        }
    }

}