using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary> Use only for parallax background. Has no external links. </summary>
public class BackGroundController : MonoBehaviour {

  [SerializeField]  BackgroundLayer[] Backgrounds;

	Camera main;
	Vector3 PrevCameraPos;

	Vector3 CameraPos;

	private void Start () {
		main = Camera.main;
		transform.SetParent(main.transform);
		CameraPos = main.transform.position;
		PrevCameraPos = CameraPos;
		for (int i = 0; i < Backgrounds.Length; i++) {
			Backgrounds[i].BorderByHorizontal = Backgrounds[i].FirstSprite.size.x;
			Backgrounds[i].SecondSprite = GameObject.Instantiate(Backgrounds[i].FirstSprite, Backgrounds[i].FirstSprite.transform.parent);
			Backgrounds[i].SecondSprite.transform.localPosition = Backgrounds[i].FirstSprite.transform.localPosition;
			transform.localPosition = new Vector3(Backgrounds[i].BorderByHorizontal, transform.localPosition.y, transform.localPosition.z);
		}
	}

	private void Update () {
		if (PrevCameraPos == CameraPos) return;

		var deltaCameraPos =  PrevCameraPos - CameraPos;
		PrevCameraPos = CameraPos;

		for (int i = 0; i < Backgrounds.Length; i++) {
			var deltaPos = deltaCameraPos;
			deltaPos *= Backgrounds[i].MultiplierScrollSpeed;
			Backgrounds[i].FirstSprite.transform.localPosition += deltaPos;
			Backgrounds[i].SecondSprite.transform.localPosition += deltaPos;

			CheckBorder(Backgrounds[i].FirstSprite.transform, Backgrounds[i].BorderByHorizontal);
			CheckBorder(Backgrounds[i].SecondSprite.transform, Backgrounds[i].BorderByHorizontal);
		}
	}

	void CheckBorder (Transform transform, float borderByHorizontal) {
		if (transform.localPosition.x > borderByHorizontal) {
			transform.localPosition=new Vector3(transform.localPosition.x - (borderByHorizontal * 2),transform.localPosition.y,transform.localPosition.z);
		} else if (transform.localPosition.x < -borderByHorizontal) {
			transform.localPosition = new Vector3(transform.localPosition.x + (borderByHorizontal * 2), transform.localPosition.y, transform.localPosition.z);
		}
	}

	[Serializable]
	class BackgroundLayer {
		public string CaptionLayer;			
		public SpriteRenderer FirstSprite;	
		public float MultiplierScrollSpeed;     

		public SpriteRenderer SecondSprite { get; set; }
		public float BorderByHorizontal { get; set; }
	}
}
