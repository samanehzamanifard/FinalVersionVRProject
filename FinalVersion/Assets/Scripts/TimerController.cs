using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
	float currentTime = 0;
	float startingTime = 300;
	public Text text_box;
    // Start is called before the first frame update
    void Start(){
        currentTime = startingTime;
    }

	// Update is called once per frame
	void Update () {
		currentTime -= 1 * Time.deltaTime;
		float minutes = currentTime / 60;
		float seconds = currentTime % 60;
		text_box.text = string.Format("{0}:{1:D2}", (int)minutes, (int)seconds);
		string end = "Game Over!                             ";
		
		if(currentTime <= 0){
			currentTime = 0;
			text_box.text = end;
			Application.Quit();
		}
	}
}
