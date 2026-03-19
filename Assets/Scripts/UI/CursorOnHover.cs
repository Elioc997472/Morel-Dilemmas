using UnityEngine;

public class CursorOnHover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnHover(){
        CursorManager.changeTo(CursorType.POINTER);
    }
    public void OnExit(){
        CursorManager.changeTo(CursorType.ARROW);
    }
}
