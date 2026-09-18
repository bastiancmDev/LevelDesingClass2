using System;
using Unity.VisualScripting;
using UnityEngine;

public class Calabaza : MonoBehaviour
{
    public Color color;
    public float size = 1.0f;
    public Vector3 nuevaPosicion;
    public Vector3 posicionInicial;

    public bool estaBajando = false;



    private void ApagarObjeto()
    {
        gameObject.SetActive(false);
    }

    private void ModificarTamano()
    {
        Transform esteTrasform = GetComponent <Transform>();
        esteTrasform.localScale = new Vector3(size, size, size);
    }

    private void ModificarColor()
    {
        MeshRenderer meshRenderer = GetComponent <MeshRenderer>();
        Material mat = meshRenderer.material;
        mat.color = color;
    }


    private void CambiarColoSegunDistancia()
    {
        Transform esteTransform = GetComponent<Transform>();
        if(Vector3.Distance(esteTransform.position, posicionInicial) > 5)
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            Material mat = meshRenderer.material;
            mat.color = color;
        }
        else
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            Material mat = meshRenderer.material;
            mat.color = Color.black;
        }
    }


    private void ModificarPosicion()
    {
        Transform esteTransform = GetComponent <Transform>();

        if(estaBajando)
        {
            if (esteTransform.position.y > posicionInicial.y)
            {
                esteTransform.position = new Vector3(esteTransform.position.x, esteTransform.position.y - 1, esteTransform.position.z);
                //ApagarObjeto();
            }
            else
            {
                estaBajando = false;
            }
        }
        else
        {
            if (esteTransform.position.y < 30)
            {
                esteTransform.position = new Vector3(esteTransform.position.x, esteTransform.position.y + 1, esteTransform.position.z);
            }
            else
            {
                estaBajando = true;
            }
        }

    }

    private void Awake()
    {
        size = DateTime.Now.Hour;
    }

    private void Start()
    {
        size = 4;
        Transform esteTransform = GetComponent<Transform>();
        posicionInicial = esteTransform.position;

        ModificarColor();
    }


    private void Update()
    {
        CambiarColoSegunDistancia();
        ModificarPosicion();
    }


    private void OnDestroy()
    {
        
    }
}
