using UnityEngine;
using System.Linq;


public class InteractiveShadows : MonoBehaviour
{
    [SerializeField] private Transform shadowTransform;

    [SerializeField] private Transform lightTransform;
    private LightType lightType;

    [SerializeField] private LayerMask targetLayerMask;

    [SerializeField] private Vector3 extrusionDirection = Vector3.zero;

    public Material material;
    public GameObject shadowGameObject;

    private Vector3[] objectVertices;

    private Mesh shadowColliderMesh;
    private MeshCollider shadowCollider;

    private Vector3 previousPosition;
    private Quaternion previousRotation;
    private Vector3 previousScale;

    private bool canUpdateCollider = true;

    private bool frezeCollider = false;

    [SerializeField][Range(0.02f, 1f)] private float shadowColliderUpdateTime = 0.08f;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            frezeCollider = !frezeCollider;

            if(frezeCollider)
            {
                shadowCollider.isTrigger = false;
                canUpdateCollider = false;
            }
            else
            {
                shadowCollider.isTrigger = true;
                canUpdateCollider = true;
            }
        }
        
    }

    private void Awake()
    {
        if (frezeCollider == false)
        {
            InitializeShadowCollider();

            lightType = lightTransform.GetComponent<Light>().type;

            objectVertices = transform.GetComponent<MeshFilter>().mesh.vertices.Distinct().ToArray();

            shadowColliderMesh = new Mesh();
        }
    }

    void LateUpdate()
    {
        if (frezeCollider == false)
        {
            shadowTransform.position = transform.position;
            shadowGameObject.GetComponent<MeshFilter>().mesh = shadowColliderMesh;
        }

    }

    private void FixedUpdate()
    {
        if (TransformHasChanged() && canUpdateCollider)
        {
            Invoke("UpdateShadowCollider", shadowColliderUpdateTime);
            canUpdateCollider = false;
        }

        previousPosition = transform.position;
        previousRotation = transform.rotation;
        previousScale = transform.localScale;
    }

    private void InitializeShadowCollider()
    {
        //shadowGameObject.hideFlags = HideFlags.HideInHierarchy; //OPTIONNAL
        shadowCollider = shadowGameObject.AddComponent<MeshCollider>();


        shadowGameObject.GetComponent<MeshRenderer>().material = material;
        
        shadowCollider.convex = true;
        shadowCollider.isTrigger = true;

        //shadowColliderMesh.triangles = new int[objectVertices.Length * 3];
    }

    private void UpdateShadowCollider()
    {
        shadowColliderMesh.vertices = ComputeShadowColliderMeshVertices();
        shadowCollider.sharedMesh = shadowColliderMesh;
        if (frezeCollider == false) 
        { 
            canUpdateCollider = true; 
        }
    }

    private Vector3[] ComputeShadowColliderMeshVertices()
    {
        Vector3[] points = new Vector3[2 * objectVertices.Length];
        int[] triangles = new int[objectVertices.Length * 3];

        Vector3 raycastDirection = lightTransform.forward;

        int n = objectVertices.Length;

        for (int i = 0; i < n; i++)
        {
            Vector3 point = transform.TransformPoint(objectVertices[i]);

            if (lightType != LightType.Directional)
            {
                raycastDirection = point - lightTransform.position;
            }

            points[i] = ComputeIntersectionPoint(point, raycastDirection);

            points[n + i] = ComputeExtrusionPoint(point, points[i]);

            if (i < n - 2)
            {
                triangles[i * 3] = i;
                triangles[i * 3 + 1] = n + i;
                triangles[i * 3 + 2] = n + i + 1;
            }
            else
            {
                triangles[i * 3] = i;
                triangles[i * 3 + 1] = n + i;
                triangles[i * 3 + 2] = 0;
            }
        }

        return points;
    }

    private Vector3 ComputeIntersectionPoint(Vector3 fromPosition, Vector3 direction)
    {
        RaycastHit hit;

        if (Physics.Raycast(fromPosition, direction, out hit, Mathf.Infinity, targetLayerMask))
        {
            return hit.point - transform.position;
        }

        return fromPosition + 100 * direction - transform.position;
    }

    private Vector3 ComputeExtrusionPoint(Vector3 objectVertexPosition, Vector3 shadowPointPosition)
    {
        if (extrusionDirection.sqrMagnitude == 0)
        {
            return objectVertexPosition - transform.position;
        }

        return shadowPointPosition + extrusionDirection;
    }

    private bool TransformHasChanged()
    {
        return previousPosition != transform.position || previousRotation != transform.rotation || previousScale != transform.localScale;
    }
}