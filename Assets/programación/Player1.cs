using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject disparo;
    [SerializeField] GameObject disparo2;
    [SerializeField] float cadencia;
    [SerializeField] float cadencia2;

    float minX;
    float maxX;
    float minY;
    float maxY;
    float contador;
    float nextfire, nextfire_2;
    bool tipoDisparo = true;
    public bool gamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinasuperiorDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 esquinaInferiorIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinasuperiorDer.x - 0.6f;
        maxY = esquinasuperiorDer.y - 0.6f;
        minX = esquinaInferiorIzq.x + 0.6f;

        Vector2 puntoX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.6f));
        minY = puntoX.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePaused)
        {
            Mover();
            if (tipoDisparo)
                disparar();
            else
                DisparoSecundario();

            if (Input.GetKeyDown(KeyCode.C))
                tipoDisparo = tipoDisparo ? false : true;    
        }


    }
    void Mover()
    {
        float dirh = Input.GetAxis("Horizontal");
        float dirv = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(dirh * Time.deltaTime * speed, dirv * Time.deltaTime * speed);
        transform.Translate(movimiento);

        if (transform.position.x > maxX)
            transform.position = new Vector2(maxX, transform.position.y);

        if (transform.position.x < minX)
            transform.position = new Vector2(minX, transform.position.y);

        if (transform.position.y > maxY)
            transform.position = new Vector2(transform.position.x, maxY);

        if (transform.position.y < minY)
        {
            transform.position = new Vector2(transform.position.x, minY);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(disparo, transform);
        }


        // if (transform.position.x > maxX)
        //transform.position = new Vector2(maxX, transform.position.y);

        //if (transform.position.x < minX)
        //  transform.position = new Vector2(maxX, transform.position.x);

        //if (transform.position.y > maxY)
        //  transform.position = new Vector2(transform.position.y, maxY);
    }
    void disparar()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time >= nextfire)
        {
            Instantiate(disparo, transform.position, transform.rotation);
            nextfire = Time.time + cadencia;
        }
    }
    void DisparoSecundario()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextfire)
        {
            Instantiate(disparo2 , transform.position, transform.rotation);
            nextfire = Time.time + (cadencia/3);
        }
    }
    void cambio()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            
        }
    }
}
