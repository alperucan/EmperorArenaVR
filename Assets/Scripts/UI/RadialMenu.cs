using UnityEngine;

    public class RadialMenu : BaseUI
    {
        [SerializeField] private float radius = 360f;

        [ContextMenu("Setup")]
        public void Setup()
        {
            float radians = Mathf.PI * 2 / transform.childCount;
            for (int i = 0; i < transform.childCount; i++)
            {
                float x = Mathf.Sin(radians * i) * radius;
                
                float y = Mathf.Cos(radians * i) * radius;

                transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            }

        }
    }
