using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PatrolOfEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int positionOfPatrol;
    public Transform point;
    private bool movingRight;
    //private bool isRight;
    Transform player;
    [SerializeField] private float stoppingDistance;
    private bool chill = false;
    private bool angry = false;
    private bool goBack = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance) ;
        {
            angry = true;
            chill = false;
            goBack = false;
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance) ;
        {
            goBack = true;
            angry = false;
        }


        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goBack == true)
        {
            GoBack();
        }
    }
    //void FixedUpdate()
    //{
    //    IsRight();
    //}
    void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            movingRight = false;
            //isRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            movingRight = true;
            //isRight = true;
        }
        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
    //public void IsRight()
    //{
    //    if (isRight == true)
    //    {
    //        GetComponent<SpriteRenderer>().flipX = false;
    //    }
    //    else
    //    {
    //        GetComponent<SpriteRenderer>().flipX = true;
    //    }
    //}
}