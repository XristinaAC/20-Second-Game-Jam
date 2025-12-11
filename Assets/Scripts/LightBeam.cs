using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using static UnityEngine.GraphicsBuffer;

public class LightBeam : MonoBehaviour
{
    public static LightBeam instance = null;

    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] Transform end;
    [SerializeField] LayerMask rayHitMask;
    [SerializeField] LayerMask rayHitMaskMirror;
    [SerializeField] LayerMask ignoreLayer;
    [SerializeField] GameObject mirror;
    [SerializeField] GameObject mirrorBase;

    LineRenderer _lightBeam;
    bool ray1 = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

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
        //RaycastHit hitInfo2;
        //Vector3 direction = mirrorBase.transform.position - startPoint.position;
        //Ray hitRay2 = new Ray(startPoint.position, direction);
        //bool hit3 = Physics.Raycast(hitRay2.origin, hitRay2.direction, out hitInfo2, 20, ~ignoreLayer);
        //Debug.DrawLine(hitRay2.origin, hitInfo2.point, Color.green);

        if(ray1 && MirrorBase.instance.new_surface)
        {
            MirrorBase.instance.new_surface = false;
            RaycastHit hitInfo2;
            Vector3 direction = end.transform.position - startPoint.position;
            Ray hitRay2 = new Ray(startPoint.position, direction);
            bool hit3 = Physics.Raycast(hitRay2.origin, hitRay2.direction, out hitInfo2, 20, ~ignoreLayer);
            
            Debug.Log(hitInfo2.collider.gameObject.layer);
            Debug.DrawLine(hitRay2.origin, hitInfo2.point, Color.green);
         
            if (hitInfo2.collider != null && hitInfo2.collider.gameObject.layer == 7)
            {
                //Debug.Log("Mirror3");
            }
        }
    }

    public void Reflect()
    {
        if (ray1)
        {
            if (reflect)
            {
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

        if (hit)
        {
            _lightBeam.SetPosition(1, hitInfo.point);
            ray1 = true;
        }
    }
}
