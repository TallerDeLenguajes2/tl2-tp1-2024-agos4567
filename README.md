# Trabajo Practico N1


### ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
•La relacion Pedido-Cliente es por composicion, ya que cada pedido debe estar asociado a un cliente especifico, si se elimina un pedido el cliente relacionado al mismo tambien se debe eliminar, esto muestra una fuerte dependencia entre ambos.

•La relacion Pedido-Cadete es por agregacion, un pedido puede existir sin estar asignado a un cadete.


•La relacion Cadeteria-Cadete es por composicion ya que un cadete no puede existir sin una cadeteria.


### ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?

##### Metodos Cadeteria:
-AgregarCadete(Cadete cadete); Agrega un nuevo cadete a la lista de Cadeteria.

-DarDeBajaCadete(Cadete cadete);Elimina un cadete a la lista de Cadeteria.

-MostrarListadoCadete();

-AsignarPedido(Pedido pedido, Cadete cadete);Para asignar un pedido a un cadete específico.


##### Metodos Cadete:
-AgregarPedido(Pedido pedido); Para agregar un pedido a la lista de pedidos del cadete.

-EliminarPedido(Pedido pedido);Para eliminar un pedido a la lista de pedidos del cadete.

-ListaPedidos(); Muestra la lista de pedidos.

-CalcularJornal(); Para calcular el jornal en base a los pedidos entregados.



### Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles privados.

 

  ##### CLIENTE:

###### Atributos:
  - Nombre:privado
   -Direccion:privado
   -Telefono:privado
   -DatosReferenciaDireccion:privado

###### Metodos:

-VerDireccionCliente(): publico
-VerDatosCliente():publico

 ##### CADETE:
###### Atributos:
  -ID:privado
  -Nombre:privado
  -Direccion:privado
  -Telefono:privado
  -Pedidos:privado

 ###### Metodos:
-AgregarPedido(Pedido pedido);publico.

-EliminarPedido(Pedido pedido);publico.

-ListaPedidos(); privado

-CalcularJornal();publico.

 ##### CADETERIA:
###### Atributos:
-Nombre:(privado)
-Telefono:(privado)
-ListadoCadetes:(privado)
 ###### Metodos:

-AgregarCadete(Cadete cadete); publico

-DarDeBajaCadete(Cadete cadete);publico

-MostrarListadoCadete();privado

-AsignarPedido();publico

 ##### PEDIDOS:
 ###### Atributos:
-Numero:privado
-Observacion:privado
-Cliente:privado
-Estado:privado

  ###### Metodos:
-VerDireccionCliente();publicos
-VerDatosCliente();publicos

### ¿Cómo diseñaría los constructores de cada una de las clases?
### ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?
