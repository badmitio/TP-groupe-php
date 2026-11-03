-- MiniProjet F1 (PHP / C#) - Héritage
--   membre_ecurie (table mère)  <--  pilote (fille)
--                               <--  mecanicien (fille)
-- La clé primaire des tables filles est aussi une clé étrangère vers la table mère.

CREATE DATABASE IF NOT EXISTS f1_heritage CHARACTER SET utf8mb4;
USE f1_heritage;

DROP TABLE IF EXISTS mecanicien;
DROP TABLE IF EXISTS pilote;
DROP TABLE IF EXISTS membre_ecurie;

-- Table mère
CREATE TABLE membre_ecurie (
    id            INT AUTO_INCREMENT PRIMARY KEY,
    nom           VARCHAR(50)   NOT NULL,
    prenom        VARCHAR(50)   NOT NULL,
    salaire_base  DECIMAL(10,2) NOT NULL DEFAULT 0
);

-- Table fille : Pilote
CREATE TABLE pilote (
    id      INT PRIMARY KEY,
    numero  INT NOT NULL UNIQUE,
    points  INT NOT NULL DEFAULT 0,
    FOREIGN KEY (id) REFERENCES membre_ecurie (id) ON DELETE CASCADE
);

-- Table fille : Mecanicien
CREATE TABLE mecanicien (
    id                 INT PRIMARY KEY,
    specialite         VARCHAR(50) NOT NULL,
    annees_experience  INT NOT NULL DEFAULT 0,
    FOREIGN KEY (id) REFERENCES membre_ecurie (id) ON DELETE CASCADE
);

-- Jeu d'essai (une ligne dans la table mère + une ligne dans la table fille)
INSERT INTO membre_ecurie (id, nom, prenom, salaire_base) VALUES (1, 'Leclerc',  'Charles', 20000);
INSERT INTO membre_ecurie (id, nom, prenom, salaire_base) VALUES (2, 'Hamilton', 'Lewis',   25000);
INSERT INTO membre_ecurie (id, nom, prenom, salaire_base) VALUES (3, 'Rossi',    'Mario',    3000);

INSERT INTO pilote (id, numero, points) VALUES (1, 16, 25);
INSERT INTO pilote (id, numero, points) VALUES (2, 44, 40);

INSERT INTO mecanicien (id, specialite, annees_experience) VALUES (3, 'Moteur', 10);
