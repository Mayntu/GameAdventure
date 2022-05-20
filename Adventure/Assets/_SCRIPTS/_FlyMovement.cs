using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _FlyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool angry = false;
    public Transform startingPoint;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        if(angry == true)
        {
            Angry();
        }
        else
        {
            GoBack();
        }
        Flip();     
        
    }
    private void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    private void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }
    private void Flip()
    {
        if(transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
