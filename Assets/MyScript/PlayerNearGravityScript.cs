using UnityEngine;

public class PlayerNearGravityScript : MonoBehaviour
{
    public GameObject player;
    public bool UpBool;


    private PlayerMoveScript playerScript;
    private bool gravity = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = player.GetComponent<PlayerMoveScript>();
    }

    void Update()
    {
        gravity = playerScript.nearGravityDownBool || playerScript.nearGravityUpBool || playerScript.suparSafeBool;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Planet" || other.gameObject == playerScript.mainPlanet || !playerScript.playerJumping || gravity) return;
        if (UpBool)
        {
            playerScript.nearGravityUpBool = true;
        }
        else
        {
            playerScript.nearGravityDownBool = true;
        }
    }
}
