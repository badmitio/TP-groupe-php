namespace MiniProjet_F1_Bibli
{
    /// <summary>
    /// Classe FILLE : un mécanicien. Table MySQL : mecanicien.
    /// </summary>
    public class Mecanicien : MembreEcurie
    {
        #region Champs privés

        private string _specialite = "inconnue";
        private int _anneesExperience = 0;

        #endregion

        #region Propriétés (accesseurs get / set)

        public string Specialite
        {
            get { return _specialite; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ValeurInvalideException("La spécialité ne peut pas être vide.");
                _specialite = value;
            }
        }

        public int AnneesExperience
        {
            get { return _anneesExperience; }
            set
            {
                if (value < 0)
                    throw new ValeurInvalideException("L'expérience ne peut pas être négative.");
                _anneesExperience = value;
            }
        }

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Mecanicien() : base()
        {
        }

        /// <summary>
        /// Constructeur complet : appelle le constructeur de la classe mère.
        /// </summary>
        public Mecanicien(string nom, string prenom, decimal salaireBase, string specialite, int anneesExperience)
            : base(nom, prenom, salaireBase)
        {
            Specialite = specialite;
            AnneesExperience = anneesExperience;
        }

        #endregion

        #region Méthodes redéfinies

        public override string GetRole()
        {
            return "Mécanicien " + _specialite;
        }

        /// <summary>
        /// Salaire de base + 500 euros par année d'expérience.
        /// </summary>
        public override decimal CalculerSalaire()
        {
            return SalaireBase + _anneesExperience * 500;
        }

        public override string ToString()
        {
            return base.ToString() + " (" + _anneesExperience + " ans d'expérience)";
        }

        #endregion
    }
}
