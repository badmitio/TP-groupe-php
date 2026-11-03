<?php

/**
 * Exception levée quand une valeur ne respecte pas les règles métier
 * (nom vide, numéro hors de 1..99, salaire négatif...).
 */
class ValeurInvalideException extends Exception
{
}
