using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiping : MonoBehaviour {

	public static string mydirection;
	public static Vector2 firstPressPos;
	public static Vector2 secondPressPos;
	public static Vector2 currentSwipe;
	public static bool canswipe;
	public static GameObject The_Dragged;


	public enum SwipeDirection{
		Up,
		Down,
		Right,
		Left
	}

	public static event Action<SwipeDirection> Swipe;
	public static bool swiping = false;
	private bool eventSent = false;
	private Vector2 lastPosition;
	void Start(){
		canswipe = true;
	}
	void Update () {

		three();
	}

	void three(){
		if(Input.touches.Length > 0 && canswipe)
		{
			//Debug.Log("YOUVH");
			Touch t = Input.GetTouch(0);
			if(t.phase == TouchPhase.Began)
			{
				Debug.Log("A");
				//save began touch 2d point
				firstPressPos = new Vector2(t.position.x,t.position.y);
			}
			if(t.phase == TouchPhase.Ended)
			{
				Debug.Log("D");
				//save ended touch 2d point
				secondPressPos = new Vector2(t.position.x,t.position.y);

				//create vector from the two points
				currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

				Debug.Log(currentSwipe);
				//normalize the 2d vector
				//currentSwipe.Normalize();
				//Debug.Log(currentSwipe);
				Vector2 screenvalue = ScreenValue(currentSwipe);
				currentSwipe.Normalize();
				//Debug.Log(screenvalue);
				Debug.Log((Mathf.Abs(screenvalue.x) + Mathf.Abs(screenvalue.y)));
				//swipe upwards
				if((Mathf.Abs(screenvalue.x) + Mathf.Abs(screenvalue.y)) > 0.04 ){
					//Debug.Log("Big");
					if(currentSwipe.y > 0.5 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
					{
						Debug.Log("up swipe");
						Debug.Log(firstPressPos.x + "+" + firstPressPos.y );
						Debug.Log(secondPressPos.x + "+" + secondPressPos.y);

						mydirection = "Up";
					}
					//swipe down
					if(currentSwipe.y < -0.5 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
					{
						Debug.Log("down swipe");
						Debug.Log(firstPressPos.x + "+" + firstPressPos.y );
						Debug.Log(secondPressPos.x + "+" + secondPressPos.y);

						mydirection = "Down";
					}
					//swipe left
					if(currentSwipe.x < -0.5 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
					{
						Debug.Log(firstPressPos.x + "+" + firstPressPos.y);
						Debug.Log(secondPressPos.x + "+" + secondPressPos.y );

						Debug.Log("left swipe");
						mydirection = "Left";
					}
					//swipe right
					if(currentSwipe.x > 0.5 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
					{
						Debug.Log(firstPressPos.x + "+" + firstPressPos.y);
						Debug.Log(secondPressPos.x + "+" + secondPressPos.y );

						Debug.Log("right swipe");
						mydirection = "Right";
					}					
				}
			}
		}
	}
	Vector2 ScreenValue(Vector2 Swipe){
		Vector2 result = new Vector2();
		result.x = (float)Swipe.x/Screen.width;
		result.y = (float)Swipe.y/Screen.height;
		return result;
	}

}