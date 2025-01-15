using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : Fighters

{
    private int attackInt;



    // Start is called before the first frame update
    void Start()
    {
        attackInt = Random.Range(1, 5);

    }


    public void Act()
    {

        switch (attackInt)
        {


            case 1:
                // attacktype
                if (attackType == AttackType.Ranged)
                {
                    Debug.Log("Hit");
                }
                if (attackType == AttackType.Melee)
                {
                    Debug.Log("Slash");
                }
                if (attackType == AttackType.Casting)
                {
                    Debug.Log("Boom");
                }

                break;

            case 2:
                if (!isMagicAttack)

                {
                    ShootProjectile();
                }
                else
                {
                Debug.Log("Magic Bullet");
                }
                // Cast magic
                break;

            case 3:
                //defend
                break;





        }


    }
}
