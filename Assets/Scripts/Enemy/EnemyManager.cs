using System;
using Dialogue;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public enum Archetipe
    {
        NERD, 
        HIPPIE,
        NORMIE,
        SPORTMAN
    }
    
    public class EnemyManager : MonoBehaviour
    {
        public float speed;
        public Archetipe archetipe;
        
        public GameObject canvas;
        public GameObject button1, button2, button3, button4;

        private int rootValue;

        private void Awake()
        {
            rootValue = 2;
        }

        public void ActiveDialogue()
        {
            canvas.SetActive(true);
            canvas.GetComponent<ConversationSystem>().SetText();
        }

        private void Update()
        {
            if(canvas.activeSelf) PressButton();
        }

        private void PressButton()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                ButtonSelected(button1.GetComponent<Button>());
            if (Input.GetKeyDown(KeyCode.Alpha2))
                ButtonSelected(button2.GetComponent<Button>());
            if (Input.GetKeyDown(KeyCode.Alpha3))
                ButtonSelected(button3.GetComponent<Button>());
            if (Input.GetKeyDown(KeyCode.Alpha4))
                ButtonSelected(button4.GetComponent<Button>());
        }
        private void ButtonSelected(Button button)
        {
            String response = button.GetComponentInChildren<TextMeshProUGUI>().text;
            rootValue += canvas.GetComponent<ConversationSystem>().CheckResponse(archetipe, response);
            canvas.SetActive(false);
        }
        
    }
}