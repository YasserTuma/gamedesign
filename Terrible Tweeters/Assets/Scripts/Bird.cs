using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
	[SerializeField] float _launchForce = 500;
	[SerializeField] float _maxDragDistance = 5;

	Vector2 _startPosition;
	Rigidbody2D _rigidbody2D;

	void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

    // Start is called before the first frame update
    void Start()
    {
    	Debug.Log("started");
    	_startPosition = _rigidbody2D.position;
        _rigidbody2D.isKinematic = true;
    }

    void onMouseDown()
    {
    	//Debug.Log("down");
    	GetComponent<SpriteRenderer>().color = Color.red;
    }

    void onMouseUp()
    {
    	Vector2 currentPosition = _rigidbody2D.position;
    	Vector2 direction = _startPosition - currentPosition;
    	direction.Normalize();

        _rigidbody2D.isKinematic = false;
    	_rigidbody2D.AddForce(direction * _launchForce);

        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<Collider2D>().isTrigger = false;
    }

    void onMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = mousePosition;

        float distance = Vector2.Distance(desiredPosition, _startPosition);
        if(distance > _maxDragDistance)
        {
        	Vector2 direction = desiredPosition - _startPosition;
        	direction.Normalize();
        	desiredPosition = _startPosition + (direction * _maxDragDistance);
        }

		if(desiredPosition.x > _startPosition.x)
        	desiredPosition.x = _startPosition.x;

        _rigidbody2D.position = desiredPosition;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButtonDown(0))
         {
            onMouseDown();
            onMouseDrag();
         }

         if (Input.GetMouseButtonUp(0))
         {
            onMouseUp();
         }
         if (Input.GetMouseButton(0))
         {
            onMouseDrag();
         }
         
         
    }
	void OnCollisionEnter2D(Collision2D collision)
    {
    	StartCoroutine(ResetAfterDelay());
    }

    IEnumerator ResetAfterDelay()
    {
    	yield return new WaitForSeconds(3);
    	_rigidbody2D.position = _startPosition;
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
