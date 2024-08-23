EXTERNAL Name(charName)  // Cambia nombre 
EXTERNAL CharacterIcon(charName) // Cambia Icono
EXTERNAL CharacterExpression(expressionName) //Cambia imagen de enemigo
EXTERNAL ToLevel(levelName) // Cambia a escena 
EXTERNAL AddOneIndex()

{Name("Maugre")} {CharacterIcon("Enemy_4")}
-Quien se atreve a impedir mis planes!?

{Name("Arkanos")} {CharacterIcon("Player")}
-No voy a dejar que desates el caos en el mundo!”

{Name("Maugre")} {CharacterIcon("Enemy_4")}
-¡Soy más poderoso que tú, intenta derrotarme HA HA HA HA!
{ToLevel("Level4")}
{AddOneIndex()}
