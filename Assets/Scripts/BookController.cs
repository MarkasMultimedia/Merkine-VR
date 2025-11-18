using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookController : MonoBehaviour
{
    public SceneController sceneController;
    public GameObject bookClosedGroup;
    public GameObject bookOpenGroup;
    public Transform telePoints;
    public GameObject playerGO;
    public GameObject uiButtons;
    public GameObject uiDescriptions;
    public Image uiDescImage;
    public TMP_Text uiDescTextbox;
    public GameObject[] canvasGroups;
    private int canvasGroupIndex = 0;
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
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Invoke("SetButtonsActive", 1.0f);
    }

    private void SetButtonsActive()
    {
        if (bookOpenGroup.activeInHierarchy)
            uiButtons.SetActive(true);
    }

    public void OnDeselect()
    {
        bookClosedGroup.SetActive(true);
        bookOpenGroup.SetActive(false);
        uiButtons.SetActive(false);
    }

    public void OnConfirmClick(int index)
    {
        Debug.Log("onclick");
        playerGO.transform.position = telePoints.GetChild(index).position;
        sceneController.StartScene();
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

    public void OnNextButtonClick()
    {
        canvasGroupIndex += 1;
        if (canvasGroupIndex > 2) canvasGroupIndex = 2;
        SetupCanvasGroup();
    }

    public void OnPrevButtonClick()
    {
        canvasGroupIndex -= 1;
        if (canvasGroupIndex < 0) canvasGroupIndex = 0;
        SetupCanvasGroup();
    }

    private void SetupCanvasGroup()
    {
        foreach (GameObject canvasGroup in canvasGroups)
        {
            canvasGroup.SetActive(false);
        }
        canvasGroups[canvasGroupIndex].SetActive(true);
    }
}
