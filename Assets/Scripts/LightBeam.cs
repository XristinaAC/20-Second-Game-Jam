using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using static UnityEngine.GraphicsBuffer;

public class LightBeam : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] LayerMask rayHitMask;
    [SerializeField] LayerMask rayHitMaskMirror;
    [SerializeField] LayerMask ignoreLayer;
    [SerializeField] GameObject mirror;
    [SerializeField] GameObject mirrorBase;

    LineRenderer _lightBeam;
    bool ray1 = false;

    //lineRenderer.positionCount = 3;

    void Start()
    {
        _lightBeam = GetComponent<LineRenderer>();
        _lightBeam.startWidth = 0.1f;
        _lightBeam.endWidth = 0.1f;
        //_lightBeam.SetPosition(0, startPoint.position);
    }
    Ray hitRay;
    Vector3 point;
    bool reflect;

    private void Update()
    {
        //Physics.Raycast(hitRay.origin, hitRay.direction, 12, ~ignoreLayer);
        //bool hit2 = Physics.Raycast(hitRay.origin, hitRay.direction, out hitInfo, 12);
        //Debug.DrawLine(hitRay.origin, hitInfo.point, Color.green);
        if (ray1)//&& hitInfo.collider && !hitInfo.collider.CompareTag("mirrorBase"));
        {
            RaycastHit hitInfo;
            RaycastHit hitInfo2;
            bool hit2 = Physics.Raycast(hitRay.origin, hitRay.direction, out hitInfo,20,~ignoreLayer);



            //if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == 7)
            //{
            //    Debug.Log("Mirror2");
            //}
            Debug.Log(hitInfo.collider.gameObject.name);
            bool hit3 = Physics.Raycast(hitRay.origin, hitRay.direction, out hitInfo2, 20, ~ignoreLayer);
            if (hitInfo2.collider != null && hitInfo2.transform.gameObject.name == mirrorBase.name)
            {
               
                Debug.Log("Mirror3");
            }

            if (reflect)
            {
                //Debug.Log("MirrorBase");
                _lightBeam.positionCount += 1;
                _lightBeam.SetPosition(2, endPoint.position);
                ray1 = false;
            }
        }
    }

    public void CreateBeam()
    {
        _lightBeam.SetPosition(0, startPoint.position);
        Vector3 direction = mirror.transform.position - startPoint.position;
        hitRay = new Ray(startPoint.position, direction);
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(hitRay.origin, hitRay.direction, out hitInfo, 20, rayHitMask);
        //Debug.DrawLine(hitRay.origin, hitInfo.point, Color.green);

        if (hit)
        {
            _lightBeam.SetPosition(1, hitInfo.point);
            ray1 = true;
            //_lightBeam.positionCount += 1;
            //_lightBeam.SetPosition(2, endPoint.position);
        }
    }
}
