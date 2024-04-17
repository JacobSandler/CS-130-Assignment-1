using UnityEngine;

public class camera_rotate : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 offset;

    Vector3 newpos;

    public GameObject player;
    void Start()
    {
        offset = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position - offset;
    }
}
