using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject player;

    // The radius the player can be from the center of the camera.
    [SerializeField] float playerMaxRadius;
    //The player position relative to the camera.
    [SerializeField] Vector2 playerPositionRelative;
    //The multiple of the camera size that will beused to calculate player radius.
    [SerializeField] float sizeMultiple = 2/3;
    [SerializeField] float cameraMaxVelocityMag;
    [SerializeField] float cameraVelocityMag;
    [SerializeField] float cameraSize;

    [SerializeField] float yMaxPosition;
    [SerializeField] float yMinPosition;
    [SerializeField] float xMaxPosition;
    [SerializeField] float xMinPosition;

    [SerializeField] Vector2 cameraVelocity;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        cameraVelocity = new Vector2();
        mainCamera = this.GetComponent<Camera>();
        player = FindObjectOfType<PlayerHandler>().gameObject;
        playerMaxRadius = cameraSize * sizeMultiple;
        playerPositionRelative = new Vector2();
        cameraMaxVelocityMag = player.GetComponent<PlayerHandler>().moveMag;
    }


    private void FixedUpdate()
    {
        playerPositionRelative.Set
            (player.transform.position.x - mainCamera.transform.position.x,
            player.transform.position.y - mainCamera.transform.position.y);
        cameraVelocityMag =
            (playerPositionRelative.magnitude / playerMaxRadius)
            * cameraMaxVelocityMag;
        if (cameraVelocityMag > cameraMaxVelocityMag)
        {
            cameraVelocityMag = cameraMaxVelocityMag;
        }

        cameraVelocity = playerPositionRelative.normalized * cameraVelocityMag;

        ///Determining if the camera is out of bounds, and if it is
        ///sets the according velocity so it doesn't continue to move in that
        ///direction.
        if(transform.position.x < xMinPosition && cameraVelocity.x < 0)
        {
            cameraVelocity = new Vector2(0, cameraVelocity.y);
        }
        if (transform.position.x > xMaxPosition && cameraVelocity.x > 0)
        {
            cameraVelocity = new Vector2(0, cameraVelocity.y);
        }
        if (transform.position.y < yMinPosition && cameraVelocity.y < 0)
        {
            cameraVelocity = new Vector2(cameraVelocity.x, 0);
        }
        if (transform.position.y > yMaxPosition && cameraVelocity.y > 0)
        {
            cameraVelocity = new Vector2(cameraVelocity.x, 0);
        }

        transform.Translate(cameraVelocity.x * Time.fixedDeltaTime, cameraVelocity.y * Time.fixedDeltaTime, 0);
    }
}
