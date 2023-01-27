using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private RectTransform playerField;
    [SerializeField] private Transform topTransform;
    [SerializeField] private Transform bottomTransform;

    private GameObject topField;
    private GameObject bottomField;

    private bool isPinnedTop;
    private bool isPinnedBottom;

    private VerticalLayoutGroup verticalLayout;

    private void Start()
    {
        verticalLayout = content.GetComponent<VerticalLayoutGroup>();
        topField = Instantiate(playerField.gameObject, topTransform.position, Quaternion.identity,topTransform);
        bottomField= Instantiate(playerField.gameObject, bottomTransform.position ,Quaternion.identity,bottomTransform);
        topField.gameObject.SetActive(false);
        bottomField.gameObject.SetActive(false);
    }
    public void PinPlayerField()
    {
        if (playerField.position.y >= topTransform.position.y)
        {
            verticalLayout.enabled = false;
            playerField.gameObject.SetActive(false);
            topField.gameObject.SetActive(true);
            isPinnedTop = true;
        }
        else if (playerField.position.y < topTransform.position.y && isPinnedTop)
        {
            verticalLayout.enabled = true;
            playerField.gameObject.SetActive(true);
            topField.gameObject.SetActive(false);
            isPinnedTop = false;
        }

        if (playerField.position.y >= bottomTransform.position.y && isPinnedBottom)
        {
            verticalLayout.enabled = true;
            playerField.gameObject.SetActive(true);
            bottomField.gameObject.SetActive(false);
            isPinnedBottom = false;
        }
        else if (playerField.position.y < bottomTransform.position.y)
        {
            verticalLayout.enabled = false;
            playerField.gameObject.SetActive(false);
            bottomField.gameObject.SetActive(true);
            isPinnedBottom = true;
        }
    }
}
