using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void ControllerDelegate(char letter);
    public static event ControllerDelegate OnKeyPress;

    public delegate void ConditionDelegate();
    public static event ConditionDelegate OnKeyDelete;
    public static event ConditionDelegate OnSuccess;
    public static event ConditionDelegate OnError;
    public static event ConditionDelegate OnRepeat;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && OnKeyPress != null) OnKeyPress('a');
        if (Input.GetKeyDown(KeyCode.B) && OnKeyPress != null) OnKeyPress('b');
        if (Input.GetKeyDown(KeyCode.C) && OnKeyPress != null) OnKeyPress('c');
        if (Input.GetKeyDown(KeyCode.D) && OnKeyPress != null) OnKeyPress('d');
        if (Input.GetKeyDown(KeyCode.E) && OnKeyPress != null) OnKeyPress('e');
        if (Input.GetKeyDown(KeyCode.F) && OnKeyPress != null) OnKeyPress('f');
        if (Input.GetKeyDown(KeyCode.G) && OnKeyPress != null) OnKeyPress('g');
        if (Input.GetKeyDown(KeyCode.H) && OnKeyPress != null) OnKeyPress('h');
        if (Input.GetKeyDown(KeyCode.I) && OnKeyPress != null) OnKeyPress('i');
        if (Input.GetKeyDown(KeyCode.J) && OnKeyPress != null) OnKeyPress('j');
        if (Input.GetKeyDown(KeyCode.K) && OnKeyPress != null) OnKeyPress('k');
        if (Input.GetKeyDown(KeyCode.L) && OnKeyPress != null) OnKeyPress('l');
        if (Input.GetKeyDown(KeyCode.M) && OnKeyPress != null) OnKeyPress('m');
        if (Input.GetKeyDown(KeyCode.N) && OnKeyPress != null) OnKeyPress('n');
        if (Input.GetKeyDown(KeyCode.O) && OnKeyPress != null) OnKeyPress('o');
        if (Input.GetKeyDown(KeyCode.P) && OnKeyPress != null) OnKeyPress('p');
        if (Input.GetKeyDown(KeyCode.Q) && OnKeyPress != null) OnKeyPress('q');
        if (Input.GetKeyDown(KeyCode.R) && OnKeyPress != null) OnKeyPress('r');
        if (Input.GetKeyDown(KeyCode.S) && OnKeyPress != null) OnKeyPress('s');
        if (Input.GetKeyDown(KeyCode.T) && OnKeyPress != null) OnKeyPress('t');
        if (Input.GetKeyDown(KeyCode.U) && OnKeyPress != null) OnKeyPress('u');
        if (Input.GetKeyDown(KeyCode.V) && OnKeyPress != null) OnKeyPress('v');
        if (Input.GetKeyDown(KeyCode.W) && OnKeyPress != null) OnKeyPress('w');
        if (Input.GetKeyDown(KeyCode.X) && OnKeyPress != null) OnKeyPress('x');
        if (Input.GetKeyDown(KeyCode.Y) && OnKeyPress != null) OnKeyPress('y');
        if (Input.GetKeyDown(KeyCode.Z) && OnKeyPress != null) OnKeyPress('z');

        if (Input.GetKeyDown(KeyCode.Backspace) && OnKeyDelete != null) OnKeyDelete();

        if (Input.GetKeyDown(KeyCode.Return) && OnSuccess != null) OnSuccess();
        if (Input.GetKeyDown(KeyCode.LeftControl) && OnError != null) OnError();
        if (Input.GetKeyDown(KeyCode.Space) && OnRepeat != null) OnRepeat();
    }
}
