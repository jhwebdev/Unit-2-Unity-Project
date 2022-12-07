using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectScript : MonoBehaviour
{
	public GameObject startPoint;
	public GameObject endPoint;
    public bool singleUse;
	public float travelTime = 10;
    public bool isMoving;//can be set to true at the start to have an object move from the start
    public bool isReverse;//start from endpoint then go to start
    private GameObject platform;
	private Rigidbody rb;
	private Vector3 currentPos;
    

	private void Start()
	{
        platform = transform.GetChild(0).gameObject;
		rb = platform.GetComponent<Rigidbody>();
        startPoint.transform.position = platform.transform.position;
	}

    public void toggleMove(){
        isMoving = !isMoving;
    }

	void Update()
	{
        movePlatform();
        if(singleUse && (int)time >= travelTime/2){isMoving = false;}
	}

    float time;
    private void movePlatform(){
        if(isMoving){
            float speed;
            if(!isReverse){
                speed = Mathf.Cos(time / travelTime * Mathf.PI * 2) * -.5f + .5f;
            }
            else{
                speed = -Mathf.Cos(time / travelTime * Mathf.PI * 2) * -.5f + .5f;
            }
            currentPos = Vector3.Lerp(startPoint.transform.position, endPoint.transform.position,
                        speed);
            rb.MovePosition(currentPos);
            time += Time.deltaTime;
        }
    }
}