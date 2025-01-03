using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;



public class LevelCharacter : MonoBehaviour 
{
    public PlayerInformation play;

    public CharacterStats characterData;
    private PlayerActions _playerInput;

    private Rigidbody2D rig;

    private SpriteRenderer spr;

    [Header("Character ")]
    [SerializeField] float _speed;
    //[SerializeField] float _maxSpeed;
    float defaultSpeed = 105;
    [SerializeField] float multiplierSpeed = 1.5f;
    [SerializeField] bool isRunning;

    
    public static LevelCharacter Instance;
   

    private Vector3 bottomLimit;
    private Vector3 topLimit;
    private Vector3 offset = new Vector3(.5f, .1f, 0f);
    private Animator _anim;
     private Vector2 movement;
    float hInput;
    float yInput;
   bool deactivateMove = false;

    public string sceneName;

    [Header("Attacking")]
    [SerializeField] float attackRate;

    private float lastAttack;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
       DontDestroyOnLoad(gameObject);

        _playerInput = new();
        _playerInput.Enable();
        Setup();

      

        SetStats();
    }

    public void SetStats()
    {
      play = new();
      play.armorPower = characterData.armorPower;
      play.weaponPower = characterData.weaponPower;
      play.currentHP = characterData.currentHP;
      play.maxHP = characterData.maxHP;
      play.currentMP = characterData.currentMP;
      play.MaxMP = characterData.MaxMP;
      play.attack = characterData.attack;
      play.defense = characterData.defense;
      play.magic = characterData.magic;
      play.magicDefense = characterData.magicDefense;
      play.speed = characterData.speed;
      play.sanity = characterData.sanity;
      play.maxSanity = characterData.maxSanity;
      play.friendship = characterData.friendship;
      play.playerLevel = characterData.playerLevel;
      //play.playerName = characterData.playerName;
      //play.characterImage = characterData.characterImage;
      
      
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

    // Update is called once per frame
     void OnAttack(InputAction.CallbackContext context)
    {
        if (Time.time - lastAttack > attackRate)
        {
            lastAttack = Time.time;
            _anim.SetTrigger("ToHit");
           
        }
    }
    private void OnInteract(InputAction.CallbackContext context)
    {
        //Debug.Log("Interact");
        _anim.SetTrigger("Interact");
    }


    // Update is called once per frame
    private void Update()
    {
        
        if (deactivateMove)
        {
            movement = Vector2.zero;
            hInput = 0;
            yInput = 0;
        }
        else if(!deactivateMove)
        {
            AllMovement();
           

        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,
            bottomLimit.x, topLimit.x), Mathf.Clamp(transform.position.y, bottomLimit.y, topLimit.y),
            transform.position.z);
    }

    void FixedUpdate()
    {
        // All movement here
        Velocity();
    }
    private void Velocity()
    {
        rig.velocity = movement * _speed * Time.fixedDeltaTime;
    }
    

    private void AllMovement()
    {
        //movement = _playerInput.Movement.Directional.ReadValue<Vector2>();
        movement = _playerInput.MainPlayer.Movement.ReadValue<Vector2>();
        hInput = _playerInput.MainPlayer.Movement.ReadValue<Vector2>().x;
        yInput = _playerInput.MainPlayer.Movement.ReadValue<Vector2>().y;
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

    public void NoMove()
    {
        deactivateMove = true;
        _speed = 0f;
        
       
    }

    public void SomeMove()
    {
        deactivateMove = false;
        _speed = defaultSpeed;
    }
    public bool DeactivateMovement(bool movement)
    {
        deactivateMove = movement;
        return movement;
    }


     public void SetBounds(Vector3 bottomScreen, Vector3 topScreen)
    {
        bottomLimit = bottomScreen + offset;
        topLimit = topScreen + -offset;
    }


    public static void AddEXP()
    {
        
    }


    



}


    





