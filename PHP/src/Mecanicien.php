<?php

require_once __DIR__ . '/MembreEcurie.php';

/**
 * Classe FILLE : un mécanicien. Table MySQL : mecanicien.
 */
class Mecanicien extends MembreEcurie
{
    // #region Champs privés

    private $specialite = 'inconnue';
    private $anneesExperience = 0;

    // #endregion

    // #region Constructeur

    /**
     * Appelle le constructeur de la classe mère, puis ajoute la spécialité et l'expérience.
     */
    public function __construct($nom = 'inconnu', $prenom = 'inconnu', $salaireBase = 0, $specialite = 'inconnue', $anneesExperience = 0)
    {
        parent::__construct($nom, $prenom, $salaireBase);
        $this->setSpecialite($specialite);
        $this->setAnneesExperience($anneesExperience);
    }

    // #endregion

    // #region Accesseurs (getters / setters)

    public function getSpecialite()
    {
        return $this->specialite;
    }

    public function setSpecialite($specialite)
    {
        if (trim($specialite) === '') {
            throw new ValeurInvalideException('La spécialité ne peut pas être vide.');
        }
        $this->specialite = $specialite;
    }

    public function getAnneesExperience()
    {
        return $this->anneesExperience;
    }

    public function setAnneesExperience($anneesExperience)
    {
        if ($anneesExperience < 0) {
            throw new ValeurInvalideException('L\'expérience ne peut pas être négative.');
        }
        $this->anneesExperience = $anneesExperience;
    }

    // #endregion

    // #region Méthodes redéfinies

    public function getRole()
    {
        return 'Mécanicien ' . $this->specialite;
    }

    /** Salaire de base + 500 euros par année d'expérience. */
    public function calculerSalaire()
    {
        return $this->getSalaireBase() + $this->anneesExperience * 500;
    }

    public function __toString()
    {
        return parent::__toString() . ' (' . $this->anneesExperience . ' ans d\'expérience)';
    }

    // #endregion
}
