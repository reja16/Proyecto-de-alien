using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movingRight;
    [SerializeField] GameManager gm;
    float minX, MaxX;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        MaxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingRight)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
        else
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));

        if(transform.position.x > MaxX - 0.3f)
        {
            movingRight = false;
        }
        else if(transform.position.x < minX + 0.3f)
        {
            movingRight = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colisionando = collision.gameObject;
        if (colisionando.tag == "disparo")
        {
            gm.ReducirNumeroEnemigos();
            Destroy(this.gameObject);
        }

    }
}
