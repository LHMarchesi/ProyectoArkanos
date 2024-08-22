EXTERNAL Name(charName)  // Cambia nombre 
EXTERNAL CharacterIcon(charName) // Cambia Icono
EXTERNAL CharacterExpression(expressionName) //Cambia imagen de enemigo
EXTERNAL ToLevel(levelName) // Cambia a escena 

{CharacterExpression("Level3_idle")}

{Name("Arkanos")} {CharacterIcon("Player")}
-Lich, he llegado hasta aquí para reclamar el Grimorio de los Deseos. 
Mi abuelo está gravemente enfermo, y solo el poder de ese grimorio puede salvarlo. 
No permitiré que tus oscuros designios sigan impidiéndolo.

{Name("Lich")} {CharacterIcon("Enemy_3")}
-¿Realmente crees que puedes despojarme de lo que he obtenido con tanto esfuerzo por un simple deseo personal?

{Name("Arkanos")} {CharacterIcon("Player")}
-No puedo darme el lujo de retroceder ahora. La vida de mi abuelo está en juego.

{Name("Lich")} {CharacterIcon("Enemy_3")}
-Son meros caprichos humanos. Lo que tú llamas salvar a tu abuelo, yo lo veo como una debilidad. 
El Grimorio es solo un medio para obtener el poder supremo que mi magia exige.

{Name("Arkanos")} {CharacterIcon("Player")}
-No puedes usar el Grimorio para tus oscuros fines. 
Es un artefacto que debe ser usado para restaurar el equilibrio y para sanar, no para alimentar tu ambición.

{Name("Lich")} {CharacterIcon("Enemy_3")}
-El Grimorio es mi llave a un reino de poder eterno. Nadie puede detenerme.

{Name("Arkanos")} {CharacterIcon("Player")}
-La batalla será ardua, pero no permitiré que la oscuridad me impida salvar a mi abuelo.

{Name("Lich")} {CharacterIcon("Enemy_3")}
-Ven, entonces, Arkanos. Demuestra tu poder. 
Aquí, en mi dominio, las sombras se convierten en armas y la oscuridad es nuestra aliada. 
¿Estás preparado para enfrentar la verdadera esencia de la magia oscura?
{ToLevel("Level3")}

