using System;

namespace MiniProjet_F1_Bibli
{
    /// <summary>
    /// Exception levée quand une valeur ne respecte pas les règles métier
    /// (nom vide, numéro hors de 1..99, salaire négatif...).
    /// </summary>
    public class ValeurInvalideException : Exception
    {
        public ValeurInvalideException(string message) : base(message)
        {
        }
    }
}
