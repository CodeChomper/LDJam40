using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    Transform trans;

    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    float targetPosThreshold = 0.05f;

    [SerializeField]
    float zRot;

    [SerializeField]
    float speed = 1.75f;

    [SerializeField]
    AudioSource botWalk;

    [SerializeField]
    AudioSource botTurn;

    public bool reachedGoal = false;

    Vector3 targetPos;

    public string state = "";
    
	
    // Use this for initialization
	void Start () {
        
        targetPos = trans.position;
        zRot = trans.rotation.z;
        
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void MoveForward()
    {
        targetPos = trans.position + trans.forward;
        botWalk.Play();
    }

    public void TurnRight()
    {
        zRot += 90;
        botTurn.Play();
    }

    public void TurnLeft()
    {
        zRot -= 90;
        botTurn.Play();
    }

    private void FixedUpdate()
    {
        if (!NearTargetPos())
        {
            rb.MovePosition(trans.position + trans.forward * Time.fixedDeltaTime * speed);
        }
        else
        {
            targetPos.y = trans.position.y;
            rb.MovePosition(targetPos);
        }

        if (!NearRotation())
        {
            rb.MoveRotation(Quaternion.Euler(0, zRot - rb.rotation.y, 0));
        }
    }


    private bool NearRotation()
    {
        return false;
    }

    private bool NearTargetPos()
    {
        if(Mathf.Abs(trans.position.x - targetPos.x) < targetPosThreshold 
            && Mathf.Abs(trans.position.z - targetPos.z) < targetPosThreshold)
        {
            return true;
        }
        return false;
    }

}
