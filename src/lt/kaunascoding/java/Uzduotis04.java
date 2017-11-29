package lt.kaunascoding.java;

import java.util.Scanner;

public class Uzduotis04 {
    public Uzduotis04() {
// paprasyti vartotojo ivesti du skaicius
        System.out.println("Iveskite du skaicius: ");
        Scanner skaitytuvas = new Scanner(System.in);

        float a = skaitytuvas.nextFloat();
        float b = skaitytuvas.nextFloat();

        System.out.println(suma(a, b));

        System.out.println(skirtumas(a, b));

    }

    public static float suma(float a, float b) {
        return a + b;
    }

    public static float skirtumas(float a, float b) {
        return a - b;
    }
}
