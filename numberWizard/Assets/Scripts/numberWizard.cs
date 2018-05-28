using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numberWizard : MonoBehaviour {

	int max;
	int min;
	int guess;

	// Use this for initialization
	void Start () {

		startGame();

	}

	void startGame () {
		
		max = 1000;
		min = 1;
		guess = 500;

		print("Welcome to Number Wizard!");
		print("Pick a secret number!");


		print("The highest number you can pick is " + max);
		print("The lowest number you can pick is " + min);

		print("Is the number higher or lower than " + guess + "?");
		print("If higher, press up; if lower, press down; if equal, press return.");

		max += 1;

	}
	
	void nextGuess () {

		guess = (max + min) / 2;
		print("Is the number higher or lower than " + guess + "?");
		print("If higher, press up; if lower, press down; if equal, press return.");

	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown("up")) {
			min = guess;
			nextGuess();
		} else if (Input.GetKeyDown("down")) {
			max = guess;
			nextGuess();
		} else if (Input.GetKeyDown("return")) {
			print("I won.");
			print("=======================");
			startGame();
		}

	}
}