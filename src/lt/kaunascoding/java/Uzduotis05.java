package lt.kaunascoding.java;

import java.util.Scanner;

public class Uzduotis05 {
    public Uzduotis05() {
// paprasyti vartotojo ivesti du skaicius
        System.out.println("Iveskite du skaicius: ");
        Scanner skaitytuvas = new Scanner(System.in);

        float a = skaitytuvas.nextFloat();
        float b = skaitytuvas.nextFloat();

        System.out.println(suma(a, b));
        System.out.println(suma((int) a, (int) b));
        System.out.println(skirtumas(a, b));
        System.out.println(skirtumas((int) a, (int) b));
    }

    public static int suma(int a, int b) {
        return a + b;
    }

    public static float suma(float a, float b) {
        return a + b;
    }

    public static int skirtumas(int a, int b) {
        return a - b;
    }

    public static float skirtumas(float a, float b) {
        return a - b;
    }
}
