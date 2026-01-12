using UnityEngine;

public class CopyPositionScript : MonoBehaviour
{
    public GameObject targetObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=targetObj.transform.position;
        transform.rotation=targetObj.transform.rotation;
    }
}
