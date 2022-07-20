using UnityEngine;

public class GameManager : MonoBehaviour
{

    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }
}
