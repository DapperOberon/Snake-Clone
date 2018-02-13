using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {

	public GameObject _foodPrefab;
	public Transform _foodParent;
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

	private void Spawn()
	{
		int x = (int)Random.Range(_borderLeft.position.x, _borderRight.position.x);
		int y = (int)Random.Range(_borderBottom.position.y, _borderTop.position.y);

		GameObject g = (GameObject)Instantiate(_foodPrefab, new Vector2(x, y), Quaternion.identity);
		g.transform.parent = _foodParent;
	}
}
