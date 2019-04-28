using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour 
{
	
	public float m_JumpForce = 20f;							
	public float m_MovementSmoothing = .05f;	
	public Transform m_GroundCheck;							
	

	const float k_GroundedRadius = .05f; 
	
	bool ground;
	Rigidbody2D m_Rigidbody2D;
	
	bool right = true;
	
	Vector3 m_Velocity = Vector3.zero;
	
	
	public AudioSource audio;
	public AudioClip[] sounds; 

	float t=0;

	void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	private void FixedUpdate()
	{
		bool wasGrounded = ground;
		ground = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				ground = true;
			}
		}
	}
	
	
	public void Act(float h, bool jump)
	{
		Vector3 targetVelocity = new Vector2(h * 10f, m_Rigidbody2D.velocity.y);
		m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
		
		if(jump&&ground)
		{
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			
			audio.PlayOneShot(sounds[1],1f);
		}
		
		
			if (h > 0 && !right)
			{
				Flip();
			}
			else if (h < 0 && right)
			{
				Flip();
			}
		
		t-=Time.deltaTime*1;
		if(ground&&h!=0&&t<0)
		{
			t=0.12f;
			audio.PlayOneShot(sounds[0],.5f);
		}
		
		
		
		
	}
	
	void Flip()
	{

		right = !right;


		Vector3 s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
	}

}
