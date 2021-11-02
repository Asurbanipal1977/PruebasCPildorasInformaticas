### [API DE .NET](https://docs.microsoft.com/es-es/dotnet/api/)

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
  
Ej: [ejemplo con estos casos](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/blob/main/PruebasCPildorasInformaticas/Program.cs)

### 2. EXPRESIONES REGULARES
Son secuencias que funcionan como un patrón de búsqueda. Se pueden en: validación de formularios, búsqueda en base de datos, búsqueda en ficheros, ...
  Clases útiles: Regex, Match, MatchCollection, MatchGroup
  Métodos: Matches
  Propiedades: Groups
  
  Ej: [ejemplo con estos casos](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/blob/main/ExpresionesRegulares/Program.cs)
  
### 3. WPF (Windows Presentation Fundation)
  - Es el sucesor de Windows Forms.
  - Es un API del paquete de framewok .NET que permite crear interfaces de usuario bajo Windows
  - Puedes hacer estas interfaces gráficas utilizando un lenguaje llamado xaml similar a HTML
  - Se puede crear de forma visual, generándose por debajo el código xaml.
  - Las interfaces gráficas son vectoriales.
  - Data binding. MVC
  
  1. CONCEPTOS BÁSICOS
  - Puedes cambiar entre poner el xaml ariba o abajo con la flecha que aparece en la imagen
  ![imagen](https://user-images.githubusercontent.com/37666654/139532388-9f08161a-fa81-41a6-b4cb-06b62dbb954a.png)
  
  - Los cambios se pueden realizar arrastrando controles del "Cuadro de Herramientas" o desde el código xaml.
  Con WPF se puede trabajar de tres formas: Vista de diseño, con el XAML y con code behind
  
  Sin duda es más fácil o con xaml o con vista diseño. Se ajunta ejemplo que incluye un ejemplo con code behind:
    Ej: [ejemplo de WPF](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/tree/main/PrimeraInterfazWPF)
  
  - Se puede usar un StackPanel para que apile. Para separar elementos se puede usar Margin (se pone el margin arriba, abajo, izquierda y derecha)
  - Para sacar un alert se usa Messabox.Show(texto).
  - En WPF tenemos los eventos enrutados. Dependiendo de la ruta que siga tenemos: 
    - eventos directos. Sin propagación.
    - eventos burbuja. Propagación hacia arriba.
    - eventos tunelados. Propagación hacia abajo. Hay que poner la palabra preview antes del nombre del evento.
  - El evento click para el Stack es: ButtonBase.Click
  
  2. USO DE GRID
  - Divide el contenedor en columnas y filas.
  - Cada columna y fila pueden tomar diferentes valores:
    - Absoluto: Valores en píxeles.
    - Automático: Necesita el valor del elemento interior. **Asigna el tamaño necesario para que quepa el componente**
    - Proporcional: Valor disponible asignado de forma proporcional. **Con el asterisco se indica que se ocupe el resto de la anchura**. Si se pone un número delante es un multiplicador.
  - Las coordenadas están en (columna,fila)
  - Para definir las columnas se usa un código como este:
  ```
    <Grid.ColumnDefinitions>
      <ColumnDefinition Width="175"></ColumnDefinition>
      <ColumnDefinition Width="375"></ColumnDefinition>
    </Grid.ColumnDefinitions>
  ```
Para las **filas es igual pero con RowDefinitions y height**.

  - Para indicar la columna dónde colocar el botón se utiliza la propiedad: Grid.Column="número de la columna empezando en cero"
  - Para la fila se usa Grid.Row
  - Para unir columnas Grid.ColumnSpan y para filas Grid.RowSpan
      Ej: [ejemplo de WPF](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/tree/main/PrimeraInterfazWPF)
  
  3. DEPENDENCY PROPERTIES
  Son propiedades que dependen del sistema de propiedades de WPF para su completo funcionamiento. El sistema de propiedades de WPF son un conjunto de servicios que se pueden utilizar para ampliar la funcionalidad de una propiedad.
  Este sistema de dependencias se utiliza para poder establecer las propiedades de un control en función de otros parámetros que pueden cambiar (Just in time).
  ¿Qué parámetros pueden cambiar para establecer la propiedad de un control? 
- Propiedades del sistema (temas y preferencias de usuario).
- Data Binding
- Animaciones.
- Estilos.
  
  Se puede crear nuestro propio Dependency property, cosa que también se ve en el ejemplo de debajo.
  
  Ej: Tenemos un ejemplo en: 
  [ejemplo de WPF](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/blob/main/PrimeraInterfazWPF/MainWindow.xaml). En este ejemplo se cambia el color y el tamaño de de letra de un botón en el momento en que te mueves con el ratón
  
  
  
  
