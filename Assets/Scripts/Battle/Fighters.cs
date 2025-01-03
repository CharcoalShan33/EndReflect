using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighters : MonoBehaviour
{
   
    [Header("Other")]
    public BattleStats data;
    public enum AttackType // 
    {
        Archer,
        
        Magician,

        Warrior
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
    public bool isCasting;
    
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
            case AttackType.Archer:
            
        
            break;

            case AttackType.Magician:
            
            break;

            case AttackType.Warrior:
           
            break;



        }
    }

    private IEnumerator Physical()
    {
        attackType = AttackType.Warrior;
        isMagicAttack = false;
        if(actionStarted == true)
        {
            yield break;
        }

        actionStarted = true;




    }
    private IEnumerator RangedAttack()
    {
         attackType = AttackType.Archer;
        isMagicAttack = false;
        if(actionStarted == true)
        {
            yield break;
        }

        actionStarted = true;




    }

    private IEnumerator Casting()
    {
         attackType = AttackType.Magician;
        isMagicAttack = true;
        isCasting = true;
        if(actionStarted == true)
        {
            yield break;
        }

        actionStarted = true;




    }

    private void ShootArrow(bool noAttack)
    {
        isMagicAttack = noAttack;

        
        if(noAttack == false) // magic
        {
            // spells go here
        }
        else
        {
            /// instantiate arrow here
        /// archers only
        /// 
        }
      

    }


    private IEnumerator MagicShot()
    {
        isMagicAttack = true;
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
