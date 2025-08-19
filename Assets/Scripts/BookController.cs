using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookController : MonoBehaviour
{
    public GameObject bookClosedGroup;
    public GameObject bookOpenGroup;
    public Transform telePoints;
    public GameObject playerGO;
    public GameObject uiButtons;
    public GameObject uiDescriptions;
    public Image uiDescImage;
    public TMP_Text uiDescTextbox;
    void Start()
    {
        Debug.Log("Book controller active");
    }

    public void OnFocus()
    {
        Debug.Log("On focus...");
    }

    public void OnSelect()
    {
        bookClosedGroup.SetActive(false);
        bookOpenGroup.SetActive(true);
    }

    public void OnDeselect()
    {
        bookClosedGroup.SetActive(true);
        bookOpenGroup.SetActive(false);
    }

    public void OnConfirmClick(int index)
    {
        Debug.Log("onclick");
        playerGO.transform.position = telePoints.GetChild(index).position;
    }

    public void OnPersonClick(DescriptionScriptable desc)
    {
        if (bookOpenGroup.activeSelf)
        {
            OpenDescription(desc);
        }
        else
        {
            Debug.Log("book closed");
        }
    }

    private void OpenDescription(DescriptionScriptable desc)
    {
        uiButtons.SetActive(false);
        uiDescriptions.SetActive(true);
        uiDescImage.sprite = desc.image;
        uiDescTextbox.text = desc.descText;
    }

    public void CloseDescription()
    {
        uiButtons.SetActive(true);
        uiDescriptions.SetActive(false);
    }
}
