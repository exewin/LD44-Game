using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Actions : MonoBehaviour 
{

	public int hp = 100;

	public GameObject hpBar;
	public GameObject skeltal;

	public Animator animator;
	
	public GameObject[] flasks;
	public List<GameObject> flasksGpxs = new List<GameObject>();
	public bool[] flasksAllowed;
	public int[] flasksCost;
	//public LevelManager lm;
	
	bool thrower=false;
	float cooldown=0;
	
	public void FlasksGpxs()
	{
		for(int i =0;i<flasks.Length;i++)
		{
			if(flasksAllowed[i])
				flasksGpxs[i].SetActive(true);
			else
				flasksGpxs[i].SetActive(false);
		}
	}
	
	public void SetBar()
	{
		hpBar=GameObject.FindWithTag("HpBar");
	}

	void Update()
	{
		for(int i =0;i<flasks.Length;i++)
		if(Input.GetKeyDown((i+1)+"")&&!thrower&&flasksAllowed[i])
		{
			cooldown=.2f;
			SetThrow(true);
			GameObject flak = Instantiate(flasks[i],transform.position, transform.rotation);
			flak.GetComponent<Flask>().AddPower(transform.localScale.x);
			SetHp(hp-flasksCost[i]);
		}
		
		
		if(thrower)
		{
			cooldown-=Time.deltaTime*1;
			if(cooldown<0)
				SetThrow(false);
		}
		
	}
	
	
	void SetThrow(bool m)
	{
		thrower=m;
		animator.SetBool("throw", m);
	}
	
	public void SetHp(int h)
	{
		hp=h;
		hpBar.GetComponent<RectTransform>().sizeDelta = new Vector2(146*hp/100,11);
		
		if(hp<=0)
		{
			Die();
		}
	}
	
	void Die()
	{
		GameObject skel = Instantiate(skeltal,transform.position, transform.rotation);
		skel.GetComponent<Rigidbody2D>().AddTorque(40,ForceMode2D.Force);
		Destroy(gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D collision)
    {
		if(collision.gameObject.tag=="Fall")
		{
			SetHp(0);
		}
	}


}
