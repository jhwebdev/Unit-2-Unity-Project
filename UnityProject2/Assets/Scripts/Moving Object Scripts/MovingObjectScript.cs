using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectScript : MonoBehaviour
{
	public GameObject startPoint;
	public GameObject endPoint;
    public bool singleUse;
	public float travelTime = 10;
    private GameObject platform;
	private Rigidbody rb;
	private Vector3 currentPos;
    public bool isMoving;

	private void Start()
	{
        platform = transform.GetChild(0).gameObject;
		rb = platform.GetComponent<Rigidbody>();
        startPoint.transform.position = platform.transform.position;
	}

    public void toggleMove(){
        isMoving = !isMoving;
    }
    public void singleUseMove(){//Moves from start to end once, one time use
        
    }
	void Update()
	{
        movePlatform();
        if(singleUse && (int)time >= travelTime/2){isMoving = false;}
	}

    float time;
    private void movePlatform(){
        if(isMoving){
            currentPos = Vector3.Lerp(startPoint.transform.position, endPoint.transform.position,
                        Mathf.Cos(time / travelTime * Mathf.PI * 2) * -.5f + .5f);
            rb.MovePosition(currentPos);
            time += Time.deltaTime;
        }
    }
}