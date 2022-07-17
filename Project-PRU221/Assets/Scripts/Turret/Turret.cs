using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    public float Range;

    Timer timer;
    bool Detected = false;
    private bool isInAttackRange;

    [SerializeField]
    GameObject bulletPrefab;


    Collider2D[] inCombat;

    [SerializeField]
    float attackRadius;

    [SerializeField]
    float checkRadius;

    Vector2 Direction;

    [SerializeField]
    LayerMask whatIsEnemy;
    GameObject target;

    Vector3 dir;

    public GameObject AlarmLight;
    public GameObject Gun;

    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 2;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        inCombat = Physics2D.OverlapCircleAll(
               transform.position,
               attackRadius,
                 LayerMask.GetMask("P2")
           );
        /*Transform Target = target.gameObject.transform ;
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;*/
    }
    private void FixedUpdate()
    {

        if (inCombat != null)
        {
            if (timer.Finished)
            {
                int l = inCombat.Length;
                if (l > 0)
                {
                    dir = (Vector2)inCombat[l - 1].transform.position - (Vector2)transform.position;
                    var bullet = Instantiate(
                        bulletPrefab.transform,
                        transform.position,
                        Quaternion.Euler(dir)
                    );
                    bullet.GetComponent<Bullet>().Direction = dir;
                    Debug.Log(dir);
                }
                timer.Duration = 2;
                timer.Run();
            }

            AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
