using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPlatformScript : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    private Vector2 startPos;
    private Vector2 endPos;
    private bool drawing = false;
    private GameObject platform;

    void Update()
    {
        if (GameManagerScript.state == GameManagerScript.GameState.gamePlayed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                drawing = true;
            }

            if (Input.GetMouseButtonUp(0) && drawing)
            {
                endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                DrawPlatform(startPos, endPos);
                drawing = false;
            }
        }
        else
        {
            drawing = false;
        }
    }

    void DrawPlatform(Vector2 start, Vector2 end)
    {
        if (platform)
        {
            Destroy(platform);
        }
        platform = Instantiate(platformPrefab, (start + end) / 2, Quaternion.identity);
        float length = Vector2.Distance(start, end);
        platform.transform.localScale = new Vector3(length, platform.transform.localScale.y, platform.transform.localScale.z);
        platform.transform.right = end - start;
    }
}
