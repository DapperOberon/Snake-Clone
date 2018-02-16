using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {

	public static SpawnFood instance = null;

	public GameObject _foodPrefab;
	public Transform _foodParent;
	public int _startTimer;
	public float _respawnTime;

	public Transform _borderTop;
	public Transform _borderRight;
	public Transform _borderBottom;
	public Transform _borderLeft;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	private void Start () {
		InvokeRepeating("Spawn", _startTimer, _respawnTime);
	}

	private void Spawn()
	{
		Debug.Log("Generating food pos...");

		int x = (int)Random.Range(_borderLeft.position.x, _borderRight.position.x);
		int y = (int)Random.Range(_borderBottom.position.y, _borderTop.position.y);
		Vector3 pos = new Vector3(x, y, 0);

		Transform[] snakePos = Snake.instance.tail.ToArray();

		GameObject g = (GameObject)Instantiate(_foodPrefab, pos, Quaternion.identity);
		g.transform.parent = _foodParent;

		for(int i = 0; i < snakePos.Length; i++)
		{
			if (snakePos[i].position.Equals(pos))
			{
				Debug.LogWarning("Snake and food in same pos, destroying food...");
				Destroy(g);
			}
		}
	}

	public void ResetFood()
	{
		// Reset the score
		Game.instance.ResetScore();

		foreach (Transform foodGOs in _foodParent)
		{
			Destroy(foodGOs.gameObject);
		}
	}
}
