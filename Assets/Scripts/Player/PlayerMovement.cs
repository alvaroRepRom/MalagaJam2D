using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rb2D;
    private SpriteRenderer _sR;
    private Vector2 _moveVector;
    private float _horizontal, _vertical;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _sR = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        GetInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInputs()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _moveVector = new Vector2(_horizontal, _vertical);
        _moveVector.Normalize();
    }

    private void Move()
    {
        //Movemos al player con la velocidad del RigidBody.
        _rb2D.velocity = _speed * Time.deltaTime * _moveVector;
        GetComponentInChildren<Animator>().SetBool("Walk", (_horizontal!=0 || _vertical!=0));
        //Flipeamos el sprite del jugador sólo cuando se mueva.
        if (_horizontal != 0) TurnPlayer();
    }

    private void TurnPlayer()
    {
        _sR.flipX = _horizontal < 0;
    }
}
