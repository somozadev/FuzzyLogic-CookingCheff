using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FuzzyLogicPCL;
using FuzzyLogicPCL.FuzzySets;
using System;
using UnityEngine.UI;
using System.Globalization;
using TMPro;
public class FuzzyDrinking : MonoBehaviour
{
    public Image imagen;
    public Sprite imagenAInsertar;
    public TMP_Text solveValue;
    public Slider SocialSelec;
    public Slider HealthSelec;
    public double SocialSelecD;
    public double HealthSelecD;

    public void Setup()
    {
        imagen.gameObject.SetActive(true);
        Health();
        Social();
        //BEBIDAS
        FuzzySystem system = new FuzzySystem("Bebedor express");
        LinguisticVariable social = new LinguisticVariable("NivelSocial", 0,18); //Nivel social de la bebida
        social.AddValue(new LinguisticValue("Nada", new LeftFuzzySet(0,18,1,3)));
        social.AddValue(new LinguisticValue("Poco", new TrapezoidalFuzzySet(0,18,2,4,6,7)));
        social.AddValue(new LinguisticValue("Media", new TrapezoidalFuzzySet(0,18,6,8,10,11)));
        social.AddValue(new LinguisticValue("Alta", new TrapezoidalFuzzySet(0,18,10,12,14,15)));
        social.AddValue(new LinguisticValue("Altisima", new RightFuzzySet(0,18,14,16)));
        system.addInputVariable(social);


        LinguisticVariable salud = new LinguisticVariable("NivelSaludable", 0,20); //Nivel saludable en comidas
        salud.AddValue(new LinguisticValue("Beneficioso",new LeftFuzzySet(0,20,1,10)));
        salud.AddValue(new LinguisticValue("Normal", new TrapezoidalFuzzySet(0,20,8,10,14,16)));
        salud.AddValue(new LinguisticValue("Dañino", new RightFuzzySet(0,20,15,19)));
        system.addInputVariable(salud);

        LinguisticVariable tipoDeBebida = new LinguisticVariable("Bebida",0,20); //Tipos de bebida
        tipoDeBebida.AddValue(new LinguisticValue("Agua", new LeftFuzzySet(0,20,1,5)));
        tipoDeBebida.AddValue(new LinguisticValue("Cocacola", new TrapezoidalFuzzySet(0,20,4,5,7,8)));
        tipoDeBebida.AddValue(new LinguisticValue("Cerveza", new TrapezoidalFuzzySet(0,20,8,9,11,12)));
        tipoDeBebida.AddValue(new LinguisticValue("Vino", new TrapezoidalFuzzySet(0,20,12,13,15,16)));
        tipoDeBebida.AddValue(new LinguisticValue("Copa", new RightFuzzySet(0,20,16,19)));
        system.addOutputVariable(tipoDeBebida);

        //REGLAS DIFUSAS DE LA CARNE 
        
        
        system.addFuzzyRule("IF NivelSaludable IS Dañino AND nivelSocial IS Nada THEN Bebida IS Cocacola");
        system.addFuzzyRule("IF NivelSaludable IS Dañino AND nivelSocial IS Poco THEN Bebida IS Cocacola");
        system.addFuzzyRule("IF NivelSaludable IS Dañino AND nivelSocial IS Media THEN Bebida IS Vino");
        system.addFuzzyRule("IF NivelSaludable IS Dañino AND nivelSocial IS Alta THEN Bebida IS Cerveza");
        system.addFuzzyRule("IF NivelSaludable IS Dañino AND nivelSocial IS Altisima THEN Bebida IS Copa");
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        system.addFuzzyRule("IF NivelSaludable IS Normal AND nivelSocial IS Nada THEN Bebida IS Cocacola");
        system.addFuzzyRule("IF NivelSaludable IS Normal AND nivelSocial IS Poco THEN Bebida IS Cocacola");
        system.addFuzzyRule("IF NivelSaludable IS Normal AND nivelSocial IS Media THEN Bebida IS Cerveza");
        system.addFuzzyRule("IF NivelSaludable IS Normal AND nivelSocial IS Alta THEN Bebida IS Cerveza");
        system.addFuzzyRule("IF NivelSaludable IS Normal AND nivelSocial IS Altisima THEN Bebida IS Vino");
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        system.addFuzzyRule("IF NivelSaludable IS Beneficioso AND nivelSocial IS Nada THEN Bebida IS Agua");
        system.addFuzzyRule("IF NivelSaludable IS Beneficioso AND nivelSocial IS Poco THEN Bebida IS Agua");
        system.addFuzzyRule("IF NivelSaludable IS Beneficioso AND nivelSocial IS Media THEN Bebida IS Agua");
        system.addFuzzyRule("IF NivelSaludable IS Beneficioso AND nivelSocial IS Alta THEN Bebida IS Vino");
        system.addFuzzyRule("IF NivelSaludable IS Beneficioso AND nivelSocial IS Altisima THEN Bebida IS Cerveza");

        //CASOS
        system.SetInputVariable(social,SocialSelecD);
        system.SetInputVariable(salud,HealthSelecD);
        
        Debug.Log(system.Solve());
        ChooseImage(system.Solve());
        system.ResetCase();
    }

    public void Social()
    {
       SocialSelecD = SocialSelec.value;
    }
    public void Health()
    {
       HealthSelecD = HealthSelec.value;
    }
    void ChooseImage(double result)
    {
        solveValue.text = Convert.ToString(result);
        if(result >= 1 && result <= 5)
        {
            imagenAInsertar = Resources.Load<Sprite>("Agua");
            imagen.sprite = imagenAInsertar;
        }
        if(result > 4 && result < 7)
        {
            imagenAInsertar = Resources.Load<Sprite>("Cocacola");
            imagen.sprite = imagenAInsertar;
        }
        if(result > 8 && result < 11)
        {
            imagenAInsertar = Resources.Load<Sprite>("Cerveza");
            imagen.sprite = imagenAInsertar;
        }
        if(result > 12 && result < 15)
        {
            imagenAInsertar = Resources.Load<Sprite>("Vino");
            imagen.sprite = imagenAInsertar;
        }
        if(result >= 16)
        {
            imagenAInsertar = Resources.Load<Sprite>("Copa");
            imagen.sprite = imagenAInsertar;
        }
        
    }


}
