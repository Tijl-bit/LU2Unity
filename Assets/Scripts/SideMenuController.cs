using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SideMenuController : MonoBehaviour
{
    public GameObject sideMenu;  // The panel containing the side menu
    public Button toggleButton;  // The button used to toggle the menu
    private bool isMenuOpen = false;

    private CanvasGroup menuCanvasGroup;  // To control menu opacity
    private RectTransform menuRectTransform;  // The RectTransform of the side menu
    private float menuWidth = 400f;  // Width of the side menu (adjust according to your design)
    private float menuSpeed = 10f;  // Speed of sliding the menu

    void Start()
    {
        // Initialize CanvasGroup and RectTransform
        menuCanvasGroup = sideMenu.GetComponent<CanvasGroup>();
        if (menuCanvasGroup == null)
        {
            menuCanvasGroup = sideMenu.AddComponent<CanvasGroup>();
        }

        menuRectTransform = sideMenu.GetComponent<RectTransform>();

        // Set the side menu off-screen to the right (hidden position), adjusted 130 units to the left
        menuRectTransform.anchoredPosition = new Vector2(360, 0);  // Moved left (was 519)
        menuCanvasGroup.alpha = 0;

        // Add hover effect to the button
        EventTrigger trigger = toggleButton.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entryEnter = new EventTrigger.Entry();
        entryEnter.eventID = EventTriggerType.PointerEnter;
        entryEnter.callback.AddListener((data) => { OnHover(true); });
        trigger.triggers.Add(entryEnter);

        EventTrigger.Entry entryExit = new EventTrigger.Entry();
        entryExit.eventID = EventTriggerType.PointerExit;
        entryExit.callback.AddListener((data) => { OnHover(false); });
        trigger.triggers.Add(entryExit);

        // Add click event to toggle the menu
        toggleButton.onClick.AddListener(ToggleMenu);
    }

    void ToggleMenu()
    {
        // Toggle menu open/close (shifted left by 130)
        isMenuOpen = !isMenuOpen;
        StopAllCoroutines();
        StartCoroutine(SmoothMove(isMenuOpen ? 117 : 305, isMenuOpen ? 1 : 0));
    }

    void OnHover(bool isHovering)
    {
        // Fade the button on hover
        Color color = toggleButton.image.color;
        color.a = isHovering ? 0.5f : 1f;  // Set opacity to 50% when hovered
        toggleButton.image.color = color;
    }

    System.Collections.IEnumerator SmoothMove(float targetX, float targetAlpha)
    {
        // Smoothly move the side menu and fade its alpha
        while (Mathf.Abs(menuRectTransform.anchoredPosition.x - targetX) > 0.01f)
        {
            float newX = Mathf.Lerp(menuRectTransform.anchoredPosition.x, targetX, Time.deltaTime * menuSpeed);
            menuRectTransform.anchoredPosition = new Vector2(newX, menuRectTransform.anchoredPosition.y);

            menuCanvasGroup.alpha = Mathf.Lerp(menuCanvasGroup.alpha, targetAlpha, Time.deltaTime * menuSpeed);
            yield return null;
        }

        // Final position and opacity
        menuRectTransform.anchoredPosition = new Vector2(targetX, menuRectTransform.anchoredPosition.y);
        menuCanvasGroup.alpha = targetAlpha;
    }
}
