using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
  public float speed;

  private int count;

  public Text text;
  public Text final;


  void Start()
  {
	  count = 0;
	  updateCounter();
	  final.text = "";
  }
  void FixedUpdate()
  {
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    Vector3 direction = new Vector3(horizontal, 0, vertical);
    
    GetComponent<Rigidbody>().AddForce(direction * speed);
  }
	/// <summary>
	/// OnTriggerEnter is callerd when the Colider other enters the trigger.
	/// <summary>
	/// <param name="other"> The other Colider involved in this collision. </param>
	void OnTriggerEnter(Collider other){
		if(other.tag == "Pickup"){
			Destroy(other.gameObject);
			count++;

			updateCounter();

		}
 	}

	void updateCounter()
	{
		text.text = "Puntos: " + count;


		GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickup");
		int numPickups = pickups.Length;

		if (numPickups == 1)
		{
			final.text = "Has Ganado!";
		}
	}
}
