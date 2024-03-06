using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        if (LevelManager.Instance.Run)
        {
            if (Input.GetKeyDown(KeyCode.A)) LevelManager.Instance.Enqueue('a');
            if (Input.GetKeyDown(KeyCode.B)) LevelManager.Instance.Enqueue('b');
            if (Input.GetKeyDown(KeyCode.C)) LevelManager.Instance.Enqueue('c');
            if (Input.GetKeyDown(KeyCode.D)) LevelManager.Instance.Enqueue('d');
            if (Input.GetKeyDown(KeyCode.E)) LevelManager.Instance.Enqueue('e');
            if (Input.GetKeyDown(KeyCode.F)) LevelManager.Instance.Enqueue('f');
            if (Input.GetKeyDown(KeyCode.G)) LevelManager.Instance.Enqueue('g');
            if (Input.GetKeyDown(KeyCode.H)) LevelManager.Instance.Enqueue('h');
            if (Input.GetKeyDown(KeyCode.I)) LevelManager.Instance.Enqueue('i');
            if (Input.GetKeyDown(KeyCode.J)) LevelManager.Instance.Enqueue('j');
            if (Input.GetKeyDown(KeyCode.K)) LevelManager.Instance.Enqueue('k');
            if (Input.GetKeyDown(KeyCode.L)) LevelManager.Instance.Enqueue('l');
            if (Input.GetKeyDown(KeyCode.M)) LevelManager.Instance.Enqueue('m');
            if (Input.GetKeyDown(KeyCode.N)) LevelManager.Instance.Enqueue('n');
            if (Input.GetKeyDown(KeyCode.O)) LevelManager.Instance.Enqueue('o');
            if (Input.GetKeyDown(KeyCode.P)) LevelManager.Instance.Enqueue('p');
            if (Input.GetKeyDown(KeyCode.Q)) LevelManager.Instance.Enqueue('q');
            if (Input.GetKeyDown(KeyCode.R)) LevelManager.Instance.Enqueue('r');
            if (Input.GetKeyDown(KeyCode.S)) LevelManager.Instance.Enqueue('s');
            if (Input.GetKeyDown(KeyCode.T)) LevelManager.Instance.Enqueue('t');
            if (Input.GetKeyDown(KeyCode.U)) LevelManager.Instance.Enqueue('u');
            if (Input.GetKeyDown(KeyCode.V)) LevelManager.Instance.Enqueue('v');
            if (Input.GetKeyDown(KeyCode.W)) LevelManager.Instance.Enqueue('w');
            if (Input.GetKeyDown(KeyCode.X)) LevelManager.Instance.Enqueue('x');
            if (Input.GetKeyDown(KeyCode.Y)) LevelManager.Instance.Enqueue('y');
            if (Input.GetKeyDown(KeyCode.Z)) LevelManager.Instance.Enqueue('z');

            if (Input.GetKeyDown(KeyCode.Backspace)) LevelManager.Instance.Dequeue();
            if (Input.GetKeyDown(KeyCode.Return)) LevelManager.Instance.Submit();
        }
    }
}
