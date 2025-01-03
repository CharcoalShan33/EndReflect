using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock.LowLevel;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _enemySpeed;
    private Rigidbody2D rig;
    private Animator _anim;
    [SerializeField] float attackRate;
    private float lastAttackTime;
    Vector2 direction;

    [SerializeField] GameObject player;

    

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        direction = transform.forward * _enemySpeed;
        //transform. position = Vector2.MoveTowards(transform.position, player.transform.position, _enemySpeed * Time.deltaTime);
    }
    void Attack()
    {
        if (Time.time - lastAttackTime > attackRate)
        {
            lastAttackTime = Time.time;
            _anim.SetTrigger("ToHit");
        }

    }









}
