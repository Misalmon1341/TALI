using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trancisionescena : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip animacionFinal;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public IEnumerator CambiarEscena()
    {
        animator.SetTrigger("Inicializar");

        yield return new WaitForSeconds(animacionFinal.length);
        SceneManager.LoadScene("2JeremyPov");
    }

}
