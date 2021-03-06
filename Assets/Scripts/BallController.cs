﻿using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public float moveSpeed;


	private Vector2 targetPos = new Vector2(0f, 0f);
	private Vector2 startPos;
	private float angleDelta = 60.0f;
	private float starDis = 7.0f;
	private ScoreKeeper sk;

	private void Start () {
		sk = FindObjectOfType<ScoreKeeper> ();
		float dir = (angleDelta * Random.Range (0, 6) + 30.0f) * Mathf.Deg2Rad;
		startPos = new Vector2 (Mathf.Cos (dir), Mathf.Sin (dir)).normalized * starDis;
		transform.position = startPos;
	}

	private void Update () {
		transform.position = Vector2.MoveTowards (transform.position, targetPos, moveSpeed * Time.deltaTime);
	}

	private void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == this.gameObject.tag) {
			sk.IncreaseScore (1);
		} else {
			sk.DecreaseLives ();
		}
		Destroy (this.gameObject);
	}
}
