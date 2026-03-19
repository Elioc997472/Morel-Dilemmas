
using Unity.VisualScripting;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;

    static private Vector2 cursorHotspot = Vector2.zero;
    static private CursorMode cursorMode = CursorMode.Auto;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    static void ResetProperties()
    {
        cursorHotspot = Vector2.zero;
        cursorMode = CursorMode.Auto;
        Cursor.visible = true;
    }

    // Update is called once per frame
    public static void changeTo(CursorType newCursor)
    {
        Texture2D newCursorTexture;
        ResetProperties();
        switch (newCursor)
        {
            case CursorType.POINTER:
                newCursorTexture = Resources.Load<Texture2D>("Cursors/Pointer");
                break;
            case CursorType.HAND_OPEN:
                newCursorTexture = Resources.Load<Texture2D>("Cursors/Hand_Open");
                cursorHotspot.Set(newCursorTexture.width / 2, newCursorTexture.height / 2);
                break;
            case CursorType.HAND_GRAB:
                newCursorTexture = Resources.Load<Texture2D>("Cursors/Hand_Grab");
                cursorHotspot.Set(newCursorTexture.width / 2, newCursorTexture.height / 2);
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
                Cursor.visible = false;
                break;
        }

        Cursor.SetCursor(newCursorTexture, cursorHotspot, cursorMode);
    }
}
