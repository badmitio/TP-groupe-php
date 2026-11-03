<?php

require_once __DIR__ . '/../src/Pilote.php';
require_once __DIR__ . '/../src/Mecanicien.php';

// ----- Test 1 : création des objets -----
echo "===== Test 1 : création =====\n";
$leclerc = new Pilote('Leclerc', 'Charles', 20000, 16);
$hamilton = new Pilote('Hamilton', 'Lewis', 25000, 44);
$mario = new Mecanicien('Rossi', 'Mario', 3000, 'Moteur', 10);
echo $leclerc . "\n";
echo $hamilton . "\n";
echo $mario . "\n";

// ----- Test 2 : accesseurs et méthodes -----
echo "\n===== Test 2 : accesseurs et méthodes =====\n";
$leclerc->ajouterPoints(25);
$hamilton->setPoints(40);
echo 'Points de Leclerc : ' . $leclerc->getPoints() . "\n";
echo 'Numéro de Hamilton : ' . $hamilton->getNumero() . "\n";

// ----- Test 3 : collection + polymorphisme -----
echo "\n===== Test 3 : collection (polymorphisme) =====\n";
$membres = [];
$membres[] = $leclerc;
$membres[] = $hamilton;
$membres[] = $mario;

$total = 0;
foreach ($membres as $m) {
    // Même appel, résultat différent selon la classe réelle (Pilote ou Mecanicien)
    echo $m->getRole() . ' -> ' . $m->calculerSalaire() . " euros\n";
    $total += $m->calculerSalaire();
}
echo 'Masse salariale : ' . $total . " euros\n";

// ----- Test 4 : exceptions -----
echo "\n===== Test 4 : exceptions =====\n";

try {
    $faux = new Pilote('Verstappen', 'Max', 20000, 150);
    echo "Ne doit pas s'afficher\n";
} catch (ValeurInvalideException $e) {
    echo 'Exception capturée (numéro) : ' . $e->getMessage() . "\n";
}

try {
    $leclerc->ajouterPoints(-10);
} catch (ValeurInvalideException $e) {
    echo 'Exception capturée (points) : ' . $e->getMessage() . "\n";
}

try {
    $mario->setNom('');
} catch (ValeurInvalideException $e) {
    echo 'Exception capturée (nom vide) : ' . $e->getMessage() . "\n";
}

try {
    $mario->setSalaireBase(-100);
} catch (ValeurInvalideException $e) {
    echo 'Exception capturée (salaire) : ' . $e->getMessage() . "\n";
}
