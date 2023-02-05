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
        [HideInInspector]
        public Rigidbody2D rB;
        [HideInInspector]
        public bool interacting;
        [HideInInspector]
        public bool runTimer = false;

        [Header("Root3")]
        //Punto que tendrá este enemigo en concreto.
        public Transform waypoint;
        //Velocidad a la que se mueve a su punto de spawn. Esto sera para cuando vuelva al estado 3.
        public float defaultSpeed;

        [Header("Root2")] 
        public float root2Speed;

        [Header("Root1")]
        public Transform exit;
        public float root1Speed;
        
        [Header("Root0")]
        public float root0Speed;
        
        private EnemyState _currentState;
        private int _rootValue;
        private int _unrootTime;
        private float _time;

        private void Awake()
        {
            rB = GetComponent<Rigidbody2D>();
            _rootValue = 3;
            _unrootTime = Random.Range(minTime, maxTime);
            _time = 0.0f;
            ChangeState();
        }

        private void Update()
        {
            if(canvas.activeSelf) PressButton();
            if (_time > _unrootTime && runTimer) DecreaseRoot();
            _time += Time.deltaTime;
            
            _currentState.Execute(this);
        }
        
        #region States

        private void ChangeState()
        {
            switch (_rootValue)
            {
                case 1:
                    SetState(new EnemyState1());
                    break;
                case 2:
                    SetState(new EnemyState2());
                    break;
                case 3:
                    SetState(new EnemyState3());
                    break;
                default:
                    SetState(new EnemyState0());
                    break;
            }
            _time = 0.0f;
        }
        
        public void SetState(EnemyState newState)
        {
            _currentState = newState;
            _currentState.OnStateEnter(this);
        }

        public void SetTimer()
        {
            _time = 0.0f;
        }

        #endregion
        
        #region Dialogues

        public void ActiveDialogue()
        {
            if (_rootValue != 3 && !canvas.activeSelf)
            {
                AudioManager.Instance.OpenDialogSound();
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
            AudioManager.Instance.ChooseOptionSound();
            canvas.SetActive(false);
        }

        #endregion

        #region Roots

        public void ChangeSprite()
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
                ChangeState();
                _unrootTime = Random.Range(minTime, maxTime);
                _time = 0.0f;
            }
        }

        #endregion
    }
}