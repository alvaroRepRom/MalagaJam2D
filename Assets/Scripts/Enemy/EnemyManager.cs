using System;
using Dialogue;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
        public Archetipe archetipe;
        public int maxTime, minTime;
        
        [Header("Canvas")]
        public GameObject canvas;
        public GameObject button1;
        public GameObject button2;
        public GameObject button3;
        public GameObject button4;
        
        [Header("Brotes")]
        public GameObject brote1;
        public GameObject brote2;
        public GameObject raices;

        [Header("Logic")] 
        public float root0Speed, root1Speed, root2Speed;
        public bool interacting;
        public bool runTimer;

        private EnemyState _currentState;
        private int _rootValue;
        private int _unrootTime;
        private float _time;

        private void Awake()
        {
            _rootValue = 2;
            _unrootTime = Random.Range(minTime, maxTime);
            _time = 0.0f;
            ChangeSprite();
        }

        private void Update()
        {
            if(canvas.activeSelf) PressButton();
            if (_time > _unrootTime) DecreaseRoot();
            _time += Time.deltaTime;
        }

        #region States

        public void ChangeState()
        {
            
        }

        #endregion
        
        #region Dialogues

        public void ActiveDialogue()
                {
                    if (_rootValue != 3 && !canvas.activeSelf)
                    {
                        canvas.SetActive(true);
                        GetComponent<ConversationSystem>().SetText();
                    }
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
                    string response = button.GetComponentInChildren<TextMeshProUGUI>().text;
                    _rootValue += GetComponent<ConversationSystem>().CheckResponse(archetipe, response);
                    ChangeSprite();
                    canvas.SetActive(false);
                }

        #endregion

        #region Roots

        private void ChangeSprite()
        {
            switch (_rootValue)
            {
                case 1:
                    brote1.SetActive(true);
                    brote2.SetActive(false);
                    break;
                case 2:
                    brote1.SetActive(false);
                    brote2.SetActive(true);
                    raices.SetActive(false);
                    break;
                case 3:
                    brote2.SetActive(false);
                    raices.SetActive(true);
                    break;
                default:
                    brote1.SetActive(false);
                    break;
            }
            _time = 0.0f;
        }

        private void DecreaseRoot()
        {
            if (_rootValue != 0)
            {
                _rootValue -= 1;
                ChangeSprite();
                _unrootTime = Random.Range(minTime, maxTime);
                _time = 0.0f;
            }
        }

        #endregion
    }
}