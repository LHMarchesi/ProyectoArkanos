EXTERNAL Name(charName)  // Cambia nombre 
EXTERNAL CharacterIcon(charName) // Cambia Icono
EXTERNAL CharacterExpression(expressionName) //Cambia imagen de enemigo
EXTERNAL ToLevel(levelName) // Cambia a escena 
EXTERNAL AddOneIndex() // Suma uno al index del ProgessTracker

{CharacterExpression("Level2")}{Name("Arkanos")} {CharacterIcon("Player")}-¿Quién eres? ¿Y qué haces en este templo?



{Name("Enemy2")} {CharacterIcon("Enemy_2")}
-Mi objetivo es proteger este templo de los tesoros que ocultan. 
Ningún viajero se atreverá a apoderarse de las mayores riquezas de este templo.

{Name("Arkanos")} {CharacterIcon("Player")}
-No quiero las riquezas de este templo, solo quiero usar el círculo mágico para viajar al siguiente mundo.

{Name("Enemy2")} {CharacterIcon("Enemy_2")}
-Tendras que derrotarme...

{Name("Arkanos")} {CharacterIcon("Player")}
-Fuera de mi camino!!
{AddOneIndex()}
{ToLevel("Level2")}


