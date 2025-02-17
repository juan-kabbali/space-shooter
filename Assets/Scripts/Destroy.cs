using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public GameObject blast;
	public Player playerScriptReference;
	// Use this for initialization
	void Start () {
		playerScriptReference = GameObject.Find("Nave").GetComponent<Player>();


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider obj){


		switch (obj.tag) {
			case "Projectil":
				playerScriptReference.score ++;
				Instantiate(blast, transform.position, transform.rotation);
				detachGameObjFromMainTree(obj);
				break;
			case "Player":
				if(playerScriptReference.lifes > 0){
					playerScriptReference.lifes --;
					Instantiate(blast, transform.position, transform.rotation);
					detachGameObjFromMainTree(null);
				}else{
					Instantiate(blast, transform.position, transform.rotation);
					detachGameObjFromMainTree(obj);
					}
				break;
			case "Asteroid":
				break;
		} 


	}

	void detachGameObjFromMainTree(Collider other){
		if(other != null){
			Destroy(other.gameObject);
			Debug.Log("Deberia dañar la nave");
		}
		Destroy(gameObject);
	}















}
