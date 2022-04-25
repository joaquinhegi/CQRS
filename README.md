# CQRS
Command and Query Responsibility Segregation 

## Que es?
La idea detrás de CQRS es partir lógicamente el flujo de nuestra aplicación en dos flujos distintos:

- **Commands:** Modifican el estado del dominio.
- **Queries:** Consultan el estado del dominio.

![CQRS](https://www.iteriam.es/img/blog/ahg_01.png)

## Problema que resuelve
En las arquitecturas tradicionales, se utiliza el mismo modelo de datos para consultar y actualizar una base de datos. Es sencillo y funciona bien para las operaciones CRUD básicas. Sin embargo, en aplicaciones más complejas, este enfoque puede resultar difícil de manejar. Por ejemplo, en el lado de lectura, la aplicación puede realizar muchas consultas diferentes y devolver objetos de transferencia de datos (DTO) con distintas formas. La asignación de objetos puede llegar a ser algo complicado. En el lado de escritura, el modelo puede implementar una validación y una lógica de negocios complejas. En consecuencia, puede acabar con un modelo excesivamente complejo que haga demasiado.
Las cargas de trabajo de lectura y escritura suelen ser asimétricas, con requisitos de rendimiento y escalabilidad muy diferentes.

- A menudo hay una incoherencia entre las representaciones de lectura y escritura de los datos, como columnas o propiedades adicionales que se deben actualizar correctamente incluso aunque no sean necesarias como parte de una operación.

- La contención de datos puede producirse cuando las operaciones se realizan en paralelo en el mismo conjunto de datos.

- El enfoque tradicional puede tener un impacto negativo en el rendimiento debido a la carga en el almacén de datos y al nivel de acceso a los datos, y la complejidad de las consultas necesarias para recuperar la información.

- Esto puede hacer que la administración de la seguridad y los permisos se vuelva más compleja ya que cada entidad está sujeta a operaciones de lectura y de escritura, lo cual podría exponer los datos en el contexto equivocado.

## Commands
Los comandos se deben basar en tareas, en lugar de centrarse en los datos. ("Book hotel room", no "set ReservationStatus to Reserved") y se pueden colocar en una cola para su procesamiento asincrónico, en lugar de procesarse sincrónicamente.

**Carateristicas:**
- Data Transfer object(DTO)
- Inmutable
- Realizan una modificacion en el sistema 
- No devuelven nada

```C#
public class AddPersonCommand:ICommand
{
     public int Id { get; set; }
     public string FirstName { get; set; }
     public string LastName { get; set; }
     public DateTime DateOfBirth { get; set; }
}
``` 

## Queries
Las queries nunca modifican la base de datos. Una queries devuelve un DTO que no encapsula ningún conocimiento del dominio.

**Carateristicas:**
- Data Transfer object(DTO)
- Inmutable
- Pide algo a el sistema
- Devuelve una respuesta

```C#
public class FindPersonBetweenYearCommand:IQuery
{
    public int StartYear { get; set; }
    public int EndYear { get; set; }
}
``` 

## Ventajas
- Puede maximizar el rendimiento, la escalabilidad y la seguridad. La flexibilidad creada al migrar a CQRS permite que un sistema evolucione mejor con el tiempo y evita que los comandos de actualización provoquen conflictos de combinación en el nivel de dominio.

- Escalado Independiente, CQRS permite que las cargas de trabajo de lectura y escritura se escalen de forma independiente y pueden resultar en menos contencion de bloqueos.

- Esquemas de datos optimizados, el lado de lectura usar un equema optmizado para consultas, mientas que el lado de escritura usa un esquema optimizado para actualizaciones.

- Seguridad, es mas facil asegurase de que solo las entidades de domio correctas esten realizando esrituras en los datos.

- Separacion de Intereses, la seaparacion de los lados de lectura y escritura pueden dar como ersultado modelos mas faciles de mantener y flexibles. La mayor parte de la logica empresarial compleja entra en el modelo de escritura. El odelo de ectura puese ser relativamente simple.

## Desventajas

- Complejidad, la idea básica de CQRS es sencilla. Pero puede generar un diseño de aplicación más complejo.

- Coherencia final, si separa las bases de datos de lectura y escritura, los datos de lectura pueden estar obsoletos. El almacén de modelos de lectura debe actualizarse para reflejar los cambios del almacén de modelos de escritura, y puede ser difícil detectar cuándo un usuario ha emitido una solicitud basada en datos de lectura obsoletos.

## Conclusión
La implementación de CQRS puede Maximizar el rendimiento, la reutilización, la capacidad de prueba, la capacidad de mantenimiento, la seguridad y la escalabilidad. Sin embargo, puede ser muy costoso y complejo implementar este patron si nuestro dominio o las reglas de negocio son simples.
