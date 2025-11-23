using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using static UnityEngine.GraphicsBuffer;

public class LightBeam : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] LayerMask rayHitMask;

    LineRenderer _lightBeam;

    void Start()
    {
        _lightBeam = GetComponent<LineRenderer>();
        _lightBeam.startWidth = 0.1f;
        _lightBeam.endWidth = 0.1f;

        //_lightBeam.startColor = Color.red;
        // _lightBeam.endColor = Color.red;

        //_lightBeam.SetPosition(0, startPoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        Ray hitRay = new Ray(startPoint.position,startPoint.forward);
        RaycastHit hitInfo;
        Debug.DrawLine(hitRay.origin, hitRay.direction * 20, Color.green);
        if (Physics.Raycast(hitRay.origin,hitRay.direction, out hitInfo, 20,rayHitMask))
        {
            //if (hitInfo.collider.GetComponent<Interactable>() != null)
            //{
                Debug.Log("Mirror");
            //} 
            //_lightBeam.SetPosition(1, hitInfo.point);
        }
    }
}
