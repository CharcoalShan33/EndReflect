using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    Rigidbody2D rig;

    [SerializeField] float force;
    [SerializeField] float deathTime = 2f;

    [SerializeField] Transform target;

    Vector2 DistanceToTarget;



    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>();
        DistanceToTarget = transform.position - target.position;
        AssignTarget(target.gameObject);
    }

    // Update is called once per frame

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < .2f)
        {
            Destroy(this.gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        if (target.position != Vector3.zero)
        {
            rig.velocity = DistanceToTarget * force * Time.fixedDeltaTime;
        }
    }

    public void AssignTarget(GameObject fighter)
    {

        target = fighter.transform;


    }
}
