package lt.kaunascoding.java;

import java.util.Scanner;

public class Uzduotis03 {
    public Uzduotis03() {
// paprasyti vartotojo ivesti du skaicius
        System.out.println("Iveskite du skaicius: ");
        Scanner skaitytuvas = new Scanner(System.in);
        int skaicius = skaitytuvas.nextInt();
        int skaicius2 = skaitytuvas.nextInt();

        System.out.println(skaicius + skaicius2);
        System.out.println(skaicius - skaicius2);

    }
}
