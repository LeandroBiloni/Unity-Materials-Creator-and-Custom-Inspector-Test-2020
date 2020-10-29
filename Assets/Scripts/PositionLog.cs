using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class PositionLog : MonoBehaviour
{
    public float distance;
    public List<Vector3> positions = new List<Vector3>();
    private Vector3 _previousPos;
    public Player player;
    // Start is called before the first frame update
    public void Start()
    {
        player = GetComponent<Player>();
        _previousPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RegisterPosition();
    }


    //Guardo las posiciones para poder usarlas despues
    private void RegisterPosition()
    {
        if ((transform.position - _previousPos).magnitude > distance)
        {
            positions.Add(transform.position);
            _previousPos = transform.position;
        }
            
    }
}
