using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;

    private bool _facingRight;
    private bool _onGround;
    public bool _jump = true;

    Animator anima;
    public float velocidade = 4f;
    public float forcaPulo = 300f;
    public bool inicioPulo = false;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump") && _onGround)
        {
            _jump = true;
        }
        Animacaoes();
    }

    private void FixedUpdate()
    {
        
        float h = Input.GetAxis("Horizontal");
        if (h!=0)
        {
            anima.SetBool("Move", true);
        }
        else
        {
            anima.SetBool("Move", false);
        }
        if (h < 0 && !_facingRight)
        {
            Flip();
        }
        else if (h > 0 && _facingRight)
        {
            Flip();
        }

        if (_jump)
        {
            _jump = false;
            _rb.AddForce(Vector2.up * forcaPulo);
        }
        _rb.velocity = new Vector2(h * velocidade, _rb.velocity.y);

    }
    void Flip()
    {
        _facingRight = !_facingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

    }
    void Animacaoes()
    {
        //Vector2 v2Velocity = _rb.velocity;
        //Debug.Log(v2Velocity);
        float Velocity_Y = _rb.velocity.y;
        if (Velocity_Y>0)
        {
            anima.SetInteger("forcaSalto", 1);
        }
        else if (Velocity_Y<0)
        {
            anima.SetInteger("forcaSalto", -1);
        }
        else
        {
            anima.SetInteger("forcaSalto", 0);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="chao")
        {
            _onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            _onGround = false;
        }
    }

}
