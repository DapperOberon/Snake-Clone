using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {

	public GameObject _foodPrefab;
	public int _startTimer;
	public int _respawnTime;

	public Transform _borderTop;
	public Transform _borderRight;
	public Transform _borderBottom;
	public Transform _borderLeft;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", _startTimer, _respawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Spawn()
	{
		int x = (int)Random.Range(_borderLeft.position.x, _borderRight.position.x);
		int y = (int)Random.Range(_borderBottom.position.y, _borderTop.position.y);

		Instantiate(_foodPrefab, new Vector2(x, y), Quaternion.identity);
	}
}
