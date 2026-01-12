using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class PlayerSuparSafeTrigger : MonoBehaviour
{

    public GameObject player;
    public bool UpBool;


    private PlayerMoveScript playerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = player.GetComponent<PlayerMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Planet" || other.gameObject == playerScript.mainPlanet || !playerScript.playerJumping ) return;
        playerScript.suparSafeBool = true;
        playerScript.nearGravityUpBool = false;
        playerScript.nearGravityDownBool = false;
    }

}
