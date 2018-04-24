using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MouseFollow : MonoBehaviour {


	public static Vector3 shipPos;
	public float speed = 1f;
	private Quaternion localRotation;
	private Vector3 eulerAngles;
	public float waiting = 5;

    private float timer = 0;
    private float timerMax = 0;

    void Start () {
		
		Cursor.visible = false;

    }

    void FixedUpdate () {

        if (!Waited(4))
        {
            this.gameObject.transform.position = new Vector2(0, -4);
        }
        else {

            shipPos = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f);
            shipPos.z = -2;
            shipPos.x = Mathf.Clamp(shipPos.x, -8.18f, 8.18f);
            shipPos.y = Mathf.Clamp(shipPos.y, -4.37f, 4.37f);

            if (Input.GetAxis("Mouse X") > 0.25f)
            {
                eulerAngles.z -= speed;
            }
            else if (Input.GetAxis("Mouse X") < -0.25f)
            {
                eulerAngles.z += speed;
            }
            else {
                eulerAngles.z -= Mathf.Sign(eulerAngles.z) * speed * 1.3f;
            }

            if (eulerAngles.z > 30)
            {
                eulerAngles.z = 30;
            }
            else if (eulerAngles.z < -30)
            {
                eulerAngles.z = -30;
            }

            transform.localRotation = Quaternion.Euler(eulerAngles);

            transform.position = shipPos;
        }
	}

    private bool Waited(float seconds)
    {
        timerMax = seconds;

        timer += Time.deltaTime;

        if (timer >= timerMax)
        {
            return true; //max reached - waited x - seconds
        }

        return false;
    }
}
