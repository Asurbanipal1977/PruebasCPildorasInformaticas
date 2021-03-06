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
- Data Binding.
- Animaciones.
- Estilos.
  
  Se puede crear nuestro propio Dependency property, cosa que también se ve en el ejemplo de debajo.
  
  Ej: Tenemos un ejemplo en: 
  [ejemplo de WPF](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/blob/main/PrimeraInterfazWPF/MainWindow.xaml). En este ejemplo se cambia el color y el tamaño de de letra de un botón en el momento en que te mueves con el ratón.
  
4. DATA BINDING
  - Es un puente o enlace a través del cúal el control es capaz de enviar y recibir información pudiendo obtener información de: BBDD, Objetos u otros controles.
  - Tipos: oneway, onewayToSource, twoWays, oneTime.
  
  Ej: Como se puede observar, en el campo Text se define engtre llaves el Binding, indicando el nombre del elemento de fuente de datos, la propiedad que se quiere obtener (en este caso el valor) y el modo (oneWay, onewayToSource, twoWays, oneTime)
  ```
        <StackPanel Grid.Column="1" Grid.Row="2" Grid.ColumnSpan="3">
            <TextBox Name="MiCuadroTexto" FontSize="20" Width="200"
                   VerticalAlignment="Center" HorizontalAlignment="Center" Text="{Binding ElementName=MiSlider, Path=Value, Mode=TwoWay}" TextAlignment="Right"></TextBox>
            <Slider Name="MiSlider" Width="350" Minimum="0" Maximum="100"></Slider>
        </StackPanel>
  ```
5. Interfaz INotifyPropertyChanged
Permite notificar cambios en cualquiera de las propiedades de un objeto. Para controlar estos cambios se deben seguir varios pasos:
- Indicar el Binding con la propiedad en el xaml.
  ```
   Text="{Binding Path=Nombre, Mode=TwoWay}"
  ```
  
- Declarar una clase que herede de INotifyPropertyChanged.
- Ejecutar el evento de cambio mediante una función como esta:
  ```C#
  private void NotifyPropertyChanged(string propertyName = "")
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
  ````
  - Instancias la clase y indicar el origen de dato de los binding.
  ```
  UnirNombre unirNombre = new UnirNombre { Nombre="Juan", Apellido="Rodríguez"};
  this.DataContext = unirNombre;
  ```
  
  Ej: [ejemplo de INotifyPropertyChanged](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/blob/main/PruebasCPildorasInformaticas/PrimeraInterfazWPF/UnirNombre.cs)
  
6. ListBox
  En los ListBox se tiene que establecer el ItemTemplate. Un ejemplo es el siguiente:
  ```
  <ListBox Name="lstPoblacionesXAML" Grid.Row="0" HorizontalContentAlignment="Stretch" SelectionChanged="lstPoblacionesXAML_SelectionChanged">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid Margin="10">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="*"></ColumnDefinition>
                            <ColumnDefinition Width="*"></ColumnDefinition>
                            <ColumnDefinition Width="*"></ColumnDefinition>
                            <ColumnDefinition Width="*"></ColumnDefinition>
                            <ColumnDefinition Width="*"></ColumnDefinition>
                        </Grid.ColumnDefinitions>
                        <TextBlock Grid.Column="0" Grid.Row="0" Text="{Binding Path=Poblacion1}"></TextBlock>
                        <TextBlock Grid.Column="1" Grid.Row="0" Text="{Binding Path=Temperatura1}"></TextBlock>
                        <TextBlock Grid.Column="2" Grid.Row="0" Text="{Binding Path=Poblacion2}"></TextBlock>
                        <TextBlock Grid.Column="3" Grid.Row="0" Text="{Binding Path=Temperatura2}"></TextBlock>
                        <ProgressBar Grid.Column="4" Grid.Row="0" Maximum="100" Value="{Binding Path=DiferenciaTemperatura}" />
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
  ```
  Ej: [ejemplo de ListBox](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/blob/main/PruebasCPildorasInformaticas/ListBoxPractica/MainWindow.xaml.cs)
  
7. ComboBox y CheckBox. El ComboBox es muy poarecido al anterior y, el checkbox, tiene la opción de permitir tres estados, para checkbox que permiten seleccionar todos los checkbox hijos. Ej: [ejemplo de ComboBox y CheckBox](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/blob/main/PruebasCPildorasInformaticas/ListBoxPractica/MainWindow.xaml.cs)
8. Checkbox. Se realiza una práctica que consiste en un checkbox con un semáforo que enciende luz según el check. Hay que usar un Grid y el objeto Ellipse

### 4. ACCESO A BBDD SQLSERVER
Creamos una base de datos con un tabla clientes, productos y pedidos.
En el explorador de servidores tenemos las bases de datos que se van a poder gestionar desde el proyecto. Para enlazar un la base de datos podemos;
- Usar el Origenes de datos y usar el asistente.
- Usar el app.Config, definir la cadena de conexión con appSettings y add key.

Al usar el editor de base de datos que viene con visual studio es necesario acordarse de pulsar el botón actualizar.
  
Para recuperar los datos de la base de datos y  cargarlos en un ListBox se necesita:
  - Crear la cadena de conexión.
  - Usar la clase SqlConnection.
  - Usar sqlDataAdapter o sqlCommand (necesita el open de la conexión).
  - Cargar el DataTable.
  - Indicar en el ListBox
    - El elemento a mostrar en la lista: ListaClientes.DisplayMemberPath = "nombre"; 
    - La clave: ListaClientes.SelectedValuePath = "Id";
    - El origen de datos: ListaClientes.ItemsSource = clientes.DefaultView;
  
  Ej: [GestionPedidos](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/tree/main/GestionPedidosWPF)

A continuación, se realiza un ejemplo de CRUD, con la modificación en una ventana emergente.
Para ejecutar un código después de cerrar la ventana hijo hau dos alternativas:
1. Usar ventana modal con ShowDialog y ejecutar el código después.
2. Usar el evento de ventana Activated que se ejecuta cuando la ventana recibe el foco.
Ej: [GestionPedidos](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/tree/main/GestionPedidosWPF)

### 5. LINQ
Es un lenguaje de consulta integrado en C#. Permite consultar datos de diferentes orígenes de datos: colección de objetos, XML, SQL BBDD, entidades, recordset...
El uso de Linq:
  - Uniforma el lenguaje de consulta
  - Reduce el código
  - Código más legible.
  - Integración en C#.
  
La API Linq está formada por dos clases: Enumerable y Queryable.
  
1. Pruebas con listas. Se realiza ejemplo con Empresas y Empleados y se emplea LINQ para filtrar estas listas:
Ej: [PruebasLinq](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/tree/main/PruebasLinq)

2. Ejemplo con Clases de Linq to SQL (Hay que instalarla extensión con Visual Studio Installer y es el paquete Herramientas de Linq to SQL)
  C:\Program Files (x86)\Microsoft Visual Studio\Installer
  
  Al crear un elemento de este tipo, se crea un archivo .dbml dónde podemos arrastrar las tablas desde el "Explorador de Servidores" que queramos gestionar como clases. Aquí tenemos un ejemplo de WPF con un DataGrid y realizando las operaciones CRUD.
Ej: [WPFLinq](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/tree/main/WPFLinq)

### 6. THREAD
Programación concurrente y aplicaciones multitarea.

Dos tipos:
- Monotarea: Solo realiza una tarea a la vez.
- Multitarea: Se pueden realizar varias tareas a la vez.

Para poder ver la ejecución, hay una ventana de subproceso. En depuración vamos a Depurar / Ventanas / Subproceso.

1. **Sincronización y bloqueo**
- Para sincronizar se usa el .Join()
- Para el bloqueo se usa Lock(objeto) y entre llaves el código a bloquear. Usamos un ejemplo de 4 miembros de una familia y una cuenta bancaria.
Se puede dar nombre a un Thread con la propiedad Name y se puede acceder a ese nombre con CurrentThread.Name.

Ej: [PruebaThread](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/tree/main/PruebaThread)
    [ThreadPruebaBanco](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/tree/main/ThreadPruebaBanco)
  

2. **Control de finalización de hilo**
Se hace con TaskCompletionSource<Generico> y, para indicar que ha terminado, llamamos al método TrySetResult del TaskCompletionSource y cómo parámetro el genérico.
Después, para preguntar si ha finalizado el hilo, usamos la propiedad Task.Result
Ej: [ThreadTaskCompletion](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/tree/main/ThreadTaskCompletion)
  
3. POOL DE THREAD
Se utiliza cuando quieres usar varios hilos de manera concurrente. Al crear un pool de Thread, permite reutilizar Thread para varias tareas. Para usarlo utilizamos el método estático: ThreadPool.QueueUserWorkItem
Ej: [ThreadPullPruebas](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/tree/main/ThreadPullPruebas)
  
4. TASK.
Las Task surgen para gestionar los problemas que surgen por infrautilizar o sobreutilizar los recursos del procesador. Se colocan por encima de los Thread (un nivel de abstracción mayor) para optimizar el uso del procesador (parecido al pull de conexiones)
  
El método estático Run permite hacer en un solo paso la instanciación y el arranque de la tarea.
```
  Task tarea = Task.Run(EjecutarTarea);
  
  es igual que
  Task tarea = new Task(EjecutarTarea);
  tarea.Start();
```
  
Para ejecutar una tarea después de otra, hay que usar la tarea anterior y llamar al método **ContinueWith**.
  
- WaitAll, WaitAny y Wait. Permite dar prioridad a unas tareas sobre otras, es decir, podemos conseguir que las tareas se ejecuten de manera consecutiva o que se ejecuten cuando se acabe otra de las tareas.
  
Ej: [ThreadTask](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/tree/main/ThreadTask)
  
5. **CLASE PARALLEL** Nos permite trabajar con varias tareas de manera sencilla y ejecutar llamadas paralelas gracias a su métodos For y ForEach.
Ej: [Parallel](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/tree/main/ThreadParallel) 

6. CANCELAR TAREA.
- Hay que crear un token de cancelación. Se usa las clases: CancellationTokenSource y CancellationToken
- Hay que propagar esa cancelación. Se usa el objeto CancellationTokenSOurce con el método Cancel.
- El método que se ejecuta en la tarea recibirá la petición de cancelación y realizará las operaciones oportunas.
  
Ej: [Cancel](https://github.com/Asurbanipal1977/PruebasCPildorasInformaticas/tree/main/ThreadTaskCancel) 

  
  
