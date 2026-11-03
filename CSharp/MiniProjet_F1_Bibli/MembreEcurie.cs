namespace MiniProjet_F1_Bibli
{
    /// <summary>
    /// Classe MÈRE : un membre du personnel d'une écurie de F1.
    /// Table MySQL : membre_ecurie.
    /// </summary>
    public abstract class MembreEcurie
    {
        #region Champs privés

        private int _id = 0;
        private string _nom = "inconnu";
        private string _prenom = "inconnu";
        private decimal _salaireBase = 0;

        #endregion

        #region Propriétés (accesseurs get / set)

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ValeurInvalideException("Le nom ne peut pas être vide.");
                _nom = value;
            }
        }

        public string Prenom
        {
            get { return _prenom; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ValeurInvalideException("Le prénom ne peut pas être vide.");
                _prenom = value;
            }
        }

        public decimal SalaireBase
        {
            get { return _salaireBase; }
            set
            {
                if (value < 0)
                    throw new ValeurInvalideException("Le salaire de base ne peut pas être négatif.");
                _salaireBase = value;
            }
        }

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut (valeurs "inconnu", salaire à 0).
        /// </summary>
        protected MembreEcurie()
        {
        }

        /// <summary>
        /// Constructeur complet, appelé par les classes filles avec base(...).
        /// </summary>
        protected MembreEcurie(string nom, string prenom, decimal salaireBase)
        {
            Nom = nom;
            Prenom = prenom;
            SalaireBase = salaireBase;
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Rôle du membre : écrit différemment dans chaque classe fille.
        /// </summary>
        public abstract string GetRole();

        /// <summary>
        /// Salaire réel : calculé différemment dans chaque classe fille.
        /// </summary>
        public abstract decimal CalculerSalaire();

        #endregion

        #region Méthodes redéfinies

        public override string ToString()
        {
            return Prenom + " " + Nom + " - " + GetRole() + " - salaire : " + CalculerSalaire() + " euros";
        }

        #endregion
    }
}
