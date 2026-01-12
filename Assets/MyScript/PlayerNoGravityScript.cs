using UnityEngine;

public class PlayerNoGravityScript : MonoBehaviour
{
    public GameObject player;

    private PlayerMoveScript playerScript;
    private bool gravityBool = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript=player.GetComponent<PlayerMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        gravityBool = playerScript.noGravityTriggerBool || playerScript.downTriggerBool || playerScript.upTriggerBool;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Planet" || other.gameObject == playerScript.mainPlanet || gravityBool || !playerScript.playerJumping) return;
        playerScript.noGravityTriggerBool = true;

    }

}
