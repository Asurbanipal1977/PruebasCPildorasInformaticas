### 1. DELEGADOS PREDICADOS Y LAMBDA
**1. DELEGADOS:** Funciones que delegan las tareas a otras. Un delegado es una referencia a un método y se usan para llamar a eventos.

Síntaxis: delegate tipo NombreDelegado(argumentos)

Para usarla se debe instancias como una clase:
NombreDelegado oNombre = new NombreDelegado(FuncionDelegada);
oNombre(argumentos);

**2. PREDICADOS:** Son delegados que responden un booleano.
Normalmente se usan para filtrar listas de valores si una condición es cierta

Síntaxis: Predicate<T> NombrePredicado = new Predicate<T>(FuncionDelegada);
  
**3. LAMBDAS:** Funciones anónimas que se usan para ejecutar una tarea que no necesita ser nombrada.
Se utilizan en delegados sencillos y expresiones LINQ.

Síntaxis: parametros => bloque de sentencia
