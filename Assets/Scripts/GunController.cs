using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private Rigidbody2D _body2D;
    [SerializeField] private Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        _body2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //_body2D.transform.position = playerRb.transform.position;
        AimAtMouse();
    }

    private void AimAtMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;

       
    }
}
