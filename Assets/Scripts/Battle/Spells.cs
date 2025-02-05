using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public string spellName;
    public int power;
    public int mpCost;

    public bool isFlipped;

    public enum SpellType { Attack, Healing, Buff, Debuff }
    public SpellType currentSpellType;

    private Vector3 targetPosition;
    [SerializeField] private float speed;

    private BattleMachine BSM;


    private  void Start()
    {
    // BSM = GameObject.Find("Batlle_System").GetComponent<BattleMachine>();
    }
    private void Update()
    {
        //AudioManager.Instance.PlaySFXClip(0);
        if (targetPosition != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < .25f)
            {
                Destroy(gameObject, 1.5f);
            }
        }
        else
        {
            Destroy(gameObject);
        }

    
    }

    public void CastSpell(Fighters target)
    {
        targetPosition = target.transform.position;
        if (currentSpellType == SpellType.Attack)
        {
          target.TakeDamage(power);
            Debug.Log("Hit Target");
        }
        if (currentSpellType == SpellType.Healing)
        {
            target.Healing(power);
            Debug.Log("HealTarget");
            //target.HealHP(power);
        }
    }

   

}
