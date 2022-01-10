using Leap.Unity;
using Leap.Unity.Interaction;
using Leap.InteractionEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UHI.Tracking.InteractionEngine.Examples
{
    [AddComponentMenu("")]
    [RequireComponent(typeof(InteractionBehaviour))]
    public class TouchEvent : MonoBehaviour
    {

        private Material[] _materials;
        private InteractionBehaviour _intObj;

        [SerializeField]
        private Rend[] rends;

        [System.Serializable]
        public class Rend
        {
            public int materialID = 0;
            public Renderer renderer;
        }

        void Start()
        {
            _intObj = GetComponent<InteractionBehaviour>();

            if (rends.Length > 0)
            {
                _materials = new Material[rends.Length];

                for (int i = 0; i < rends.Length; i++)
                {
                    _materials[i] = rends[i].renderer.materials[rends[i].materialID];
                }
            }
        }

        void Update()
        {
            //手抓取時動作
            _intObj.OnContactBegin = () =>
            {
                Destroy(transform.parent.gameObject);
                MusicSheet.comb++;
                if (MusicSheet.maxComb < MusicSheet.comb) MusicSheet.maxComb = MusicSheet.comb;
                MusicSheet.hit++;
                MusicSheet.iscomb = true;
                MusicSheet.ismiss = false;
            };

            //手覆蓋的時候做動作，可以隔一段距離
            if (_intObj.isHovered)
            {
                //Destroy(gameObject);
            }
        }

    }
}