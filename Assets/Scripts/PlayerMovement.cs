using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float rotSpeedd = 180f;
    float shipBoundaryRadius = 0.5f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the ship
        Quaternion rot = transform.rotation;                            // Grab our rotation quarternion
        float z = rot.eulerAngles.z;                                    // Grab the Z euler angle
        z -= Input.GetAxis("Horizontal") * rotSpeedd * Time.deltaTime;  // Chance the Z angle based on input
        rot = Quaternion.Euler(0, 0, z);                                // Recreate the quarternion
        transform.rotation = rot;                                       // Feed the quarternion into our rotation

        // Move y the ship
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;

        // RESTRICT the player to the camera's boundaries! - LIMITE DA TELA

        // First to vertical, because it's simpler
        if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }
        if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }

        // Now calculate the orthographic width based on the screen ratio
        float screenRadio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRadio;

        // Now do horizontal bounds
        if (pos.x + shipBoundaryRadius > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundaryRadius;
        }
        if (pos.x - shipBoundaryRadius < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundaryRadius;
        }

        // Finaly, update to position
        transform.position = pos;
        // faz a mesma coisa que o código de cima / same process as above code
        ///transform.Translate(new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0));
    }
}
