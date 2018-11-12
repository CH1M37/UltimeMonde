using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingTex : MonoBehaviour {

    public float ScrollX = 0.2f;
    public float ScrollY = 0.2f;

	void Update () {

        float OffsetX = Time.unscaledTime * ScrollX;
        float OffsetY = Time.unscaledTime * ScrollY;

        GetComponent<Image>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);

        // GetComponent<RawImage>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);

        // GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);

	}
}
