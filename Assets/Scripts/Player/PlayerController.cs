using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] private float lifePlayer;
    [SerializeField] private float currentlifePlayer;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody2D rig;
    private Vector3 _moviment;

    #region Collect Objects
    // Fruits
    [SerializeField] private int _totalApplePoints;
    [SerializeField] private int _totalPineapplesPoints;

    // Objects
    [SerializeField] private int _totalCoinPoints;
    [SerializeField] private int _totalKeyPoints;
    [SerializeField] private float _totalLifePoints;

    #endregion

    #region Boolean
    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _isJumping;
    public float LifePlayer1 { get => lifePlayer; set => lifePlayer = value; }
    public Vector3 moviment { get => _moviment; set => _moviment = value; }
    public bool isGrounded { get => _isGrounded; set => _isGrounded = value; }
    public bool isJumping { get => _isJumping; set => _isJumping = value; }
    public float LifePlayer { get => LifePlayer1; set => LifePlayer1 = value; }
    public float Speed { get => speed; set => speed = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
    public int totalKeyPoints { get => _totalKeyPoints; set => _totalKeyPoints = value; }
    public int totalCoinPoints { get => _totalCoinPoints; set => _totalCoinPoints = value; }
    public int TotalApplePoints { get => _totalApplePoints; set => _totalApplePoints = value; }
    public int TotalPineapplesPoints { get => _totalPineapplesPoints; set => _totalPineapplesPoints = value; }
    public float TotalLifePoints { get => _totalLifePoints; set => _totalLifePoints = value; }
    public float CurrentlifePlayer { get => currentlifePlayer; set => currentlifePlayer = value; }
    #endregion
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        currentlifePlayer = LifePlayer;
    }
    private void Update()
    {
        OnInput();
        if (Input.GetButtonDown("Jump") && _isGrounded) 
        {
            OnJump();
        }
    }

    private void FixedUpdate()
    {
        OnMove();
    }
    void OnInput()
    {
        _moviment.x = Input.GetAxisRaw("Horizontal");

        
    }

    #region Moviment
    void OnMove()
    {
        transform.position += new Vector3(_moviment.x, 0f, 0f) * Time.fixedDeltaTime * Speed;
    }

    void OnJump()
    {
        rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse); 
        _isGrounded = false;
        _isJumping = true;
        // Aplicar a logica para pular apenas quando estiver no chao.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            _isJumping = false;
        }
    }
    #endregion

    #region Collect Objects (Methods)

    public void AddPoints(TypeObject typeObject, int points)
    {
            switch (typeObject)
            {
                case TypeObject.Apple:
                    TotalApplePoints += points;
                    break;
                case TypeObject.Pineapple:
                    TotalPineapplesPoints += points;
                    break;
                case TypeObject.Coin:
                    totalCoinPoints += points;
                    break;
                case TypeObject.Key:
                    totalKeyPoints += points;
                    break;
                case TypeObject.Heart:
                    TotalLifePoints += points;
                    break;
            }
        //Debug.Log("Total Points Apple: " + totalApplePoints);
        //Debug.Log("Total Points Pineapple: " + totalPineapplesPoints);
        //Debug.Log("Coin Total: " + totalCoinPoints);
        //Debug.Log("Key Total: " + totalKeyPoints);
        //Debug.Log("Life Total: " + totalLifePoints);
        }

    #endregion
}
