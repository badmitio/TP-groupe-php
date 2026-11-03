namespace MiniProjet_F1_Bibli
{
    /// <summary>
    /// Classe FILLE : un pilote. Table MySQL : pilote.
    /// </summary>
    public class Pilote : MembreEcurie
    {
        #region Champs privés

        private int _numero = 1;
        private int _points = 0;

        #endregion

        #region Propriétés (accesseurs get / set)

        public int Numero
        {
            get { return _numero; }
            set
            {
                if (value < 1 || value > 99)
                    throw new ValeurInvalideException("Le numéro doit être entre 1 et 99.");
                _numero = value;
            }
        }

        public int Points
        {
            get { return _points; }
            set
            {
                if (value < 0)
                    throw new ValeurInvalideException("Les points ne peuvent pas être négatifs.");
                _points = value;
            }
        }

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Pilote() : base()
        {
        }

        /// <summary>
        /// Constructeur complet : appelle le constructeur de la classe mère.
        /// </summary>
        public Pilote(string nom, string prenom, decimal salaireBase, int numero)
            : base(nom, prenom, salaireBase)
        {
            Numero = numero;
        }

        #endregion

        #region Méthodes

        public void AjouterPoints(int points)
        {
            if (points < 0)
                throw new ValeurInvalideException("On ne peut pas ajouter des points négatifs.");
            _points += points;
        }

        #endregion

        #region Méthodes redéfinies

        public override string GetRole()
        {
            return "Pilote n°" + _numero;
        }

        /// <summary>
        /// Salaire de base + 1000 euros par point marqué.
        /// </summary>
        public override decimal CalculerSalaire()
        {
            return SalaireBase + _points * 1000;
        }

        public override string ToString()
        {
            return base.ToString() + " (" + _points + " points)";
        }

        #endregion
    }
}
