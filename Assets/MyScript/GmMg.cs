using UnityEngine;

public class GmMg : MonoBehaviour
{
    public static GmMg instance = null;
    public bool decision = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
}
