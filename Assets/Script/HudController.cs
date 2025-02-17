﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudController : MonoBehaviour {

	public Fighter player1;
	public Fighter player2;

	public Text player1Tag;
	public Text player2Tag;

	public Scrollbar leftBar;
	public Scrollbar rightBar;

	public Text timerText;

	public BattleController battle;

	void Start () {
		player1Tag.text = player1.fighterName;
		player2Tag.text = player2.fighterName;
	}
	
	void Update () {
		timerText.text = battle.roundTime.ToString();
		if (leftBar.size > player1.healthPercent) {
			leftBar.size-= 0.01f;
		}
		if (rightBar.size > player2.healthPercent) {
			rightBar.size-= 0.01f;
		}
	}
}
