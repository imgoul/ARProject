using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Script.Main
{
    public class MainUimanager : MonoBehaviour {

        public static bool IsARscene = false;
	

        public void Periodic()//元素周期表场景
        {
            SceneManager.LoadScene(2);
        }
        public void Molecule3D()
        {
            SceneManager.LoadScene(4);
        }
        public void MoleculeAR()
        {
            SceneManager.LoadScene(3);
            IsARscene = true;
        }
        public void Modeledit()
        {
            SceneManager.LoadScene(1);
        }
        public void Video()
        {
            SceneManager.LoadScene(6);
        }
        public void TestKu()//试题库
        {
            SceneManager.LoadScene(5);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
