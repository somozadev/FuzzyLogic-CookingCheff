using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FuzzyLogicPCL;
using FuzzyLogicPCL.FuzzySets;
using System;
using UnityEngine.UI;
using System.Globalization;
using TMPro;

public class FuzzyKitchen : MonoBehaviour
{
        public double textotiempoD;
        public double textotemperaturaD;
        public Image imagen;
        public Sprite imagenAInsertar;
        public TMP_Text text;
        public TMP_Text solveValue;
    // Start is called before the first frame update
    public void Setup()
    {
        imagen.gameObject.SetActive(true);
        //CARNE 
        FuzzySystem system = new FuzzySystem("Cocinero express");
        LinguisticVariable temp = new LinguisticVariable("Temperatura", 0,10); //Temperatura en valores de la placa
        temp.AddValue(new LinguisticValue("Baja", new LeftFuzzySet(0,10,1,5)));
        temp.AddValue(new LinguisticValue("Media", new TrapezoidalFuzzySet(0,10,4,6,7,8)));
        temp.AddValue(new LinguisticValue("Alta", new RightFuzzySet(0,10,7,9)));
        system.addInputVariable(temp);


        LinguisticVariable coockingTime = new LinguisticVariable("Tiempo", 0,20); //Tiempo de cocción en minutos
        coockingTime.AddValue(new LinguisticValue("Poco",new LeftFuzzySet(0,20,1,3.5)));
        coockingTime.AddValue(new LinguisticValue("Normal", new TrapezoidalFuzzySet(0,20,2,6,9,15)));
        coockingTime.AddValue(new LinguisticValue("Mucho", new RightFuzzySet(0,20,10,18)));
        system.addInputVariable(coockingTime);

        LinguisticVariable LevelMeatCoocked = new LinguisticVariable("Carne",0,22); //Nivel de cocción
        LevelMeatCoocked.AddValue(new LinguisticValue("Cruda", new LeftFuzzySet(0,22,1,3)));
        LevelMeatCoocked.AddValue(new LinguisticValue("Inglesa", new TrapezoidalFuzzySet(0,22,2,3,5,6)));
        LevelMeatCoocked.AddValue(new LinguisticValue("PocoHecha", new TrapezoidalFuzzySet(0,22,5,6,8,9)));
        LevelMeatCoocked.AddValue(new LinguisticValue("AlPunto", new TrapezoidalFuzzySet(0,22,8,9,11,12)));
        LevelMeatCoocked.AddValue(new LinguisticValue("PuntoPasado", new TrapezoidalFuzzySet(0,22,11,12,14,15)));
        LevelMeatCoocked.AddValue(new LinguisticValue("Hecha", new TrapezoidalFuzzySet(0,22,14,15,17,18)));
        LevelMeatCoocked.AddValue(new LinguisticValue("MuyHecha", new TrapezoidalFuzzySet(0,22,17,18,20,21)));
        LevelMeatCoocked.AddValue(new LinguisticValue("Quemada", new RightFuzzySet(0,22,20,21)));
        system.addOutputVariable(LevelMeatCoocked);

        //REGLAS DIFUSAS DE LA CARNE 
        
        system.addFuzzyRule("IF Temperatura IS Baja AND Tiempo IS Poco THEN Carne IS Cruda");
        system.addFuzzyRule("IF Temperatura IS Baja AND Tiempo IS Normal THEN Carne IS Inglesa");
        system.addFuzzyRule("IF Temperatura IS Baja AND Tiempo IS Mucho THEN Carne IS PocoHecha");
        ///////////////////////////////////////////////////////////////////////////////////////////
        system.addFuzzyRule("IF Temperatura IS Media AND Tiempo IS Poco THEN Carne IS PocoHecha");
        system.addFuzzyRule("IF Temperatura IS Media AND Tiempo IS Normal THEN Carne IS AlPunto");
        system.addFuzzyRule("IF Temperatura IS Media AND Tiempo IS Mucho THEN Carne IS PuntoPasado");
        ///////////////////////////////////////////////////////////////////////////////////////////
        system.addFuzzyRule("IF Temperatura IS Alta AND Tiempo IS Poco THEN Carne IS Hecha");
        system.addFuzzyRule("IF Temperatura IS Alta AND Tiempo IS Normal THEN Carne IS MuyHecha");
        system.addFuzzyRule("IF Temperatura IS Alta AND Tiempo IS Mucho THEN Carne IS Quemada");


        //CASOS
        system.SetInputVariable(temp,textotemperaturaD);
        system.SetInputVariable(coockingTime,textotiempoD);
        
        Debug.Log(system.Solve());
        ChooseImage(system.Solve());
        system.ResetCase();
    }
    
    void ChooseImage(double result)
    {
        solveValue.text = Convert.ToString(result);
        if(result >= 0 && result <= 3)
        {
            imagenAInsertar = Resources.Load<Sprite>("Cruda");
            imagen.sprite = imagenAInsertar;
            text.text = "Cruda";
            
        }
        if(result > 3 && result < 5)
        {
            imagenAInsertar = Resources.Load<Sprite>("ALaInglesa");
            imagen.sprite = imagenAInsertar;
            text.text = "A La Inglesa";
        }
        if(result > 6 && result < 8)
        {
            imagenAInsertar = Resources.Load<Sprite>("PocoHecha");
            imagen.sprite = imagenAInsertar;
            text.text = "Poco Hecha";
        }
        if(result > 9 && result < 11)
        {
            imagenAInsertar = Resources.Load<Sprite>("AlPunto");
            imagen.sprite = imagenAInsertar;
            text.text = "Al Punto";
        }
        if(result > 12 && result < 14)
        {
            imagenAInsertar = Resources.Load<Sprite>("PuntoPasado");
            imagen.sprite = imagenAInsertar;
            text.text = "Punto Pasado";
        }
        if(result > 15 && result < 17)
        {
            imagenAInsertar = Resources.Load<Sprite>("Hecho");
            imagen.sprite = imagenAInsertar;
            text.text = "Hecha";
        }
        if(result > 18 && result < 20)
        {
            imagenAInsertar = Resources.Load<Sprite>("MuyHecho");
            imagen.sprite = imagenAInsertar;
            text.text = "Muy Hecha";
        }
        if(result >= 20.00000001f)
        {
            imagenAInsertar = Resources.Load<Sprite>("Quemada");
            imagen.sprite = imagenAInsertar;
            text.text = "Quemada";
        }
    }




    #region TEMP NUMBERS
    public void temp0()
    {
        textotemperaturaD = 0;
    }
    public void temp1()
    {
        textotemperaturaD = 1;
    }
    public void temp2()
    {
        textotemperaturaD = 2;
    }
    public void temp3()
    {
        textotemperaturaD = 3;
    }
    public void temp4()
    {
        textotemperaturaD = 4;
    }
    public void temp5()
    {
        textotemperaturaD = 5;
    }
    public void temp6()
    {
        textotemperaturaD = 6;
    }
    public void temp7()
    {
        textotemperaturaD = 7;
    }
    public void temp8()
    {
        textotemperaturaD = 8;
    }
    public void temp9()
    {
        textotemperaturaD = 9;
    }
    public void temp10()
    {
        textotemperaturaD = 10;
    }
    #endregion
    #region TIME NUMBERS
    public void time0()
    {
        textotiempoD = 0;
    }
    public void time1()
    {
        textotiempoD = 1;
    }
    public void time2()
    {
        textotiempoD = 2;
    }
    public void time3()
    {
        textotiempoD = 3;
    }
    public void time4()
    {
        textotiempoD = 4;
    }
    public void time5()
    {
        textotiempoD = 5;
    }
    public void time6()
    {
        textotiempoD = 6;
    }
    public void time7()
    {
        textotiempoD = 7;
    }
    public void time8()
    {
        textotiempoD = 8;
    }
    public void time9()
    {
        textotiempoD = 9;
    }
    public void time10()
    {
        textotiempoD = 10;
    }
    public void time11()
    {
        textotiempoD = 11;
    }
    public void time12()
    {
        textotiempoD = 12;
    }
    public void time13()
    {
        textotiempoD = 13;
    }
    public void time14()
    {
        textotiempoD = 14;
    }
    public void time15()
    {
        textotiempoD = 15;
    }
    public void time16()
    {
        textotiempoD = 16;
    }
    public void time17()
    {
        textotiempoD = 17;
    }
    public void time18()
    {
        textotiempoD = 18;
    }
    public void time19()
    {
        textotiempoD = 19;
    }
    public void time20()
    {
        textotiempoD = 20;
    }
    #endregion
    #region addNumbers
    public void addTemp()
    {
        textotemperaturaD += 0.5f;
    }
    public void addTime()
    {
        textotiempoD += 0.5f;
    }
    public void lessTemp()
    {
        textotemperaturaD += 0.5f;
    }
    public void lessTime()
    {
        textotiempoD -= 0.5f;
    }
    #endregion
    
    
    
    
    

}
