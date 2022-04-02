using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    Animator anima;
    SpriteRenderer sprite;

    private bool _facingRight;
    private bool _onGround;
    public bool _jump = false;


    private float velocidade = 4f;
    private float forcaPulo = 300f;
    public bool inicioPulo = false;
    public bool onMove = true;
    public int life = 5;
    public bool dead = false;
    private bool imune = false;

    // Start is called before the first frame update
    void Start()
    {
        life = 5;
        anima = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();


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

    void tatakae()
    {
        //if (Input.GetButtonDown(KeyCode.X))
        //{

        //}
    }

    void morte()
    {
        sprite.color = new Color(255, 255, 255, 110);

    }
    private void FixedUpdate()
    {
        if (_jump)
        {
            _jump = false;
            _rb.AddForce(Vector2.up * forcaPulo);
        }
        movePlayer();

    }
    void movePlayer()
    {
        if (onMove)
        {
            float h = Input.GetAxis("Horizontal");
            if (h != 0)
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
            _rb.velocity = new Vector2(h * velocidade, _rb.velocity.y);
        }
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
        float Velocity_Y = _rb.velocity.y;
        if (Velocity_Y>0 || _jump)
        {
            anima.SetInteger("forcaSalto", 1);
        }
        else if (Velocity_Y<0)
        {
            anima.SetInteger("forcaSalto", -1);
        }
        else
        {   
            if (_onGround==false)
            {
                onMove = false;
            }
            anima.SetInteger("forcaSalto", 0);
        }
    }
    void eventoFimQuedaPulo()
    {
        onMove = true;
        _onGround = true;
    }

    public void danoPlayer()
    {
        if (imune==false)
        {
            life -= 1;
            if (life <= 0)
            {
                dead = true;
                morte();
                sprite.color = new Color(0, 0, 0, 110);
            }
            else 
            {
                imune = true;
                sprite.color = new Color(255, 0, 0, 255);

                StartCoroutine(tirarImunidadeDoDano());
            }
        }

    }
    IEnumerator tirarImunidadeDoDano()
    {
        yield return new WaitForSeconds(1f);
        imune = false;
        sprite.color = new Color(255, 255, 255, 255);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="chao")
        {
            //_onGround = true;
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
