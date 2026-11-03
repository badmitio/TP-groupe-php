using System;
using System.Collections.Generic;
using MiniProjet_F1_Bibli;

namespace MiniProjet_F1_Tests
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // ----- Test 1 : création des objets -----
            Console.WriteLine("===== Test 1 : création =====");
            Pilote leclerc = new Pilote("Leclerc", "Charles", 20000, 16);
            Pilote hamilton = new Pilote("Hamilton", "Lewis", 25000, 44);
            Mecanicien mario = new Mecanicien("Rossi", "Mario", 3000, "Moteur", 10);
            Console.WriteLine(leclerc);
            Console.WriteLine(hamilton);
            Console.WriteLine(mario);

            // ----- Test 2 : accesseurs et méthodes -----
            Console.WriteLine();
            Console.WriteLine("===== Test 2 : accesseurs et méthodes =====");
            leclerc.AjouterPoints(25);
            hamilton.Points = 40;
            Console.WriteLine("Points de Leclerc : " + leclerc.Points);
            Console.WriteLine("Numéro de Hamilton : " + hamilton.Numero);

            // ----- Test 3 : collection + polymorphisme -----
            Console.WriteLine();
            Console.WriteLine("===== Test 3 : collection (polymorphisme) =====");
            List<MembreEcurie> membres = new List<MembreEcurie>();
            membres.Add(leclerc);
            membres.Add(hamilton);
            membres.Add(mario);

            decimal total = 0;
            foreach (MembreEcurie m in membres)
            {
                // Même appel, résultat différent selon la classe réelle (Pilote ou Mecanicien)
                Console.WriteLine(m.GetRole() + " -> " + m.CalculerSalaire() + " euros");
                total += m.CalculerSalaire();
            }
            Console.WriteLine("Masse salariale : " + total + " euros");

            // ----- Test 4 : exceptions -----
            Console.WriteLine();
            Console.WriteLine("===== Test 4 : exceptions =====");

            try
            {
                Pilote faux = new Pilote("Verstappen", "Max", 20000, 150);
                Console.WriteLine("Ne doit pas s'afficher");
            }
            catch (ValeurInvalideException ex)
            {
                Console.WriteLine("Exception capturée (numéro) : " + ex.Message);
            }

            try
            {
                leclerc.AjouterPoints(-10);
            }
            catch (ValeurInvalideException ex)
            {
                Console.WriteLine("Exception capturée (points) : " + ex.Message);
            }

            try
            {
                mario.Nom = "";
            }
            catch (ValeurInvalideException ex)
            {
                Console.WriteLine("Exception capturée (nom vide) : " + ex.Message);
            }

            try
            {
                mario.SalaireBase = -100;
            }
            catch (ValeurInvalideException ex)
            {
                Console.WriteLine("Exception capturée (salaire) : " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Appuie sur une touche pour fermer...");
            Console.ReadKey();
        }
    }
}
