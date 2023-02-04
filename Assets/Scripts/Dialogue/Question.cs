using System;
using System.Collections.Generic;
using Enemy;

namespace Dialogue
{
    public class Response
    {
        public String responseText;
        public Archetipe archetipe;

        public Response(string responseText, Archetipe archetipe)
        {
            this.responseText = responseText;
            this.archetipe = archetipe;
        }
    }
    
    public class Question
    {
        public String questionText;
        public List<Response> responses;

        public Question(string questionText, List<Response> responses)
        {
            this.questionText = questionText;
            this.responses = responses;
        }
    }
}