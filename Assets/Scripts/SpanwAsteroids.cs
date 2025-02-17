using UnityEngine;
using System.Collections;

public class SpanwAsteroids : MonoBehaviour {

	public GameObject asteroid;
	public Vector3 spawnValues;
	public int asteroidCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Vector3 scaleAsteroidRangeMax, scaleAsteroidRangeMin; 
	public float waitToIncreaseDifficulty;
	private float rate;
	// Use this for initialization
	void Start () {
		rate = waitToIncreaseDifficulty;
		StartCoroutine( createAsteroids() );
	}
	
	// Update is called once per frame
	void Update () {
		increaseDifficulty();
	}

	IEnumerator createAsteroids(){

		yield return new WaitForSeconds(startWait);
		while(true){
			for(int i = 0; i < asteroidCount; i++ ){
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 6.0f, 7f);
				Quaternion spawnRotation = Quaternion.identity;
				GameObject asteroidInstance = Instantiate(asteroid, spawnPosition, spawnRotation) as GameObject;
				Vector3 randomSize = new Vector3 (
					Random.Range (scaleAsteroidRangeMin.x, scaleAsteroidRangeMax.x),
					Random.Range (scaleAsteroidRangeMin.y, scaleAsteroidRangeMax.y),
					Random.Range (scaleAsteroidRangeMin.z, scaleAsteroidRangeMax.z));
				asteroidInstance.transform.localScale = randomSize;
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}

	void increaseDifficulty(){
		if(Time.time > waitToIncreaseDifficulty){
			asteroidCount += 1 ;
			waveWait -= 0.01f ;
			spawnWait -= 0.01f ;
			waitToIncreaseDifficulty = Time.time + rate;
		}
	}


}
