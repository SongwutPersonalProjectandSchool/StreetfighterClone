using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {
	public int roundTime = 99;
	private float lastTimeUpdate = 0;
	private bool battleStarted;
	private bool battleEnded;

	public Fighter player1;
	public Fighter player2;
	public BannerController banner;
	public AudioSource musicPlayer;
	public AudioClip backgroundMusic;
    	public AudioClip p1win;
    	public AudioClip p2win;
    
    void Start () {
		banner.showRoundFight ();
	}
	//check who win when time out
	private void expireTime(){
		if (player1.healthPercent > player2.healthPercent) {
			player2.health = 0;
            SoundManager.playsound(p1win, musicPlayer);
        } else {
			player1.health = 0;
            SoundManager.playsound(p2win, musicPlayer);
        }
	}

	void Update () {
		//start game and wait banner animating
		if (!battleStarted && !banner.isAnimating) {
			
			battleStarted = true;
			player1.enable = true;
			player2.enable = true;

			SoundManager.playsound(backgroundMusic, musicPlayer);
		}
			//start game
		if (battleStarted && !battleEnded) {
			if (roundTime > 0 && Time.time - lastTimeUpdate > 1) {
				roundTime--;
				lastTimeUpdate = Time.time;
				if (roundTime == 0){
					expireTime();
				}
			}

			if (player1.healthPercent <= 0) {
				battleEnded = true;
                SoundManager.playsound(p2win, musicPlayer);
            } else if (player2.healthPercent <= 0) {
				battleEnded = true;
                SoundManager.playsound(p1win, musicPlayer);
            }
		}
	}
}
