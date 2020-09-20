using FuzzyLogicPCL;
using FuzzyLogicPCL.FuzzySets;
using System;
using UnityEngine;
namespace FuzzyLogicApp
{
    class Store : MonoBehaviour
    {
        void Start()
        {
            // Creación de la persiana
            Debug.Log("Gestión de la persiana");
            FuzzySystem system = new FuzzySystem("Gestión de la persiana");

            Debug.Log("1) Agregar las variables");

            // Agregar la variable lingüística "Temperatura"
            Debug.Log("Agregar la variable Temperatura");
            LinguisticVariable temp = new LinguisticVariable("Temperatura", 0, 35);
            temp.AddValue(new LinguisticValue("Frio", new LeftFuzzySet(0, 35, 10, 12)));
            temp.AddValue(new LinguisticValue("Fresco", new TrapezoidalFuzzySet(0, 35, 10, 12, 15, 17)));
            temp.AddValue(new LinguisticValue("BuenTiempo", new TrapezoidalFuzzySet(0, 35, 15, 17, 20, 25)));
            temp.AddValue(new LinguisticValue("Calor", new RightFuzzySet(0, 35, 20, 25)));
            system.addInputVariable(temp);

            // Agregar la variable lingüística "Claridad" 
            Debug.Log("Agregar la variable Claridad");
            LinguisticVariable claridad = new LinguisticVariable("Claridad", 0, 125000);
            claridad.AddValue(new LinguisticValue("Sombra", new LeftFuzzySet(0, 125000, 20000, 30000)));
            claridad.AddValue(new LinguisticValue("Media", new TrapezoidalFuzzySet(0, 125000, 20000, 30000, 65000, 85000)));
            claridad.AddValue(new LinguisticValue("Fuerte", new RightFuzzySet(0, 125000, 65000, 85000)));
            system.addInputVariable(claridad);

            // Agregar la variable lingüística "Persiana"
            Debug.Log("Agregar la variable Altura de la persiana");
            LinguisticVariable Persiana = new LinguisticVariable("Persiana", 0, 115);
            Persiana.AddValue(new LinguisticValue("Cerrada", new LeftFuzzySet(0, 115, 25, 40)));
            Persiana.AddValue(new LinguisticValue("MediaAltura", new TrapezoidalFuzzySet(0, 115, 25, 40, 85, 100)));
            Persiana.AddValue(new LinguisticValue("Subida", new RightFuzzySet(0, 115, 85, 100)));
            system.addOutputVariable(Persiana);

            Debug.Log("2) Agregar las reglas");

            // Creación de las reglas 
            system.addFuzzyRule("IF Claridad IS Sombra THEN Persiana IS Subida");
            system.addFuzzyRule("IF Claridad IS Media AND Temperatura IS Frio THEN Persiana IS Subida");
            system.addFuzzyRule("IF Claridad IS Media AND Temperatura IS Fresco THEN Persiana IS Subida");
            system.addFuzzyRule("IF Claridad IS Media AND Temperatura IS BuenTiempo THEN Persiana IS MediaAltura");
            system.addFuzzyRule("IF Claridad IS Media AND Temperatura IS Calor THEN Persiana IS MediaAltura");
            system.addFuzzyRule("IF Claridad IS Fort AND Temperatura IS Frio THEN Persiana IS Subida");
            system.addFuzzyRule("IF Claridad IS Fort AND Temperatura IS Fresco THEN Persiana IS MediaAltura");
            system.addFuzzyRule("IF Claridad IS Fort AND Temperatura IS BuenTiempo THEN Persiana IS Cerrada");
            system.addFuzzyRule("IF Claridad IS Fort AND Temperatura IS Calor THEN Persiana IS Cerrada");
            Debug.Log("9 reglas agregadas \n");

            Debug.Log("3) Resolución de casos prácticos");
            // Caso práctico 1: temperatura de 21°, claridad de 80000 lux
            Debug.Log("Caso 1:");
            Debug.Log("T = 21 (80% buen tiempo, 20% calor)");
            Debug.Log("E = 80 000 (25% media, 75% fuerte)");
            system.SetInputVariable(temp, 21);
            system.SetInputVariable(claridad, 80000);
            Debug.Log("Esperado: Persiana más bien cerrada");
            Debug.Log("Resultado: " + system.Solve() + "\n");

            while (true) ;
        }

        /// <summary>
        /// Ayuda para escribir mensajes por consola (agregando *)
        /// </summary>
        /// <param name="msg">Mensaje a mostrar</param>
        /// <param name="stars">¿Necesita asteriscos?</param>
        
    }
}
