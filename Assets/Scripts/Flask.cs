using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Flask : MonoBehaviour
{
	
	public Rigidbody2D rb;
	public float speed;
	public float thrust;
	
	public int effect;
	
	public string reqTag = "";
	
	public AudioClip broke;
	
	
	public GameObject toSpawn;

	public void AddPower(float minus)
	{
		rb.AddForce(transform.right * thrust * minus);
		rb.AddForce(transform.up * thrust);
		rb.AddTorque(speed*minus, ForceMode2D.Force);
	}

	
	void OnCollisionEnter2D(Collision2D collision)
    {
		if(collision.gameObject.tag!="Blocks")
			if(reqTag=="" || reqTag==collision.gameObject.tag)
			{
				if(effect==1)
				{
					Instantiate(toSpawn,transform.position, Quaternion.identity);
				}
				if(effect==2)
				{
					Tilemap tilemap = collision.gameObject.GetComponent<Tilemap>();
					Vector3 hitPosition = Vector3.zero;
					if (tilemap != null)
					{
						foreach (ContactPoint2D hit in collision.contacts)
						{
							hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
							hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
							tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
						}
					}
				}
			}
		AudioSource.PlayClipAtPoint(broke,transform.position);
		Destroy(gameObject);
	}
	
	
	
}
