using UnityEngine;
using UnityEngine.EventSystems;

/* Currently allows us to interact with the map, will be replaced by actual gameplay */
public class HexMapEditor : MonoBehaviour
{

    // I've tried declaring and initializing this different ways to try to get the warning 
    // to stop when it's called in Awake() but it wont and idfk why
    public int[] textures = new int[6]; 

    public HexGrid hexGrid;
    public TurnManager turnManager;

    private int activeTexture;

    void Awake()
    {
        SelectColor(0);   
    }

    Vector3 lastHitPoint; // Keep track of the last hex that was colored
    bool isDragging = false; // Keep track of whether the mouse is currently being dragged

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = false;
            }
            else if (Input.GetMouseButton(0))
            {
                if (!isDragging)
                {
                    // If the mouse has just started dragging, color the initial hex
                    isDragging = true;
                    RaycastHit hit;
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                    {
                        lastHitPoint = hit.point;
                        if(hexGrid.CheckColorCell(lastHitPoint, activeTexture)){ // "object reference not set to an instance of an object"
                        	HandleInput();
						}
                    }
                }
                else
                {
                    // If the mouse is still being dragged, color any new hexes that it hits
                    RaycastHit hit;
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                    {
                        if (hit.point != lastHitPoint)
                        {
                            if (hexGrid.CheckColorCell(hit.point, activeTexture)) // "object reference not set to an instance of an object"
                            {
                                lastHitPoint = hit.point;
                                HandleInput();
                            }
                        }
                    }
                }
            }
            else
            {
                isDragging = false;
            }
        }
    }



    /* Model for how to handle clicking on the hexes
		 Raycast to get click coordinates
		 Add a method to HexGrid to do whatever the click needs to do
		 e.g. ColorCell */
    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            if (turnManager.tilling())
            {
                hexGrid.ColorCell(hit.point, activeTexture);
            }
        }
    }

    public HexCell getCell()
    {
      Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      if (Physics.Raycast(inputRay, out hit))
      {
        return hexGrid.getCell(hit.point);
      }
      return null;
    }

    public void SelectColor(int index)
    {
        if (textures.Length > 0)
            activeTexture = textures[index];
        else
            Debug.Log("Awake() throwing out of range exception"); // even when initialized... why is this even called in Awake()? When even is Awake() called?
    }
}
