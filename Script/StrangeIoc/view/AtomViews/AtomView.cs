using System.Collections.Generic;
using Assets.Script.StrangeIoc.controller.AtomsCommands;
using Assets.Script.StrangeIoc.model.Atoms;
using Assets.Script.StrangeIoc.model.Chapters;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.StrangeIoc.view.AtomViews
{
    public class AtomView : View {
        //元素预制体
        public GameObject atomPrefab;
        public Transform atomRectTransformParent;

        public Text ChineseName;
        public Text EnglishName;
        public Text ElementSymbol;
        public Text AtomNumber;
        public Text RelativeAtomMass;
        public Text PhysicalProperty;
        public Text ImportantKnowledge;
        public Text AtomIntroduction;
        //点击元素图片获取元素信息
        public Signal<string,string> signal=new Signal<string,string>();

        private List<Atom> atomList = null;
        private Atom targetAtom = null;
        private string path = null;

        protected override void Start()
        {
            base.Start();
            signal.Dispatch(AtomEvent.GetAllAtoms,null);
        }
        void Update () {
            if ( atomList!= null)
            {
                OnLoadAtomsSync();
                atomList = null;
            }

            if (targetAtom != null)
            {
                OnAtomBtnClickResponseSync();
            }

        }

        public void OnLoadAtoms(List<Atom> atomList)
        {
            this.atomList = atomList;
            AtomData.atomList = atomList;
        }

        /// <summary>
        /// 场景加载后立即调用，显示所有的元素
        /// </summary>
        private void OnLoadAtomsSync()
        {
            //清空元素panel中的元素
            for (int i = 0; i < atomRectTransformParent.childCount; i++)
            {
                Destroy(atomRectTransformParent.GetChild(i).gameObject);
            }
            //加载从数据库获取的元素
            foreach (var atom in atomList)
            {
                path = "AtomTextures/"+atom.AtomNumber;
                GameObject go = Instantiate(atomPrefab);
                go.transform.SetParent(atomRectTransformParent);
                go.transform.localScale = Vector3.one;
                Texture2D image =Resources.Load<Texture2D>(path);
                go.GetComponent<Image>().sprite = Sprite.Create(image, new Rect(0, 0, image.width, image.height), new Vector2(0.5f, 0.5f));
                go.name = atom.AtomName;
                go.GetComponent<Button>().onClick.AddListener(OnAtomBtnClick);
            }
        }

        /// <summary>
        /// 点击元素响应事件
        /// </summary>
        private void OnAtomBtnClick()
        {
            signal.Dispatch(AtomEvent.GetAtom,ButtonEvent.AtomName);
        }

        /// <summary>
        /// 点击元素请求数据库，回应事件
        /// </summary>
        /// <param name="atom"></param>
        public void OnAtomBtnClickResponse(Atom atom)
        {
            Debug.Log(atom);
            this.targetAtom = atom;
        }

        private void OnAtomBtnClickResponseSync()
        {
            ChineseName.text=targetAtom.AtomName;
            EnglishName.text=targetAtom.AtomEnglishName;
            ElementSymbol.text=targetAtom.AtomSymbol;
            AtomNumber.text=targetAtom.AtomNumber.ToString();
            RelativeAtomMass.text= targetAtom.RelativeAtomMass.ToString();
            PhysicalProperty.text=targetAtom.PhysicalProperty;
            ImportantKnowledge.text=targetAtom.ImportantKnowledge;
            AtomIntroduction.text=targetAtom.AtomIntroduction;
        }
    }
}
