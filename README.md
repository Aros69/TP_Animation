# TP Animation : Cinématique Inverse et MecAnim
#### UCBL Master 2 ID3D UE d'Animation 

Developpeur : Robin Donnay

## Structure du projet

- 2 scènes notables : 
    - Fabrik : Implémentation de l'algorithme de cinématique inverse FABRIK :
        - 2 prefabs à tester (dans le dossier "Assets/Prebafs"):  
            - AB0 (un arbre avec 2 cibles pour la cinématique inverse)
                - Mouvement Cible 1 : 
                    - "z" et "s" pour l'axe Y
                    - "q" et "d" pour l'axe X 
                    - "f" et "r" pour l'axe Z
                - Mouvement Cible 2 : 
                    - "h" et "k" pour l'axe X 
                    - "u" et "j" pour l'axe Y
                    - "o" et "l" pour l'axe Z
            - J0 (une chaine avec 1 cible pour la cinematique inverse) 
                - Mouvement Cible : 
                    - "q" et "d" pour l'axe X 
                    - "z" et "s" pour l'axe Y
                    - "f" et "r" pour l'axe Z
    - MecAnim : Implémentation d'une machine à état d'animation
        - Un Personnage avec un controlleur d'animation et une cinématique inverse pour la tete (elle suit du       regard le cube juste devant elle)
            - Mouvement du personnage : "zqsd" pour se deplacer sur le plan et "espace" pour courir 
        - Un mur de cubes Rigid générés à l'exécution 
