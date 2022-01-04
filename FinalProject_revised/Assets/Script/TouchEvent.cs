using Leap.Unity;
using Leap.Unity.Interaction;
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
            //�����ɰʧ@
            if (_intObj.isGrasped)
            {
                Destroy(gameObject);
                MusicSheet.comb++;
                if (MusicSheet.maxComb < MusicSheet.comb) MusicSheet.maxComb = MusicSheet.comb;
                MusicSheet.hit++;
                MusicSheet.iscomb = true;
                MusicSheet.ismiss = false;
            }

            //���л\���ɭ԰��ʧ@�A�i�H�j�@�q�Z��
            if (_intObj.isHovered)
            {
                //Destroy(gameObject);
            }
        }

    }
}