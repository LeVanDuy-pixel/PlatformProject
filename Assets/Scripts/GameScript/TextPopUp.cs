using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPopUp : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Color textColor;
    public float changeInterval = 1f;
    private float disappearTimer = 5f;
    private float fadeOutSpeed=1f;
    public float moveDistanceMax = 3f;

    [SerializeField] private Color[] colors;
    //[SerializeField] private static Transform textMesh;

    //public static TextPopUp PopUp(Vector3 position)
    //{
    //    Transform textPopUpTransform = Instantiate(textMesh, position, Quaternion.identity);
    //    TextPopUp textPopUp = textPopUpTransform.GetComponent<TextPopUp>();
    //    return textPopUp;
    //}
    private void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
        textColor = textMesh.color;
        StartCoroutine(ChangeTextColor());
    }


    private void Update()
    {
        transform.position += new Vector3(0, 3f) * Time.deltaTime;
        //    disappearTimer -= Time.deltaTime;
        //    if(disappearTimer < 0f)
        //    {
        //        float disappearSpeed = 3f;
        //        textColor.a -= disappearSpeed * Time.deltaTime;
        //        textMesh.color = textColor;
        //        if(textColor.a < 0f)
        //        {
        //            Destroy(gameObject);
        //        }
        //    }
        }
        private IEnumerator ChangeTextColor()
    {
        while(true)
        {
            Color startColor = textMesh.color;
            Color endColor = colors[Random.Range(0, colors.Length)];

            float elapsedTime = 0f;
            

            while (elapsedTime < changeInterval)
            {
                textColor = Color.Lerp(startColor, endColor, elapsedTime / changeInterval);
                textMesh.color = textColor;
               
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            
            //while(moveDistance < moveDistanceMax){
            //    transform.position += new Vector3(0, 2f) * Time.deltaTime;
            //    moveDistance += Time.deltaTime;
            //    yield return null;
            //}
            yield return new WaitForSeconds(disappearTimer);
            while (textColor.a > 0f)
            {
                textColor.a -= fadeOutSpeed * Time.deltaTime;
                textMesh.color = textColor;
                yield return null;
            }
            Destroy(gameObject);
        
        }
       
            
        
    }
}
