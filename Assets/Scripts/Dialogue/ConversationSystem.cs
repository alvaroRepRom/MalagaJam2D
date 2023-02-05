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
            if (PlayerPrefs.GetInt("languaje") == 0) InitiateDictSpanish();
            else InitiateDictEnglish();
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

        private void RandomizeResponse()
        {
            List<Response> auxresponse = new List<Response>();
            auxresponse.AddRange(currentQuestion.responses);
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

        private void InitiateDictSpanish()
        {
            dic = new List<Question>();
            CreateQuestion("Tengo una cita con alguien", 
                "Si, claro...", "No te lo recomiendo, tus chakras no son compatibles", 
                "Algo totalmente normal", "Aquí seguro que conoces a alguien mejor");
            CreateQuestion("Tengo que estar en casa antes de las 12", 
                "Los servidores se reinician a las una, aun tienes tiempo", "Los astros recomiendan esperar a mas tarde", 
                "Tu madre me ha dicho que puedes estar un rato mas", "¿Y perderte la mejor parte de la fiesta?");
            CreateQuestion("Es muy tarde para mi, me voy", 
                "Los servidores se reinician a las una, aun tienes tiempo", "Los astros recomiendan esperar a mas tarde", 
                "Tu madre me ha dicho que puedes estar un rato mas", "¿Y perderte la mejor parte de la fiesta?");
            CreateQuestion("Me aburro", 
                "Juguemos al mario Kart", "Íbamos a empezar el debate sobre la naturaleza", 
                "No te aburras", "Echemos una partida de beer pong");
            CreateQuestion("La peor fiesta de la historia", 
                "Juguemos al mario Kart", "Íbamos a empezar el debate sobre la naturaleza", 
                "No te aburras", "Echemos una partida de beer pong");
            CreateQuestion("Echo de menos a mi gato", 
                "Tu gato es virtual y puedes verlo en el móvil", "Seguro que está bien con tus otros gatos", 
                "No tienes gato", "Tu tienes un perro");
            CreateQuestion("Tengo sueño", 
                "Los héroes no duermen mientras haya un crimen por resolver", "Ahora te traigo café en grano para despertarte", 
                "Échate una siesta en el sillón de la sala", "¿Pero tu duermes?");
            CreateQuestion("Me voy a dormir", 
                "Los héroes no duermen mientras haya un crimen por resolver", "Ahora te traigo café en grano para despertarte", 
                "Échate una siesta en el sillón de la sala", "¿Pero tu duermes?");
            CreateQuestion("Mañana tengo que ir a una Game Jam temprano", 
                "¿Qué tecnología vas a usar?", "¿Y cómo aplicas tus estudios en eso?",
                "Háblame de tu proyecto", "¿Tu en una Game Jam?");
            CreateQuestion("Tengo que ir al hospital", 
                "Aguanta, Keanu Reeves aguantaría", "Espera, tengo un par de remedios naturales", 
                "Tengo una tirita, ¿te vale?", "No creo, estás en plena forma");
            //10
            CreateQuestion("Algo me ha sentado mal", 
                "Aguanta, Keanu Reeves aguantaría", "Espera, tengo un par de remedios naturales", 
                "Tengo una aspirina, ¿te vale?", "No creo, estás en plena forma");
            CreateQuestion("Me ha llamado mi madre", 
                "Ha llamado a la mía y dice que te quedes", "Tu verdadera madre, ¿la madre naturaleza?", 
                "Ya le llamarás", "Pero no le vas a hacer caso, ¿verdad?");
            CreateQuestion("Esto me parece un ritual satánico mas que una fiesta",
                "A que sí, mola mucho ¿verdad?", "Es toda una experiencia extrasensorial",
                "Si, lo es y no pasa nada", "No hay huevos a quedarte mas tiempo");
            CreateQuestion("Mas que una fiesta parece un ritual satánico",
                "A que sí, mola mucho ¿verdad?", "Es toda una experiencia extrasensorial",
                "Si, lo es y no pasa nada", "No hay huevos a quedarte mas tiempo");
            CreateQuestion("Esta música es un poco tétrica", 
                "Podemos cambiarlo por Bandas sonoras", "Vamos a poner un poco de Reagge", 
                "Ahora ponemos música pop", "Pondremos algo de rap");
            CreateQuestion("Tengo hambre", 
                "He pedido pizza y hamburguesas", "Vamos a traer galletas especiadas", 
                "Le diré a mi madre que prepare croquetas", "Ahora te traigo unas barritas energéticas");
            CreateQuestion("Mi perro ha mordido al vecino", 
                "Tu perro es virtual, no puede morder a nadie", "Vives en mitad del campo sin vecinos", 
                "Bueno, ya no puedes hacer nada", "Es normal en un perro tan activo");
            CreateQuestion("Tengo sed", 
                "¿Un monster fresquito?", "Te hago un té de hierbas",
                "Voy a por agua", "¿Un batido de proteínas?");
            CreateQuestion("Ahora empieza mi turno de trabajo", 
                "Teletrabajas, puedes empezar en otro momento", "No te dejes manipular por el capitalismo", 
                "Tu jefe ha llamado y te da la noche libre", "Tu no trabajas");
            CreateQuestion("Tengo que irme a trabajar", 
                "Teletrabajas, puedes empezar en otro momento", "No te dejes manipular por el capitalismo", 
                "¿A estas horas?", "Tú no trabajas");
            //20
            CreateQuestion("Huele raro", 
                "No intentes disimular", "Estamos preparando la diversión", 
                "Aquí tengo el ambientador", "Allí están mis pesas");
            CreateQuestion("Me he olvidado la chaqueta arriba", 
                "¿Esta de Lucky Star?", "La llevas puesta", 
                "Te la traigo", "Para qué, haz flexiones");
            CreateQuestion("Esta fiesta es un muermo", 
                "Mejor que el lol", "¡¡¡Fiesta!!!", 
                "Cambio la música", "Pongo el Wii Fit");
            CreateQuestion("Mi madre ya tiene listo el puchero", 
                "Aquí hay palomitas", "Vamos a hervir otra cosa aquí abajo", 
                "El de mi madre también. Baja ahora", "Te traigo un plato de arroz blanco");
            CreateQuestion("Me llaman para cenar", 
                "Aquí hay palomitas", "Vamos a hervir otra cosa aquí abajo", 
                "Hay cena aquí. Baja ahora", "Te traigo un plato de arroz blanco");
            CreateQuestion("Voy a por un vaso agua", 
                "¿Te lo traigo con gas o sin gas?", "Mejor te traigo un zumo de frutas", 
                "Pero si hay cerveza", "Compré bebidas isotónicas");
        }

        private void InitiateDictEnglish()
        {
            dic = new List<Question>();
            CreateQuestion("I have a date with someone", 
                "Yeah, sure...", "Don`t go, your chakras are not compatible", 
                "Something totally normal", "You'll probably meet someone better here");
            CreateQuestion("I need to be at home before 12 p.m.", 
                "Servers restart at 1 a.m. you still have time to play", "The stars recommend waiting until later.", 
                "Your mother said you could stay for a while", "You'll lose the best part of the party!");
            CreateQuestion("It's too late, I'm leaving",
                "Servers restart at 1 a.m. you still have time to play", "The stars recommend waiting until later.",
                "Your mother said you could stay for a while", "You'll lose the best part of the party!");
            CreateQuestion("I'm bored", 
                "Let's play Mario Kart", "We were going to debate about nature", 
                "Don't get bored", "Let's play beer pong");
            CreateQuestion("Worst party ever",
                "Let's play Mario Kart", "We were going to debate about nature",
                "Don't get bored", "Let's play beer pong");
            CreateQuestion("I miss my cat", 
                "Your cat is virtual and you can see it on your phone", "It is probably playing with other cats", 
                "You don't have a cat", "You have a dog");
            CreateQuestion("I'm sleepy", 
                "Heroes can't sleep while there is a crime to resolve", "I'll bring you coffe beans to wake you up", 
                "You can sleep on that chair", "Do you even sleep?");
            CreateQuestion("I'm going to sleep",
                "Heroes can't sleep while there is a crime to resolve", "I'll bring you coffe beans to wake you up",
                "You can sleep on that chair", "Do you even sleep?");
            CreateQuestion("Tomorrow I'm going to a Game Jam early in the morning", 
                "Which technology are you using?", "And how do you apply your studies to that?",
                "Talk to me about your projects", "You? In a Game Jam?");
            CreateQuestion("I need to go to the hospital", 
                "Hang in there, Keanu Reeves would do that", "Wait, I've got a couple of natural remedies", 
                "I have a band-aid, is that enough?", "I don't think so, you're in great shape");
            //10
            CreateQuestion("I must have eaten something bad",
                "Hang in there, Keanu Reeves would do that", "Wait, I've got a couple of natural remedies",
                "I have a band-aid, is that enough?", "I don't think so, you're in great shape");
            CreateQuestion("My mother called me", 
                "She called mine and told you to stay", "Your real mother, mother nature?", 
                "You can call her later", "But you are not listening to her, right?");
            CreateQuestion("This looks more like a satanic ritual than a party to me.",
                "Yeah, cool right?", "It is an extrasensory experience",
                "Yes, it is and that's OK", "I dare you to stay");
            CreateQuestion("Looks more like a satanic ritual than a party",
                "Yeah, cool right?", "It is an extrasensory experience",
                "Yes, it is and that's OK", "I dare you to stay");
            CreateQuestion("This music is a bit spooky", 
                "We can change it to OSTs", "Let's hear some Reagge", 
                "We can hear pop music later", "We'll hear some rap later");
            CreateQuestion("I'm hungry", 
                "I ordered some pizzas already", "Let's bring spiced biscuits", 
                "I'll tell my mother to prepare some sandwiches", "I can bring you some energy bars");
            CreateQuestion("My dog bite my neighbour", 
                "Your dog is virtual, it cannot bite anyone", "You live in the middle of nowhere without neighbours", 
                "It cannot be helped", "It's normal in such an active dog");
            CreateQuestion("I'm thirsty", 
                "Do you want a Monster?", "I'll prepare some herbal tea",
                "I'll bring some water", "Do you want a protein shake?");
            CreateQuestion("I have to work now", 
                "It's telework, you can work from here", "Don't be manipulated by capitalism", 
                "Your boss called and said you don't have to work today", "You don't have a job");
            CreateQuestion("I'm leaving, I have to work",
                "It's telework, you can work from here", "Don't be manipulated by capitalism",
                "Your boss called and said you don't have to work today", "You don't have a job");
            //20
            CreateQuestion("It smells weird in here",
                "Don't try to hide it", "We are preparing something funny",
                "Here I have the air freshener", "My weights are there");
            CreateQuestion("I forgot my jacket upstairs", 
                "Is it this one from Lucky Star?", "You are wearing it", 
                "I'll bring it later", "You don't need it, do push-ups");
            CreateQuestion("This party sucks", 
                "It's better than playing LoL", "Let's party!!!", 
                "I'll change the music", "Let's play Wii Fit");
            CreateQuestion("My mother has prepared my dinner", 
                "We have popcorns here", "Let's cook something here", 
                "So did my mother, come back here", "I'll bring you some white rice");
            CreateQuestion("My parents called me for dinner",
                "We have popcorns here", "Let's cook something here",
                "So did my mother, come back here", "I'll bring you some white rice");
            CreateQuestion("I want a glass of water", 
                "I'll do it, do you want it with gas?", "I'll bring you some fruits juice", 
                "We already have beer here", "I bought energetic drinks");
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
    }

}