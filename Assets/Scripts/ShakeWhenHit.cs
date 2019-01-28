using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeWhenHit : MonoBehaviour
{
    public GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.name.Contains("TrashAmmo") && gameObject.name == "Trashcan") || ((col.gameObject.name.Contains("Clothes") || col.gameObject.name.Contains("Pants")) && gameObject.name == "Hamper"))
        {
            Instantiate(scoreText, this.transform.position, Quaternion.identity);
            StartCoroutine("Shake");
        }
    }

    IEnumerator Shake()
    {
        float randNum = Random.Range(0f, 10f);
        Transform originalTransform = gameObject.transform;

        transform.Rotate(new Vector3(0, 0, 1f) * (20f + randNum));
        yield return new WaitForSeconds(Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, 1f) * (20f + randNum));
        yield return new WaitForSeconds(Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, -1f) * (20f + randNum));
        yield return new WaitForSeconds(Time.deltaTime);
        gameObject.transform.rotation = originalTransform.rotation;
        yield return new WaitForSeconds(Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, -1f) * (20f + randNum));
        yield return new WaitForSeconds(Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, -1f) * (20f + randNum));
        yield return new WaitForSeconds(Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, 1f) * (20f + randNum));
        yield return new WaitForSeconds(Time.deltaTime);
        gameObject.transform.rotation = originalTransform.rotation;
    }
}
