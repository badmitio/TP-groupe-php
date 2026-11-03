<?php

require_once __DIR__ . '/MembreEcurie.php';

/**
 * Classe FILLE : un pilote. Table MySQL : pilote.
 */
class Pilote extends MembreEcurie
{
    // #region Champs privés

    private $numero = 1;
    private $points = 0;

    // #endregion

    // #region Constructeur

    /**
     * Appelle le constructeur de la classe mère, puis ajoute le numéro.
     */
    public function __construct($nom = 'inconnu', $prenom = 'inconnu', $salaireBase = 0, $numero = 1)
    {
        parent::__construct($nom, $prenom, $salaireBase);
        $this->setNumero($numero);
    }

    // #endregion

    // #region Accesseurs (getters / setters)

    public function getNumero()
    {
        return $this->numero;
    }

    public function setNumero($numero)
    {
        if ($numero < 1 || $numero > 99) {
            throw new ValeurInvalideException('Le numéro doit être entre 1 et 99.');
        }
        $this->numero = $numero;
    }

    public function getPoints()
    {
        return $this->points;
    }

    public function setPoints($points)
    {
        if ($points < 0) {
            throw new ValeurInvalideException('Les points ne peuvent pas être négatifs.');
        }
        $this->points = $points;
    }

    // #endregion

    // #region Méthodes

    public function ajouterPoints($points)
    {
        if ($points < 0) {
            throw new ValeurInvalideException('On ne peut pas ajouter des points négatifs.');
        }
        $this->points += $points;
    }

    // #endregion

    // #region Méthodes redéfinies

    public function getRole()
    {
        return 'Pilote n°' . $this->numero;
    }

    /** Salaire de base + 1000 euros par point marqué. */
    public function calculerSalaire()
    {
        return $this->getSalaireBase() + $this->points * 1000;
    }

    public function __toString()
    {
        return parent::__toString() . ' (' . $this->points . ' points)';
    }

    // #endregion
}
