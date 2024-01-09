using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    public void Update()
    {
        Move();
    }
    public void Move()
    {
        
        
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        
       
    }

    public void DestroySelf(float delay)
    {
        Destroy(this,delay);
    }
}
