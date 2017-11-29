package lt.kaunascoding.java;

import java.util.Scanner;

public class Main {
    public static final int CHOISE_0 = 0;
    public static final int CHOISE_1 = 1;
    public static final int CHOISE_2 = 2;
    public static final int CHOISE_3 = 3;
    public static final int CHOISE_4 = 4;

    public static void main(String[] args) {
        // parodyti vartotojui kiek yra uzduociu
        // paklausti vartotojo kokia uzd parodyti
        // nuskaityti vartottojo pasirinkima
        // pagal ivesta sveika sksaiciu rodyti uzduoties vykdyma
        // programa kartoja sia seka kol neivedam 0
        Scanner skaitytuvas = new Scanner(System.in); // skaneri kuriam cia, kad maziau rytu RAM
        // begalinis ciklas:
        while(true){
            System.out.println("Turime isviso 0 uzduociu");
            System.out.println("Iveskite uzduoties nr kad ja vykdyti");
            System.out.println("Ivedus 0 programa bus baigta");

            int pasirinkimas = skaitytuvas.nextInt();
            switch (pasirinkimas){
                case CHOISE_0:
                    return;
                case CHOISE_1:
                    Uzduotis01 pirmoji = new Uzduotis01();
                    break;
            }

            //return; - nutraukia cikla
        }
    }
}
