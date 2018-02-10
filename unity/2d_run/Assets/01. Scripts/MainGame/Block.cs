using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Vector2 _velocity = Vector2.zero;

	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = _velocity;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 playerVelociy = GameManager.Instance.GetPlayer().GetVelocity();
        if(playerVelociy != _velocity)
        {
            _velocity = playerVelociy;
            gameObject.GetComponent<Rigidbody2D>().velocity = -_velocity;
        }
	}
}
