using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour {
    [SerializeField]
    private GameObject destroyedPrefab;
    [Header("Destruction Score")]
    [SerializeField]
    private float buildingScore = 0f;

    private TimeManager timeManager;
    private ScoreManager scoreManager;

    // Use this for initialization
    void Start () {
        timeManager = GameObject.FindObjectOfType<TimeManager>();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            timeManager.timeSinceLastDestruction = 0f;
            timeManager.checkWaste = true;
            GameObject destroyedObject = Instantiate(destroyedPrefab, gameObject.transform.position, gameObject.transform.rotation);
            destroyedObject.transform.localScale = gameObject.transform.lossyScale;
            Destroy(gameObject);

            scoreManager.UpdateScore(buildingScore);
        }
    }

}
