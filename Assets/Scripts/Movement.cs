using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{
	
	public Controller controller;
	public Animator animator;
	
	public LevelManager lm;
	

	
	public float speed=5f;
	
	float h;
	bool jump;
	
	void Update()
	{
		h=Input.GetAxisRaw("Horizontal") * speed;
		
		animator.SetFloat("speed", Mathf.Abs(h));

		
		if(Input.GetButtonDown("Jump"))
		{
			jump=true;
		}
		
	}
	void FixedUpdate()
	{
		
		
		controller.Act(h,jump);
		jump = false;
		
	}
	
	
	void OnTriggerEnter2D(Collider2D col)
    {
		if(col.gameObject.tag=="Exit")
		{
			lm.NextLevel();
		}
    }


}
