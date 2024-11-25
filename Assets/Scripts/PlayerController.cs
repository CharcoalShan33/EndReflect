using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
 public static PlayerController instance;
    private PlayerActions _playerInput;

    private Rigidbody2D rig;
    [SerializeField] float _speed;
    //[SerializeField] float _maxSpeed;
    float defaultSpeed = 90;
    [SerializeField] float multiplierSpeed = 1.5f;
   [SerializeField] bool isRunning;

    private Animator _anim;
    private Vector2 movement;

    bool deactivateMove = false;
  
    [Header("Attacking")]
    [SerializeField] float attackRate;

    private float lastAttack;
    [SerializeField] float coolDown;
    private float lastBreak;

    [Header("Encounter")]

    [SerializeField] int stepCounter;

    bool moveInArea;






    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        rig = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
       

        DontDestroyOnLoad(gameObject);

        

    }
    void Start()
    {
        _playerInput = new();
        _playerInput.Enable();
        Setup();
        
        
    }


    private void Setup()
    {
        // if the context/key pressed will equal or not equal to true;
        // ctx is the same as InputAction.CallbackContext context
        _playerInput.MainPlayer.Run.started += ctx => isRunning = true;
        _playerInput.MainPlayer.Run.canceled += ctx => isRunning = false;
        _playerInput.MainPlayer.Interaction.performed += OnInteract;
        _playerInput.MainPlayer.Attack.performed += OnAttack;
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        if(Time.time - lastAttack > attackRate)
        {
            lastAttack = Time.time;
            _anim.SetTrigger("ToHit");
        }
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("Interact");
        _anim.SetTrigger("Interact");
    }


    // Update is called once per frame
    private void Update()
    {
        if(deactivateMove)
        {
            movement = Vector2.zero;
        }
        else
        {
            AllMovement();
        }
      
    }

    private void AllMovement()
    {
        movement = _playerInput.MainPlayer.Movement.ReadValue<Vector2>();
        //movement = _playerInput.Movement.Directional.ReadValue<Vector2>();
        float hInput = _playerInput.MainPlayer.Movement.ReadValue<Vector2>().x;
        float yInput = _playerInput.MainPlayer.Movement.ReadValue<Vector2>().y;

        movement = new Vector2(hInput, yInput).normalized;
        _anim.SetFloat("moveX", movement.x);
        _anim.SetFloat("moveY", movement.y);

        if (hInput != 0 || yInput != 0)
        {
            _anim.SetFloat("lastX", hInput);
            _anim.SetFloat("lastY", yInput);

        }

        if (isRunning)
        {
            _speed = multiplierSpeed * defaultSpeed;
            _anim.SetBool("isRunning", true);
        }
        else if (!isRunning)
        {
            _speed = defaultSpeed;
            _anim.SetBool("isRunning", false);
        }
    }

    void FixedUpdate()
    {
        
        
        rig.velocity = movement *_speed * Time.fixedDeltaTime;
    }


public bool DeactivateMovement(bool movement)
    {
        deactivateMove = movement;
        return movement;
    }




   
}
