using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Transform target;

    public float velocidade = 1f;
    int life;
    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        _rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //movimento();
    }
    void movimento()
    {
        _rb.velocity = new Vector2(-0.5f * velocidade, _rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        /*if (collision.CompareTag("Player") && _origem == "Inimigo")
        {
            collision.gameObject.GetComponent<Player>().DamagePlayer();
            Destroy(this.gameObject);
        }
        */
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().danoPlayer();

            //_onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //collision.transform
            target = collision.GetComponent<Transform>();
            //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

            
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), velocidade * Time.deltaTime);
            //transform.position = Vector2.MoveTowards(transform.position, target.position, velocidade * Time.deltaTime);


        }
    }
}
