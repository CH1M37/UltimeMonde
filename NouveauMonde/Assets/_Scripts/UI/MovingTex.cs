using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingTex : MonoBehaviour {

    public float ScrollX = 0.5f;
    public float ScrollY = 0.5f;

	void Update () {

        float OffsetX = Time.time * ScrollX;
        float OffsetY = Time.time * ScrollY;

        GetComponent<Image>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);

        // GetComponent<RawImage>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);

        // GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);

	}
}
