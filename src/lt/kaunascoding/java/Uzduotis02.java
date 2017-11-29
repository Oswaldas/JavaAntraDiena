package lt.kaunascoding.java;

import java.util.Scanner;

public class Uzduotis02 {
    public Uzduotis02() {
        // paprasyti vartotojo ivesti zodi
        System.out.println("Iveskite zodi: ");
        // atspausdinti kiek simboliu yra tame zodyje
        Scanner skaitytuvas = new Scanner(System.in);
        String zodis = skaitytuvas.nextLine();
        System.out.println(zodis.length());

    }
}