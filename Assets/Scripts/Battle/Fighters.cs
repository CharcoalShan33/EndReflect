using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighters : MonoBehaviour
{

   
    [Header("Other")]
    public BattleStats data;
    public enum AttackType // 
    {
        Ranged,
        
        Melee,

        Casting,

       // MultiCast,

        //MultiShot, 

        //MultiHit
    }
    public AttackType attackType;

   [Header("Movement")]
   [SerializeField] float moveSpeed = 4.0f;
    [SerializeField]float defaultSpeed = 10.5f;

    private Animator _anim;
    private SpriteRenderer _spr;
    
    private const string ATTACK_ = "Attack";
    private const string HURT_ = "Hit";
    private const string DEAD_ = "Dead";
    private const string SLIDE = "isSliding";
    private const string RETURN = "Home";



    public List<Spells> availableSpells; // make game object if I have to.
    private bool isRunning;

    private bool actionStarted;


   public bool isMagicAttack;
    public bool isRanged; // archers only // can activate by critical hit
    public bool isCasting; // only activated by healing/buffing;


   [SerializeField] List<Spells> allSpells;

    [SerializeField] GameObject projectile;
    [SerializeField] Transform shootPosition;
    
        void Start()
    {
        _anim = GetComponent<Animator>();
        _spr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(attackType)
        {
            case AttackType.Ranged:
            
        
            break;

            case AttackType.Casting:
            
            break;

            case AttackType.Melee:
           
            break;



        }
    }

    public IEnumerator Physical()
    {
        attackType = AttackType.Melee;
       isMagicAttack = false;
        if(actionStarted == true)
        {
            yield break;
        }

        actionStarted = true;




    }
    public IEnumerator RangedAttack()
    {
         attackType = AttackType.Ranged;
   
        if(actionStarted == true)
        {
            yield break;
        }

        actionStarted = true;




    }

    public IEnumerator Casting() // movement
    {
        attackType = AttackType.Casting;
       isMagicAttack = true;
        if(actionStarted == true)
        {
            yield break;
        }

        actionStarted = true;




    }

    public void ShootProjectile() // NoMovement
    {
        Instantiate(projectile, shootPosition.position, shootPosition.rotation );
        
        // magic
        {

            // spells go here
            // effects and
        }
      
        {
        /// instantiate arrow here
        /// archers only
        /// 
        }
      

    }


    private IEnumerator MagicShot()
    {
        
         if(actionStarted == true)
        {
            yield break;
        }

        actionStarted = true;   
        
        // add effect here
        // instantiate objects go here




    }

     public void NoMoving()
    {
        moveSpeed = 0f;
    }

    public void Moving()
    {
        moveSpeed = defaultSpeed;
    }






}
