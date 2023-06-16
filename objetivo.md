# Proyecto
- Juego una batalla entre 2 personajes
- Cada pesonaje debe tener:
    - Datos:
        - Tipo (ejemplo mago, guerrero, etc.). Puede ser un enum
        - Nombre
        - Apodo
        - Fecha de Nacimiento
        - Edad (0 a 300)
    - Caracterisiticas (por ejemplo nivel de defensa y ataque): Entre las características :
        - Velocidad (de 1 a 10)
        - Destreza (1 a 5)
        - Fuerza (1 a 10)
        - Nivel (1 a 10)
        - Armadura (1 a 10)
        - Salud (100)
    - Hacer una clase llamada personaje. Cada personaje será un objeto y tendrá distintos niveles de cada característica.
        - Puedo hacer si quiero una clase para datos y otra para características, pero no es de mucha utilidad. Esto si tendría utilidad si es que se pueden transferir las características de un personaje a otro
    - Si quiero puedo agregar datos y características
    - Siempre comitear en puntos estratégicos (por etapas, cuando una etapa anda hago el commit)

## Generar los datos de los personajes
- Tengo un método y me retorna los datos de sus personajes con sus datos y características:
    - Primero, debo pensar como genero los valores aleatorios.No es que le voy a pedir al usuario que me diga cuanto quiere de velocidad, fuerza, etc.
    - Sino, le digo que me de un personaje y dependiendo el tipo tendrá ciertas características
- Puedo generar un arreglo de nombres o cargarlos de internet
- Para evitar tener un personaje que sea muchísimo mejor que el otro, debo hacer lo siguiente:
    - Tener personajes pre-creados
    - Tipos pre-creados según el tipo:
        - Ejemplo si es un ogro, tiene velocidad entre (4-5), pero  entre (8-10)
            - Puedo tener como constantes para ogroFuerzaMin y ogroFuerzaMax
    - Podríamos decir que un personaje no puede tener en total mas de 50 puntos por ejemplo. Entonces, a medida de que doy puntos de fuerza y velocidad, voy descontando en el total.
    