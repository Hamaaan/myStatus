using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePicForShare : MonoBehaviour
{
    [SerializeField] ShareButton shareButton;

    // Start is called before the first frame update
    void Start()
    {
        shareButton = shareButton.GetComponent<ShareButton>();
    }

    private void OnEnable()
    {
        Invoke("Take", 0.5f);
    }

    public void Take()
    {
        shareButton.Take();
    }
}
