using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private GameObject markerInstance;
    bool isMarkerActive = false;
    float markerHeight = 0.0f;

    [Header("Marker Prefabs")]
    public GameObject walkableCursor;
    public GameObject selectableCursor;
    public GameObject attackableCursor;
    public GameObject unAvailableCursor;

    CursorType currentCursor;

    public enum CursorType
    {
        None,
        Walkable,
        UnAvailable,
        Selectable,
        Attackable
    }

    void Update()
    {
        if (isMarkerActive)
        {
            markerInstance.SetActive(true);
            Cursor.visible = false;

            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            Plane groundPlane = new Plane(Vector3.up, new Vector3(0, markerHeight, 0));
            float rayDistance;

            if (groundPlane.Raycast(ray, out rayDistance))
            {
                Vector3 worldPosition = ray.GetPoint(rayDistance);
                markerInstance.transform.position = worldPosition;
            }
        }
        else
        {
            markerInstance?.SetActive(false);
            Cursor.visible = true;
        }
    }

    public void SetMarkerType(CursorType type)
    {
        if (type != currentCursor)
        {
            isMarkerActive = true;
            currentCursor = type;
            switch (type)
            {
                case CursorType.Walkable:
                    markerInstance?.SetActive(false);
                    markerInstance = walkableCursor;
                    return;
                case CursorType.Selectable:
                    markerInstance?.SetActive(false);
                    markerInstance = selectableCursor;
                    return;
                case CursorType.Attackable:
                    markerInstance?.SetActive(false);
                    markerInstance = attackableCursor;
                    return;
                case CursorType.UnAvailable:
                    markerInstance?.SetActive(false);
                    markerInstance = unAvailableCursor;
                    return;
                case CursorType.None:
                    markerInstance?.SetActive(false);
                    isMarkerActive = false;
                    return;
            }
        }
    }
}
