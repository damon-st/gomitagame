using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualGame : MonoBehaviour
{

    public GameObject panelManual;
    private string guardado;


    public GameObject sonidoConfiguracion;

    // Start is called before the first frame update
    void Start()
    {
        guardado = GuardarNiveles.CargarManual("manual");

        if (guardado.Equals("si"))
        {
            panelManual.SetActive(false);
        }
    }

    public void GuardarManual()
    {
        GuardarNiveles.GuardarManual("si");
        panelManual.SetActive(false);
    }

    public void OpenManual()
    {
        panelManual.SetActive(true);
    }

    public void OpenSonido()
    {
        sonidoConfiguracion.SetActive(true);
    }

    public void CloseSonido()
    {
        sonidoConfiguracion.SetActive(false);

    }
}
