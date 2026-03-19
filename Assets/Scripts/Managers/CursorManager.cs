
using Unity.VisualScripting;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    
    static private Vector2 cursorHotspot;
    static private CursorMode cursorMode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cursorHotspot = Vector2.zero;
        cursorMode = CursorMode.Auto;
        Cursor.SetCursor(cursorTexture, cursorHotspot, cursorMode);
    }

    // Update is called once per frame
    public static void changeTo(CursorType newCursor){
        Texture2D newCursorTexture;
        switch (newCursor) {
            case CursorType.POINTER:
            newCursorTexture = Resources.Load<Texture2D>("Cursors/Pointer");
            break;
            case CursorType.HAND_OPEN:
            newCursorTexture = Resources.Load<Texture2D>("Cursors/Hand_Open");
            break;
            case CursorType.HAND_GRAB:
            newCursorTexture = Resources.Load<Texture2D>("Cursors/Hand_Grab");
            break;
            case CursorType.KNIFE_KITCHEN:
            newCursorTexture = Resources.Load<Texture2D>("Cursors/Knife");
            break;
            case CursorType.KNIFE_STAB:
            newCursorTexture = Resources.Load<Texture2D>("Cursors/Knife_Stab");
            break;
            case CursorType.ARROW:
            newCursorTexture = Resources.Load<Texture2D>("Cursors/Arrow");
            break;
            default:
            newCursorTexture = null;
            break;
        }

        Cursor.SetCursor(newCursorTexture,cursorHotspot,cursorMode);
    }
}
