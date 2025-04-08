using UnityEngine;

public class TargetCam : MonoBehaviour
{
    [SerializeField]
    private Transform Taget;
 
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,Taget.transform.position.z); 
    }
}
