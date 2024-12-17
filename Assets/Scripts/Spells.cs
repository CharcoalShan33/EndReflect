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

    private void Update()
    {
        //AudioManager.Instance.PlaySFXClip(0);
       /* if (targetPosition != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 17f);
            if (Vector3.Distance(transform.position, targetPosition) < .5f)
            {
                Destroy(this.gameObject);
            }


        }
        else
        {
            Destroy(gameObject);
        }
    */
    }

    public void CastSpell(GameObject target)
    {
        targetPosition = target.transform.position;
        if (currentSpellType == SpellType.Attack)
        {
            //target.DealDamage(power);
        }
        if (currentSpellType == SpellType.Healing)
        {
            //target.HealHP(power);
        }
    }

}
