using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public GameObject projectil;
	public Transform bulletContainer;
	public float fireRate;
	public float nextFire;
	public int lifes;
	public int score;

	public float xMin, xMax, zMin, zMax;
	public float speed;
	private Rigidbody rb;
	private float horizontalInput, verticalInput;
	private const float HEIGHT_OFFSET = 5f;
	private Vector3 speedVector, movementVector;
	private Quaternion rotationQuat;
	private Text scoreTxt, lifesTxt; 


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		scoreTxt = GameObject.Find("Score").GetComponent<Text>();
		lifesTxt = GameObject.Find("Lifes").GetComponent<Text>();
	}

	void Update () {

		shootHandler();
		movementController();
		guiUpDate();


			

	}

	private void movementController(){
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");
		speedVector = new Vector3(horizontalInput, HEIGHT_OFFSET, verticalInput);
		rb.velocity = speedVector * speed;
		movementVector = new Vector3(Mathf.Clamp(rb.position.x, xMin, xMax),HEIGHT_OFFSET,Mathf.Clamp(rb.position.z, zMin, zMax));
		rb.position = movementVector;
		rb.rotation = Quaternion.Euler(0.0f , 0.0f, rb.velocity.x * -3);
	}

	private void shootHandler(){
		if(Input.GetButtonDown("Fire1") && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Instantiate(projectil, bulletContainer.position, bulletContainer.rotation);
			GetComponent<AudioSource>().Play();
		}
	} 

	private void guiUpDate(){
		scoreTxt.text = "Score:" + score.ToString();
		lifesTxt.text = "Lifes:" + lifes.ToString(); 
	}





















}
