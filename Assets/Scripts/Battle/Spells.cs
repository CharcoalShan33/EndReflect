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

    private void Update()
    {
        //AudioManager.Instance.PlaySFXClip(0);
        if (targetPosition != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < .2f)
            {
                Destroy(this.gameObject);
            }


        }
        else
        {
            Destroy(gameObject);
        }
    
    }

    public void CastSpell(GameObject target)
    {
        targetPosition = target.transform.position;
        if (currentSpellType == SpellType.Attack)
        {
            //target.DealDamage(power);
            Debug.Log("Hit Target");
        }
        if (currentSpellType == SpellType.Healing)
        {
            Debug.Log("HealTarget");
            //target.HealHP(power);
        }
    }

}
