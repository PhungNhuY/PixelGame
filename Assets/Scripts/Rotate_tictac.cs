using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_tictac : MonoBehaviour
{
    [SerializeField] float limit;
    [SerializeField] float speed;
    [SerializeField]float start;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        time += start;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, limit * Mathf.Sin(time));
        time += Time.deltaTime * speed;
    }
}
