using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public GameObject cannon;
    public GameObject distanceText;
    public GameObject inputVelocity;
    public GameObject inputHeight;
    public float launchVelocity;
    public float launchHeight;
    [SerializeField] GameObject submitPanel;
    [SerializeField] GameObject distancePanel;
    [SerializeField] AudioClip shootingAudio;
    public Camera mainCamera;

    public void Store()
    {
        if (inputHeight != null && inputVelocity != null && inputHeight.GetComponent<Text>() != null && inputVelocity.GetComponent<Text>() != null)
        {
            launchHeight = float.Parse(inputHeight.GetComponent<Text>().text);
           

            launchVelocity = float.Parse(inputVelocity.GetComponent<Text>().text);

            Vector3 newPosition = new Vector3(cannon.transform.position.x, launchHeight, cannon.transform.position.z);
            cannon.transform.position = newPosition;

            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, launchHeight, mainCamera.transform.position.z);

            submitPanel.SetActive(!submitPanel.activeInHierarchy);
        }
        else
        {
            Debug.LogWarning("Input fields are not assigned or are missing Text components.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            submitPanel.SetActive(!submitPanel.activeInHierarchy); 
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ball = Instantiate(projectile, transform.position,
                                                     transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                (0, 0, launchVelocity));
            AudioManager.instance.Play(shootingAudio);
            float time = Mathf.Sqrt(2 * launchHeight / 9.8f);
            float distance = launchVelocity * time;

            distancePanel.SetActive(!distancePanel.activeInHierarchy);
            Debug.Log("Distance: " + distance + " m");
            if (distanceText != null)
            {
                distanceText.GetComponent<Text>().text = distance.ToString() + " m";
                Debug.Log("Text updated");
            }
            else
            {
                Debug.LogWarning("distanceText is not assigned.");
            }
        }
    }
}
