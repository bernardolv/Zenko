﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviour : MonoBehaviour {
	Animator myanim;
	public Transform myplayer;
	//public bool moving;
	public static bool readytomove;
	public static bool isvertical;
	public static float newx;
	public static float oldx;
	public static float newy;
	public static float oldy;
	public static bool isstatic;
	public static float xdif;
	public static float ydif;
	public static bool movingtowards;
	public static bool movingaway;
	public static int lastphase;
	// Use this for initialization
	void Start () {
		myanim = GetComponentInChildren<Animator>();
		readytomove = false;
		isstatic =true;
//		Debug.Log(transform.rotation.y);
//		Debug.Log(newx);
	}
	
	// Update is called once per frame
	void Update () {
		//if(myplayer.GetComponent<PlayerMovement>().currenttile != myplayer.transform.position){
		//	Debug.Log("Moving");
		//}
		if(LevelBuilder.playertransform!= null){
		newx = LevelBuilder.playertransform.position.x;
		newy = -LevelBuilder.playertransform.position.z;
		xdif = Mathf.Abs(newx-transform.position.x);
		ydif = Mathf.Abs(newy+transform.position.z);			
		}

//		Debug.Log(lastphase);

		if(readytomove){
			if(isstatic == true){
				newx = LevelBuilder.playertransform.position.x;
				oldx = LevelBuilder.playertransform.position.x;
				newy = -LevelBuilder.playertransform.position.z;
				oldy = -LevelBuilder.playertransform.position.z;
				isstatic = false;
			}
			else{
				newx = LevelBuilder.playertransform.position.x;
				newy = -LevelBuilder.playertransform.position.z;
			}
			//Debug.Log(newx + "" + oldx +newy+oldy );
//			Debug.Log(lastphase);
			xdif = Mathf.Abs(newx-transform.position.x);
			ydif = Mathf.Abs(newy+transform.position.z);
			//if moving towards value
			//if moving away from value
			//Debug.Log(xdif + "" + ydif);
			if(isvertical){
				if(newx>oldx){//moving right
					if(xdif<1.5){
						if (transform.position.x>newx){//getting closer since im at its right.
							myanim.SetInteger("Phase",1);
			//				Debug.Log("orthis");
							lastphase = 1;
						}							
					}

					if (transform.position.x<newx){//getting away since im at its left.
						myanim.SetInteger("Phase",0);
						lastphase = 0;
					}

				}
				if(newx<oldx){//moving left
					if(xdif<1.5){
						if (transform.position.x<newx){//getting closer because im at it's left
							myanim.SetInteger("Phase",1);
//							Debug.Log("this");
							lastphase = 1;
						}								
					}
					if (transform.position.x>newx){//getting away since im at its right
						myanim.SetInteger("Phase",0);
						lastphase = 0;
					}					
			
					
				}
				if(newy<oldy){//moving up
					Debug.Log("Moving where");
					if(xdif<.9){
						Debug.Log(ydif);
						if(ydif<1.5){
							Debug.Log(-transform.position.z);
							Debug.Log(newy);
							if(-transform.position.z<newy){
							//	Debug.Log("Doing this");
								myanim.SetInteger("Phase",2);
								lastphase = 2;								
							}

						}
						else{
							if (-transform.position.z>newy){//getting closer
								myanim.SetInteger("Phase",1);
								//Debug.Log("orthis");
								lastphase = 1;
							}							
						}
						
					}
				}
				if(newy>oldy){//moving down
					if(xdif<.9){
						if(ydif<1.5){
							myanim.SetInteger("Phase",2);
							lastphase = 2;
						}
						else{
							if (transform.position.x>newx){//getting closer
								myanim.SetInteger("Phase",1);
								//Debug.Log("orthis");
								lastphase = 1;
							}							
						}
						
					}

				}
			//check x
			}
			if(!isvertical){
				if(newy>oldy){//moving up
					if(ydif<1.5){
						if (-transform.position.z>newy){//getting closer
							myanim.SetInteger("Phase",1);
							//Debug.Log("orthis");
							lastphase = 1;
						}							
						
					}
						if (-transform.position.z<newy){//getting away
							myanim.SetInteger("Phase",0);
							lastphase = 0;					
					}


				}
				if(newy<oldy){//moving down
					if(ydif<1.5){
						if (-transform.position.z<newy){//getting closer
							myanim.SetInteger("Phase",1);
							//Debug.Log("this");
							lastphase = 1;
						}								
					}
						if (-transform.position.z>newy){//getting away
							myanim.SetInteger("Phase",0);
							lastphase = 0;
						}							

				}
				if(newx>oldx){//moving right
					if(ydif<.9){
						if(xdif<1.5){
							myanim.SetInteger("Phase",2);
							lastphase = 2;
						}
						else{
							if (-transform.position.z>newy){
								myanim.SetInteger("Phase",1);
							//	Debug.Log("orthis");
								lastphase = 1;
							}							
						}
						
					}
				}
				if(newx<oldx){//moving down
					if(ydif<.9){
						if(xdif<1.5){
							myanim.SetInteger("Phase",2);
							lastphase = 2;
						}
						else{
							if (-transform.position.z>newy){
								Debug.Log("orthis");
								lastphase = 1;
							}							
						}
						
					}
				}
			}
			//myanim.SetInteger("Phase", lastphase);	

			oldx = newx;
			oldy = newy;
		}
		//if(!readytomove){
		//	isstatic = true;
		//}
//		Debug.Log("Is vertical" + isvertical);
	}

	void OpenFlower(){

	}

	void EatFox(){

	}

}
