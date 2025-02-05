using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.Mathematics;
using System.Xml.Schema;

public class Fighters : MonoBehaviour
{
    /// <summary>
    ///  Movement and Data
    /// </summary>


    [Header("Other")]
    public BattleStats data;
    public FighterStats fighterData;
    [Header("Movement")]
    [SerializeField] float moveSpeed = 4.0f;
    [SerializeField] float defaultSpeed = 10.5f;

    private Animator _anim;
    private SpriteRenderer _spr;
    private Rigidbody2D _rig;

    private const string ATTACK_ = "Attack";
    private const string HURT_ = "Hit";
    private const string DEAD_ = "Dead";
    private const string SLIDE = "isSliding";
    private const string RETURN = "Home";
    [SerializeField] string[] availableSpells; // make game object if I have to.
    [SerializeField] string[] availableAttacks;


    private bool isRunning;

    private bool actionStarted;


    public bool isMagicAttack;
    public bool isRanged; // archers only // can activate by critical hit
    public bool isCasting; // only activated by healing/buffing;




    [SerializeField] GameObject projectile;
    [SerializeField] Transform shootPosition;

    private float levelModifier = 0.02f;

    // public int Target;
    public float fadeSpeed = .5f;

    void Awake()
    {



        fighterData.health = fighterData.maxHealth;
        fighterData.mana = fighterData.maxMana;
        if (gameObject.CompareTag(TagManager.ENEMY_TAG))
        {

            SetEnemyStats();


        }
        else if (gameObject.CompareTag(TagManager.PLAYER_TAG))
        {
            SetPlayerStats();
        }

    }
    void Start()
    {
        _anim = GetComponent<Animator>();
        _spr = GetComponent<SpriteRenderer>();
        _rig = GetComponent<Rigidbody2D>();


        //  SetTarget(Target);


    }

    // Update is called once per frame
    void Update()
    {
        if (!fighterData.isPlayer && fighterData.isDead)
        {
            FadeEnemy();
        }
        
    }

    private void FadeEnemy()
    {
        _anim.SetTrigger(DEAD_);
       _spr.color = new(Mathf.MoveTowards(_spr.color.r, 1f, fadeSpeed * Time.deltaTime),
       Mathf.MoveTowards(_spr.color.g, 0f, fadeSpeed * Time.deltaTime), 
       Mathf.MoveTowards(_spr.color.b, 0f, fadeSpeed * Time.deltaTime),
       Mathf.MoveTowards(_spr.color.a, 0f, fadeSpeed * Time.deltaTime));

       if(_spr.color.a == 0f)
       {
            gameObject.SetActive(false);
       }
            
            
    }

    private void SetPlayerStats()
    {

        fighterData.fighterName = data.fighterName;
        fighterData.Level = data.LVL;

        fighterData.health = data.HP;
        fighterData.maxMana = data.maxMP;
        fighterData.mana = data.MP;
        fighterData.maxHealth = data.maxHP;

        fighterData.Level = data.LVL;

        fighterData.Attack = data.ATK;
        fighterData.Defense = data.DEF;
        fighterData.Intelligence = data.INT;
        fighterData.Resistance = data.RES;
        fighterData.Dexterity = data.SPD;
        fighterData.isDead = data.isDead;
        fighterData.isPlayer = data.isPlayer;
        

    }


    private void SetEnemyStats()
    {

        float levelMod = levelModifier * fighterData.Level;

        fighterData.fighterName = data.fighterName;
        fighterData.Level = data.LVL;


        fighterData.health = Mathf.CeilToInt((data.HP * levelMod) + data.HP);
        fighterData.maxHealth = Mathf.CeilToInt((data.maxHP * levelMod) + data.maxHP);
        fighterData.mana = Mathf.CeilToInt((data.MP * levelMod) + data.maxMP);
        fighterData.maxMana = Mathf.CeilToInt((data.maxMP * levelMod) + data.maxMP);
        fighterData.Attack = Mathf.CeilToInt((data.ATK * levelMod) + data.ATK);
        fighterData.Defense = Mathf.CeilToInt((data.DEF * levelMod) + data.DEF);
        fighterData.Intelligence = Mathf.CeilToInt((data.INT * levelMod) + data.INT);
        fighterData.Resistance = Mathf.CeilToInt((data.RES * levelMod) + data.RES);
        fighterData.Dexterity = Mathf.CeilToInt((data.SPD * levelMod) + data.SPD);

        fighterData.isDead = data.isDead;
        fighterData.isPlayer = data.isPlayer;

    }

    public virtual IEnumerator Physical()
    {

        isMagicAttack = false;
        if (actionStarted == true)
        {
            yield break;
        }

        actionStarted = true;




    }
    public IEnumerator RangedAttack()
    {


        if (actionStarted == true)
        {
            yield break;
        }

        actionStarted = true;




    }

    public IEnumerator Casting() // movement
    {

        isMagicAttack = true;
        if (actionStarted == true)
        {
            yield break;
        }

        actionStarted = true;




    }

    public void ShootProjectile() // NoMovement Button Push.
    {
        Instantiate(projectile, shootPosition.position, shootPosition.rotation);
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


    private IEnumerator MagicCasting()
    {

        if (actionStarted == true)
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

    public void Healing(int heal)
    {
        int healAmount = (int)(heal + (fighterData.maxHealth * .33f));
        fighterData.health = Mathf.Min(data.HP + healAmount, fighterData.maxHealth);
    }



    public void KnockBack()

    {
        // ifCritical
        // shake here
        // push direction

    }

    public void Defend()
    {

        fighterData.Defense += (int)(fighterData.Defense * .25f);
        fighterData.Resistance += (int)(fighterData.Resistance * .30f);
      
    }
    public void ResetStats()
    {
        fighterData.Defense = data.DEF;
        fighterData.Resistance = data.RES;
    }

    public void TakeDamage(int damage)
    {

        fighterData.health -= damage;
        //effect
        _anim.SetTrigger(HURT_);
        if (fighterData.health == 0)
        {
            _anim.SetTrigger(DEAD_);
            _spr.color = Color.grey;

            // _anim.speed = 0f;

            //gameObject.SetActive(false);
        }
    }

    public string[] AllAttacks()
    {
        return availableAttacks;
    }
    public string[] AllSpells()
    {
        return availableSpells;
    }

    private void DeadPlayer()
    {
        _anim.SetTrigger(DEAD_);
        _spr.color = Color.grey;

    }

    public void DeathToPlayer()
    {
        fighterData.isDead = true;
        DeadPlayer();
    }
    public void DeathToEnemy()
    {
        fighterData.isDead = true;
    }
    
    




    



}

[Serializable]
public class FighterStats
{
    public string fighterName;
    // public Sprite characterFace;
    public int maxHealth;
    public int health = 1;
    public int mana = 0;
    public int maxMana;

    [Header("Stats")]
    public int Attack;
    public int Defense;
    public int Intelligence;// intelligence
    public int Resistance;
    public int Dexterity; // speed

    public int Level = 1;


    public int attackPower;
    public int defensePower;

    public int magicPower;
    public int resistPower;
    public bool isDead;
    public bool isPlayer;



}