using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade_BlackOut : MonoBehaviour
{
    public GameObject Fade;
    [SerializeField] float speed = 0.01f;
    [SerializeField] Color color = Color.black;

    void Update() {
        if (Input.GetKeyUp(KeyCode.O)) StartCoroutine(FadeOut());
        if (Input.GetKeyUp(KeyCode.I)) StartCoroutine(FadeIn());
    }

    /// <summary>
    /// アルファ値を下げてフェードインさせるコールチン
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeIn() {
        Fade.SetActive(true);   //フェード対象のオブジェクトをアクティブ状態にする

        //アルファ値が0以下になるまで毎フレーム、フェードさせる
        for(float alfa=1.0f; alfa >= 0; alfa -= speed + speed * alfa){
            color[3] = alfa;
            Fade.GetComponent<Image>().color = color;
            yield return new WaitForEndOfFrame();
        }

        //フェード対象のオブジェクトを非アクティブ状態にする
        //非アクティブ状態にしないとボタンが押せないなどの問題が発生してしまう
        Fade.SetActive(false);
    }
    /// <summary>
    /// アルファ値をあげてフェードアウトさせるコールチン
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeOut() {
        //フェード対象のオブジェクトをアクティブ状態にする
        Fade.SetActive(true);

        //アルファ値が0以下になるまで毎フレーム、フェードさせる
        for (float alfa = 0; alfa <= 1.0f; alfa += speed + speed * alfa) {
            color[3] = alfa;
            Fade.GetComponent<Image>().color = color;
            yield return new WaitForEndOfFrame();
        }
    }
}