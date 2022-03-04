using UnityEngine;
using UnityEngine.UI;

namespace Blueprint
{
    public abstract class Ruler : Blueprint<Text>
    {
        //protected virtual void Awake() => elements = new List<Text>();

        protected override void DestroyMe(Text victim) => Destroy(victim.gameObject);

    

        protected Text CreateText(Vector3 pos, int value)
        {

            GameObject pref = Instantiate(prefab, pos, Quaternion.identity, transform);
            Text txt = pref.GetComponent<Text>();
            txt.text = value.ToString();


            pref.SetActive(true);

            return txt;
        }
    }
}
