using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb2d;
    float speed = 75;

    Timer timer;

    public Vector2 Direction;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 15;
        timer.Run();

        rb2d.AddForce(Direction * speed);
    }

    private void FixedUpdate()
    {
        if (timer.Finished)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7 && collision.gameObject.layer != 6)
        {
            collision.gameObject.GetComponent<Soldier>().UpdateHealth(15);
            Destroy(gameObject);

        }


    }

}
