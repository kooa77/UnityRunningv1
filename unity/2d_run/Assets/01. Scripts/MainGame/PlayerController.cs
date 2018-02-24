using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 유니티가 기본 제공 함수

    void Awake()
    {
        ChangeState(eState.IDLE);
    }

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        LayerMask layerMask = 1 << LayerMask.NameToLayer("Ground");
        RaycastHit2D distanceFromGround = Physics2D.Raycast(transform.position, Vector3.down, 2.0f, layerMask);
        if( null != distanceFromGround.transform )
        {
            _isGround = true;
            gameObject.GetComponent<Animator>().SetBool("isGround", _isGround);
        }
        else
        {
            _isGround = false;
            gameObject.GetComponent<Animator>().SetBool("isGround", _isGround);
        }

        if(eState.RUN == _state)
        {
            if( _velocity.x < _maxSpeed )
            {
                _velocity.x += _addSpeed;
            }
            else
            {
                _velocity.x = _maxSpeed;
            }
            gameObject.GetComponent<Animator>().SetFloat("Horizontal", _velocity.x);
        }
	}

    public enum eState
    {
        IDLE,
        RUN,
    }
    eState _state = eState.IDLE;
    //float _maxSpeed = 30.0f;
    //float _addSpeed = 0.05f;
    float _maxSpeed = 15.0f;
    float _addSpeed = 0.05f;

    public void ChangeState(eState state)
    {
        _state = state;
        switch (state)
        {
            case eState.IDLE:
                // 아이들 애니메이션 : 애니메이터에 isGround 패러미터를 true 만들어 주면된다.
                _velocity.x = 0.0f;
                _velocity.y = 0.0f;
                gameObject.GetComponent<Animator>().SetFloat("Horizontal", _velocity.x);
                break;
            case eState.RUN:
                // 달리기 애니메이션
                _velocity.x = 0.0f;
                _velocity.y = 0.0f;
                gameObject.GetComponent<Animator>().SetFloat("Horizontal", _velocity.x);
                break;
        }
    }
        

    // Move

    Vector2 _velocity = Vector2.zero;

    bool _isGround = false;
    bool _canDoubleJump = false;

    public Vector2 GetVelocity()
    {
        return _velocity;
    }

    void Jump()
    {
        if(_isGround)
        {
            _canDoubleJump = true;
            JumpAction();
        }
        else if(true == _canDoubleJump)
        {
            _canDoubleJump = false;
            JumpAction();
        }
    }

    void JumpAction()
    {
        //float jumpPower = 500.0f;
        //gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
        float jumpSpeed = 30.0f;
        Vector2 velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        velocity.y = jumpSpeed;
        gameObject.GetComponent<Rigidbody2D>().velocity = velocity;

        gameObject.GetComponent<Animator>().SetTrigger("Jump");
    }

    void ResetSpeed()
    {
        _velocity.x = 0.0f;
    }
}
