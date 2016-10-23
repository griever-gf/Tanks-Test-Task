using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject gameField;
    public GameObject tankSpawnPoint;
    Vector3 maxCameraPoint, minCameraPoint;

    Vector3 ConvertToCameraPosition(Vector3 pos)
    {
        return new Vector3(pos.x, transform.position.y, pos.z);
    }

    void Start () {
        //setting camera movement limits
        float cameraDistance = Mathf.Abs(transform.position.y - gameField.transform.position.y);
        float visibleFieldHeight = Vector3.Distance(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, cameraDistance)), Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, cameraDistance)));
        float visibleFieldWidth = Vector3.Distance(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, cameraDistance)), Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, cameraDistance)));
        Vector3 maxFieldPoint = Vector3.Scale(gameField.GetComponent<MeshFilter>().mesh.bounds.max, gameField.transform.localScale);
        maxCameraPoint = ConvertToCameraPosition(maxFieldPoint - new Vector3(visibleFieldWidth / 2, 0, visibleFieldHeight / 2));
        Vector3 minFieldPoint = Vector3.Scale(gameField.GetComponent<MeshFilter>().mesh.bounds.min, gameField.transform.localScale);
        minCameraPoint = ConvertToCameraPosition(minFieldPoint + new Vector3(visibleFieldWidth / 2, 0, visibleFieldHeight / 2));
    }

    public void UpdateCameraPosition(Vector3 coords)
    {
        Vector3 pos = ConvertToCameraPosition(coords);
        if (pos.x > maxCameraPoint.x) pos.x = maxCameraPoint.x;
        else if (pos.x < minCameraPoint.x) pos.x = minCameraPoint.x;
        if (pos.z > maxCameraPoint.z) pos.z = maxCameraPoint.z;
        else if (pos.z < minCameraPoint.z) pos.z = minCameraPoint.z;
        transform.position = pos;
    }

    public void ResetCameraPosition()
    {
        transform.position = ConvertToCameraPosition(tankSpawnPoint.transform.position);
    }
}
