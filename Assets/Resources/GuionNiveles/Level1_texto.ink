EXTERNAL Name(charName)  // Cambia nombre 
EXTERNAL CharacterIcon(charName) // Cambia Icono
EXTERNAL CharacterExpression(expressionName) //Cambia imagen de enemigo
EXTERNAL ToLevel(levelName) // Cambia a escena 
EXTERNAL AddOneIndex() // Suma uno al index del ProgessTracker

{CharacterExpression("Level1")} {Name("Hechicero maligno")} {CharacterIcon("Enemy_1")}Eres valiente para llegar hasta aquí, no llegarás tan lejos...”

{Name("Arkanos")} {CharacterIcon("Player")}
Te derrotaré!

{Name("Hechicero maligno")} {CharacterIcon("Enemy_1")}
No durarás nada en esta batalla…”

{AddOneIndex()}
{ToLevel("Level1")}