using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionChooser : MonoBehaviour
{
    public GameObject Carnes;
    public GameObject Bebidas;
    public GameObject MenuSelect;
    
    public GameObject BotonCarnes;
    public GameObject BotonBebidas;

    public void Return()
    {
        MenuSelect.SetActive(true);
        Carnes.SetActive(false);
        Bebidas.SetActive(false);
        BotonBebidas.SetActive(true);
        BotonCarnes.SetActive(true);
    }
    public void CarneClick()
    {
        Carnes.SetActive(true);
        Bebidas.SetActive(false);
        BotonBebidas.SetActive(false);
        BotonCarnes.SetActive(false);
        MenuSelect.SetActive(false);
    }
    public void BebidaClick()
    {
        Carnes.SetActive(false);
        Bebidas.SetActive(true);
        BotonBebidas.SetActive(false);
        BotonCarnes.SetActive(false);
        MenuSelect.SetActive(false);
    }
}
