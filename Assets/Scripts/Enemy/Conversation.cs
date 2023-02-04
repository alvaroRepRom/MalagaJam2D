using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Enemy
{
    public class Conversation :MonoBehaviour
    {

        public void Awake()
        {
        }

        public void DebugData()
        {
            Debug.Log("Hola");
        }

        public void ShowElection(String election)
        {
            Debug.Log(election);
        }

        private void OnDisable()
        {
            Lua.UnregisterFunction("Mstrartexto");
            Lua.UnregisterFunction("ShowElection");
        }

        private void OnEnable()
        {
            Lua.RegisterFunction("DebugData", this, SymbolExtensions.GetMethodInfo(() => DebugData()));
            Lua.RegisterFunction("ShowElection", this, SymbolExtensions.GetMethodInfo(() => ShowElection("Adios")));
        }

        void OnConversationLine(Subtitle subtitle)
        {
            // Add text from another source:
            subtitle.formattedText.text += "This is additional text.";
        }
        
        void OnConversationResponseMenu(Response[] responses)
        {
            foreach (var res in responses)
            { 
                Debug.Log(res.formattedText.text);
            }
            responses[0].formattedText.text = "texto1";
            responses[1].formattedText.text = "texto2";
            responses[2].formattedText.text = "texto3";
            responses[3].formattedText.text = "texto4";
        }

        public void Mstrartexto()
        {
            Debug.Log("Ha entrado");
            GetComponent<DialogueSystemTrigger>().barkText = "Buenas";
            DialogueManager.StopConversation();
            //DialogueManager.StartConversation("Prueba", other.transform, transform, -1);
        }
    }
}