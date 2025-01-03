using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Timeline;

public class Actions : MonoBehaviour
{
   private Animator _anim;
   private const string ATTACK_PARAM = "Attack";
   private const string SLIDING_PARAM = "isSliding";
   private const string IDLE_PARAM = "Stop";
   private const string RANGED_PARAM = "isRanged";

    private const string CASTING_PARAM = "Casting";
    private const string RETURN = "Home";


   [SerializeField] private Transform startPosition;
   //private Vector3 startPositon = new(17f, -2f,0f);
   private Vector3 newPosition = new(0f,2f,0f);

   private Vector3 otherPosition = new(17f,-7,0f);
   
   [SerializeField]private Transform targetPos;
   // [SerializeField] float speed;

   [SerializeField]PlayerUnit player;

    //[SerializeField] Spells oneSpell;
    //[SerializeField] GameObject targetOne;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
       
       
    }
 void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
           // StartCoroutine(AttackAction());
        }


        if(Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(RangedAction());
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            //StartCoroutine(HealAction());
        }
    }

   
    private IEnumerator AttackAction()
    {   
       _anim.SetBool(SLIDING_PARAM, true);
        Vector3 setPosition = new(targetPos.transform.position.x- 1.85f,targetPos.transform.position.y,targetPos.transform.position.z );
       while(MoveTowardsTarget(setPosition))
       { 
        
        
        yield return null;
       } 
       yield return new WaitForSeconds(.5f);
       
      //damagedealer
        _anim.SetTrigger(ATTACK_PARAM);

        _anim.SetTrigger(IDLE_PARAM);


        yield return new WaitForSeconds(1.5f);
        _anim.SetBool(SLIDING_PARAM, false);
        Vector3 firstPos = startPosition.position;     
       
         while(MoveTowardStart(firstPos))
       { 
        // _anim.SetBool(IDLE_PARAM, false);
        yield return null;
       } 
   
       _anim.SetBool("Home", true);
       yield return new WaitForSeconds(.15f);
       _anim.SetBool("Home", false);
      

    }
     private IEnumerator RangedAction()
    {
        // _anim.SetTrigger(IDLE_PARAM);
        _anim.SetBool(RANGED_PARAM, true);

       _anim.SetBool(SLIDING_PARAM, false);
        Vector3 setPosition = new(targetPos.transform.position.x,targetPos.transform.position.y,targetPos.transform.position.z );
       while(MoveTowardsTarget(setPosition))
       { 
        // _anim.SetBool(IDLE_PARAM, true);
        yield return null;
       } 

       yield return new WaitForSeconds(.5f);
      //damagedealer
        _anim.SetTrigger(ATTACK_PARAM);

       // _anim.SetBool(IDLE_PARAM, true);
        yield return new WaitForSeconds(1.5f);
        _anim.SetBool(SLIDING_PARAM, true);
        Vector3 firstPos = newPosition;    
       
         while(MoveTowardStart(firstPos))
       { 
        // _anim.SetBool(IDLE_PARAM, false);
        yield return null;
       } 
       yield return new WaitForSeconds(.5f);
        _anim.SetBool(RETURN, true);
        yield return new WaitForSeconds(.5f);
        _anim.SetBool(RETURN, false);
       
    }

    private IEnumerator HealAction()
    {
         _anim.SetBool(SLIDING_PARAM, true);
        Vector3 setPosition = new(targetPos.transform.position.x,targetPos.transform.position.y,targetPos.transform.position.z );
       while(MoveTowardsTarget(setPosition))
       { 
        // _anim.SetBool(IDLE_PARAM, true);
        yield return null;
       } 
       yield return new WaitForSeconds(.5f);
      //damagedealer
        
        
        _anim.SetTrigger(CASTING_PARAM);
        yield return new WaitForSeconds(.25f);
        //oneSpell.CastSpell(targetOne);
        //Instantiate(oneSpell.gameObject, transform.position, quaternion.identity);
      //

        yield return new WaitForSeconds(1.5f);
        _anim.SetBool(SLIDING_PARAM, false);
        Vector3 firstPos = otherPosition;  
       
         while(MoveTowardStart(firstPos))
       { 
        // _anim.SetBool(IDLE_PARAM, false);
        yield return null;
       } 
        yield return new WaitForSeconds(.5f);
        _anim.SetBool(RETURN, true);
         yield return new WaitForSeconds(.5f);
        _anim.SetBool(RETURN, false);
    }


    private bool MoveTowardsTarget(Vector3 position)
    {
        return position != (transform.position = Vector3.MoveTowards(transform.position, position, 10 * Time.deltaTime));
    }
    private bool MoveTowardStart(Vector3 position)
    {
        return position != (transform.position = Vector3.MoveTowards(transform.position, position, 10 * Time.deltaTime));
    }

    // Update is called once per frame
   
}
