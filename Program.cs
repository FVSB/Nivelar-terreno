using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




//Ejemplo 1
int[] ej1 = { 1, 1, 2, 3, 2, 2 };
int r1 = Constructora.MinNivelarParcela(ej1);
ChequearRespuesta(3, r1, 1);

//Ejemplo 2
int[] ej2 = { 2, 2, 4, 3, 4, 1, 1 };
int r2 = Constructora.MinNivelarParcela(ej2);
ChequearRespuesta(6, r2, 2);


//Ejemplo 3
int[] ej3 = { 3, 3, 3, 3 };
int r3 = Constructora.MinNivelarParcela(ej3);
ChequearRespuesta(0, r3, 3);

//Ejemplo 4
int[] ej4 = { 1, 1, 1, 2, 2, 1, 1, 2 };
int r4 = Constructora.MinNivelarParcela(ej4);
ChequearRespuesta(2, r4, 4);


/// <summary>
/// Imprime el resultado de un test
/// </summary>
/// <param name="correcta">Respuesta esperada para el test</param>
/// <param name="respuesta">Respuesta a chequear con la correcta</param>
/// <param name="caso">Numero del test</param>
static void ChequearRespuesta(int correcta, int respuesta, int caso)
{
    Console.WriteLine("Caso de Ejemplo {0}.", caso);
    if (respuesta == correcta)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Correcto");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Incorrecto. Se esperaba {0} y se obtuvo {1}.", correcta, respuesta);
    }
    Console.ResetColor();
    Console.WriteLine();
}



public static class Constructora
{
    public static int MinNivelarParcela(int[] parcela)
    {
        return recur(parcela, parcela.Length - 1, parcela.Max(), 0);
    }

    private static int recur(int[] parcela, int pala, int supremo, int cant)
    {
        if (pala == 0)//parcela
        {
            return cant;
        }



        bool cambio = false;
        bool control = false;
        do
        {
            cambio = false;
            control = false;
            for (int i = 0; i < parcela.Length; i++)//por cada pedazo de parcela
            {


                if (pala + i <= parcela.Length)
                {
                    cambio = true;
                     int[] w=clonar(parcela);   
                    int[] temp = rellenar(w, i, pala);
                    control = (comprobar(temp, supremo));//comprobar 

                    parcela = control ? temp : parcela;
                }
                if (control)
                {
                    cant++;
                }

            }

        } while (cambio && control);

        if (Nivelado(parcela))
        {
            return cant;
        }

        return recur(parcela, pala - 1, supremo, cant);





    }

    private static int[]clonar(int[]map)
    {
        int []temp=new int[map.Length];
        for (int i = 0; i <map.Length; i++)
        {
            temp[i]=map[i];
        }
        return temp;
    }
    private static int[] rellenar(int[] map, int index, int pala)
    {

        for (int j = 0; j < pala; j++)// añadir tamaño pala
        {
            int dir = index + j;

            map[dir]++;

        }
        return map;

    }

    private static bool comprobar(int[] map, int max)
    {
        for (int i = 0; i < map.Length; i++)
        {
            int s = map[i];
            if (s > max)
            {
                return false;
            }
        }
        return true;


    }

    private static bool Nivelado(int[] map)
    {
        int igual = map[0];

        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] != igual)
            {
                return false;
            }
        }
        return true;

    }



}









