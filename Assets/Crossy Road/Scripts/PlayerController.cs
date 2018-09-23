using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController:MonoBehaviour
{
    public GameObject chick = null;
    public float colliderDistCheck = 1;
    public bool isDead = false;
    public bool isIdle = true;
    public bool isJumping = false;
    public bool isMoving = false;
    public bool jumpStart = false;
    public float moveDistance = 1.0f;
    public float moveTime = 0.4f;
    public ParticleSystem particle = null;
    private bool isVisible = false;
    private Renderer renderer = null;

    public void GotHit()
    {
    }
    void CanIdle()
    {
        if (isIdle)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.RightArrow))
            {
            }
        }
    }
    void CanMove()
    {
        if (isMoving)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Moving(new Vector3(transform.position.x,transform.position.y,transform.position.z+moveDistance));
                SetMoveForwardState();
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                Moving(new Vector3(transform.position.x,transform.position.y,transform.position.z-moveDistance));
                SetMoveForwardState();
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Moving(new Vector3(transform.position.x-moveDistance,transform.position.y,transform.position.z));
                SetMoveForwardState();
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                Moving(new Vector3(transform.position.x+moveDistance,transform.position.y,transform.position.z));
                SetMoveForwardState();
            }
        }
    }
    void CheckIfCanMove()
    {
        // raycast - find if there's any collider box in front of player.

        SetMove();
    }
    void IsVisible()
    {
    }
    void MoveComplete()
    {
        isJumping=false;
        isIdle=true;
    }
    void Moving(Vector3 pos)
    {
        isIdle=false;
        isMoving=false;
        isJumping=true;
        jumpStart=false;
        LeanTween.move(this.gameObject,pos,moveTime).setOnComplete(MoveComplete);
    }
    void SetMove()
    {
        Debug.Log("Hit nothing with the recast");
        isIdle=false;
        isMoving=true;
        jumpStart=true;
    }
    void SetMoveForwardState()
    {
    }
    private void Start()
    {
    }
    private void Update()
    {
        CanMove();
        CanIdle();
    }
}