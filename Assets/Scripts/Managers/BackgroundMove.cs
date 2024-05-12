using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMove : MonoBehaviour
    {
    [SerializeField] private RawImage Background;
        [SerializeField] private float x;
        [SerializeField] private float y;


        private void Update()
        {
            Background.uvRect = new Rect(Background.uvRect.position + new Vector2(x, y) * Time.deltaTime, Background.uvRect.size);
        }

        public void ChangeBackgroundSpeed(float x, float y)
        {
            x = this.x;
            y = this.y;
        }
    }

