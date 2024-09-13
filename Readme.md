# Respuestas
***
1. ¿Cuál de estas relaciones considera que se realiza por composición y cuál por
agregación?
- El cliente, al ser parte del pedido, tiene una relaación dependiente de la clase Pedido, es decir amba clases tiene una conexión por composición.
- El cadete con el pedido tienen una relación de agregación, la cuál es mucho más débil a comparación de la composición, pues el objeto de pedido puede vivir independientemente del objeto de cadete, el cadete sólo utiliza ese objeto.
- El caso anterior sucede también en el caso del objeto cadeteria y cadete, pues cadeteria hace uso del objeto cadete pero éste es independiente.

2. ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
- Ambas clases deberían tener métodos que permitan agregar a sus campos listas sus respectivos objetos de forma ordenada.
- Cadetería debería tener algun método que le permita asignar pedidos a cadetes y listar pedidos según su estado.
- Cadete debería poder eliminar cadetes del sistema y cambiar el estado de un pedido.

3. Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos,
propiedades y métodos deberían ser públicos y cuáles privados.
-  Todas las propiedades deberían ser privadas para un mejor control y seguridad en el flujo de datos.

4. ¿Cómo diseñaría los constructores de cada una de las clases?
- Con sobrecarga de datos.
- El constructor de cadetería puede empezar con datos iniciales como nombre y número.

5. ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?
- 