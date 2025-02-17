using UnityEngine;
using System.Collections;

public class BounderController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider obj){
		if(obj.tag == "Player"){
			return;
		}
		Destroy(obj.gameObject);
	}

}
