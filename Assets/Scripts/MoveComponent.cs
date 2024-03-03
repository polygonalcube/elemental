using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    // 
    
    //Requires a Character Controller to work
    public CharacterController charCon;
	
	public float accel;
    public float decel;
	public Vector3 maxSpeed;
	public bool isNormalized;

    public bool affectedByGravity;
    public float gravity;

	public float xSpeed;
    public float ySpeed;
    public float zSpeed;
	public float angularSpeed;

    public float Accelerate(float speedVar, float axis)
    {
        speedVar += accel * axis * Time.deltaTime;
        return speedVar;
    }

    public float Decelerate(float speedVar)
    {
        speedVar += decel * GameManager.gm.Sign(-speedVar) * Time.deltaTime;
	    if (Mathf.Abs(speedVar) <= decel)
		{
			speedVar = 0f;
		}
		return speedVar;
    }

    public float Cap(float speedVar, float speedCap, float magni)
    {
        if(Mathf.Abs(speedVar) > (speedCap * Mathf.Abs(magni)))
        {
            return speedCap * magni;
        }
        return speedVar;
    }

    public Vector3 Move(Vector3 moveDir)
    {
		//acceleration and deceleration
        if (Mathf.Abs(moveDir.x) != 0f)
        {
            xSpeed = Accelerate(xSpeed, moveDir.x);
        }
		else
		{
			xSpeed = Decelerate(xSpeed);
		}

        if (affectedByGravity)
        {
            ySpeed += gravity * Time.deltaTime;
        }
        else
        {
            if (Mathf.Abs(moveDir.y) != 0f)
            {
                ySpeed = Accelerate(ySpeed, moveDir.y);
            }
            else
            {
                ySpeed = Decelerate(ySpeed);
            }
        }
		
		if (Mathf.Abs(moveDir.z) != 0f)
        {
            zSpeed = Accelerate(zSpeed, moveDir.z);
        }
		else
		{
			zSpeed = Decelerate(zSpeed);
		}

		//prevents the object from going too fast
		xSpeed = Cap(xSpeed, maxSpeed.x, moveDir.x);
        if (affectedByGravity)
        {
            ySpeed = Cap(ySpeed, maxSpeed.y, -1);
        }
        else
        {
            ySpeed = Cap(ySpeed, maxSpeed.y, moveDir.y);
        }
		zSpeed = Cap(zSpeed, maxSpeed.z, moveDir.z);

		//final movement; if isNormalized is true, diagonal movement will not be faster
		if (isNormalized)
		{
			float highestSpeed = xSpeed;
			if (Mathf.Abs(ySpeed) > Mathf.Abs(highestSpeed))
			{
				highestSpeed = ySpeed;
			}
			if (Mathf.Abs(zSpeed) > Mathf.Abs(highestSpeed))
			{
				highestSpeed = zSpeed;
			}
			//transform.position += new Vector3(xSpeed, ySpeed, zSpeed).normalized * Mathf.Abs(highestSpeed) * Time.deltaTime;
			charCon.Move(new Vector3(xSpeed, ySpeed, zSpeed).normalized * Mathf.Abs(highestSpeed) * Time.deltaTime);
            return new Vector3(xSpeed, ySpeed, zSpeed).normalized * Mathf.Abs(highestSpeed) * Time.deltaTime;
		}
		else
		{
			//transform.position += new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime;
			charCon.Move(new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime);
            return new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime;
		}
    }

    public Vector3 MoveAngularly(Vector3 moveDir)
    {
		/*
        if (Mathf.Abs(moveDir.magnitude) != 0f)
        {
            angularSpeed = Accelerate(angularSpeed, moveDir.magnitude);
        }
		else
		{
			angularSpeed = Decelerate(angularSpeed);
		}
		*/
		//prevents the object from going too fast
		//angularSpeed = Cap(angularSpeed);

		//transform.position += moveDir/*TransformDirection(moveDir)*/ * angularSpeed * Time.deltaTime;
		charCon.Move(moveDir * angularSpeed * Time.deltaTime);
        return moveDir * angularSpeed * Time.deltaTime;
    }
}
