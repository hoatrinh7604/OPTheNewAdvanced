using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop dieu khien camera theo nhan vat
public class CameraController : MonoBehaviour {

	private Transform target;
	public float smoothTime = 0.15f;

	public bool YMaxEnable = false;
	public float YMaxValue = 0;
	public bool YMinEnable = false;
	public float YMinValue = 0;
	public bool XMaxEnable = false;
	public float XMaxValue = 0;
	public bool XMinEnable = false;
	public float XMinValue = 0;


	Vector3 velority = Vector3.zero;

	void FixedUpdate()
	{

		if (target == null) {
			target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		} else {

			Vector3 targetPos = target.position;

			//Vertical
			if (YMaxEnable && YMinEnable) {
				targetPos.y = Mathf.Clamp (target.position.y, YMinValue, YMaxValue);
			} else if (YMinEnable) {
				targetPos.y = Mathf.Clamp (target.position.y, YMinValue, target.position.y);
				;
			} else if (YMaxEnable) {
				targetPos.y = Mathf.Clamp (target.position.y, target.position.y, YMaxValue);
				;
			}

			//Horizontal
			if (XMaxEnable && XMinEnable) {
				targetPos.x = Mathf.Clamp (target.position.x, XMinValue, XMaxValue);
			} else if (XMinEnable) {
				targetPos.x = Mathf.Clamp (target.position.x, XMinValue, target.position.x);
				;
			} else if (XMaxEnable) {
				targetPos.x = Mathf.Clamp (target.position.x, target.position.x, XMaxValue);
				;
			}

			targetPos.z = transform.position.z;

			transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velority, smoothTime);
		}
	}
}
