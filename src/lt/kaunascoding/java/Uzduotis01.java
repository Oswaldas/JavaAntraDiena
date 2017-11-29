package lt.kaunascoding.java;

import java.util.Scanner;

public class Uzduotis01 {
    public Uzduotis01(){
        // pasisveikinti su vartotoju
        // paprasyti ivesti savo varda
        // atspausdinti jo varda5 kartus;

        System.out.println("Sveiki, iveskite savo varda");
        Scanner skaneris = new Scanner(System.in);
        String vardas = skaneris.next();
        System.out.print(vardas);
        System.out.print(vardas);
        System.out.print(vardas);
        System.out.print(vardas);
        System.out.print(vardas);

    }
}
