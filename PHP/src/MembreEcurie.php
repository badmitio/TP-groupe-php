<?php

require_once __DIR__ . '/ValeurInvalideException.php';

/**
 * Classe MÈRE : un membre du personnel d'une écurie de F1.
 * Table MySQL : membre_ecurie.
 */
abstract class MembreEcurie
{
    // #region Champs privés

    private $id = 0;
    private $nom = 'inconnu';
    private $prenom = 'inconnu';
    private $salaireBase = 0;

    // #endregion

    // #region Constructeur

    /**
     * Constructeur de la classe mère, appelé par les filles avec parent::__construct().
     */
    public function __construct($nom = 'inconnu', $prenom = 'inconnu', $salaireBase = 0)
    {
        $this->setNom($nom);
        $this->setPrenom($prenom);
        $this->setSalaireBase($salaireBase);
    }

    // #endregion

    // #region Accesseurs (getters / setters)

    public function getId()
    {
        return $this->id;
    }

    public function setId($id)
    {
        $this->id = $id;
    }

    public function getNom()
    {
        return $this->nom;
    }

    public function setNom($nom)
    {
        if (trim($nom) === '') {
            throw new ValeurInvalideException('Le nom ne peut pas être vide.');
        }
        $this->nom = $nom;
    }

    public function getPrenom()
    {
        return $this->prenom;
    }

    public function setPrenom($prenom)
    {
        if (trim($prenom) === '') {
            throw new ValeurInvalideException('Le prénom ne peut pas être vide.');
        }
        $this->prenom = $prenom;
    }

    public function getSalaireBase()
    {
        return $this->salaireBase;
    }

    public function setSalaireBase($salaireBase)
    {
        if ($salaireBase < 0) {
            throw new ValeurInvalideException('Le salaire de base ne peut pas être négatif.');
        }
        $this->salaireBase = $salaireBase;
    }

    // #endregion

    // #region Méthodes

    /** Rôle du membre : écrit différemment dans chaque classe fille. */
    abstract public function getRole();

    /** Salaire réel : calculé différemment dans chaque classe fille. */
    abstract public function calculerSalaire();

    // #endregion

    // #region Méthodes redéfinies

    public function __toString()
    {
        return $this->prenom . ' ' . $this->nom . ' - ' . $this->getRole()
            . ' - salaire : ' . $this->calculerSalaire() . ' euros';
    }

    // #endregion
}
