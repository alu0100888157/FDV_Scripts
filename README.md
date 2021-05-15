# FDV_Scripts

C#. Programación de Scripts.

Como se puede observar hay dos tipos de figuras: 

Cilindros que son objetos con movimientos rectilineo a lo largo del mapa (al llegar al borde, dan la vuelta)

Cápsulas que son objetos estáticos que se intercambia de posición con la otra cápsula del campo.

Al empezar el juego todos los objetos aparecen en una posición aleatoria, el jugador al acercarse a cada uno de ellos activa lo siguiente:

- Siempre que se acerque a un objeto, este cambiará de color (azul estático, rojo movimiento)
- el objeto se irá reduciendo de tamaño, pero solo una vez, para que siga disminuyendo hay que alejarse y volverse a acercar.
- el objeto si disminuye una cierta cantidad de veces, desaparece
- el jugador conseguirá puntuación, 15 en los estáticos, 25 en los de movimiento.

VIDEO
