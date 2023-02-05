using System;
using Dialogue;
using TMPro;
using Unity.VisualScripting;
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
        public static int enemiesRunning = 0;

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
        public float yValue;
        public float root1Speed;
        
        [Header("Root0")]
        public float root0Speed;

        private PlayerInteraction _playerInteraction;
        private EnemyState _currentState;
        public int _rootValue;
        private int _unrootTime;
        private float _time;
        private bool stopMoving = false;

        private void Awake()
        {
            _playerInteraction = FindObjectOfType<PlayerInteraction>();
            rB = GetComponent<Rigidbody2D>();
            _rootValue = 3;
            _unrootTime = Random.Range(minTime, maxTime);
            _time = 0.0f;
            ChangeWaypoint();
            ChangeState();
        }

        private void Update()
        {
            if(canvas.activeSelf) PressButton();
            if (_time > _unrootTime && runTimer && !stopMoving) 
                DecreaseRoot();
            _time += Time.deltaTime;
            
            Vector3 pos = transform.position;
            
            
            if (!stopMoving) _currentState.Execute(this, Time.deltaTime);
        }
        
        #region States

        private void ChangeState()
        {
            switch (_rootValue)
            {
                case 1:
                    if (_currentState.Equals(typeof(EnemyState3))) enemiesRunning--;
                    SetState(new EnemyState1());
                    break;
                case 2:
                    SetState(new EnemyState2());
                    break;
                case 3:
                    SetState(new EnemyState3());
                    break;
                default:
                    if (enemiesRunning < 3)
                    {
                        enemiesRunning++;
                        SetState(new EnemyState0());
                    }
                    else SetState(new EnemyState1());
                    break;
            }
            Debug.Log($"Estado actual: {_currentState}");
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

        public void ChangeWaypoint()
        {
            waypoint = GameManager.Instance.waypoints[Random.Range(0, GameManager.Instance.waypoints.Count)].transform;
        }

        #endregion
        
        #region Dialogues

        public void ActiveDialogue()
        {
            if (!canvas.activeSelf)
            {
                interacting = true;
                AudioManager.Instance.OpenDialogSound();
                canvas.SetActive(true);
                GetComponent<ConversationSystem>().SetText();
                stopMoving = true;
            }
        }
        
        private void PressButton()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ButtonSelected(button1.GetComponent<Button>());
                stopMoving = false;
                _playerInteraction._isInteracting = false;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ButtonSelected(button2.GetComponent<Button>());
                stopMoving = false;
                _playerInteraction._isInteracting = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ButtonSelected(button3.GetComponent<Button>());
                stopMoving = false;
                _playerInteraction._isInteracting = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                ButtonSelected(button4.GetComponent<Button>());
                stopMoving = false;
                _playerInteraction._isInteracting = false;
            }
            
            interacting = false;
        }
        
        private void ButtonSelected(Button button)
        {
            string response = button.GetComponentInChildren<TextMeshProUGUI>().text;
            _rootValue += GetComponent<ConversationSystem>().CheckResponse(archetipe, response);
            if (_rootValue == 2) GameManager.Instance.peopleOnWaypoint++;
            ChangeState();
            _time = 0.0f;
            AudioManager.Instance.ChooseOptionSound();
            canvas.SetActive(false);
        }

        #endregion

        #region Roots

        private void DecreaseRoot()
        {
            if (_rootValue != 0)
            {
                if (_rootValue == 2 &&
                    GameManager.Instance.peopleLeft - GameManager.Instance.peopleOnWaypoint < 3)
                {
                    _rootValue -= 1;
                    GameManager.Instance.peopleOnWaypoint--;
                    ChangeState();
                    _unrootTime = Random.Range(minTime, maxTime);
                }
                else if(_rootValue != 2)
                {
                    _rootValue -= 1;
                    ChangeState();
                    _unrootTime = Random.Range(minTime, maxTime);
                }
            }
            _time = 0.0f;
        }

        #endregion
    }
}