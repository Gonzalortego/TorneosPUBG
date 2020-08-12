# TorneosPUBG
Muestro una lista de los torneos de PUBG
Version de unity: 2020.1.1f1

2) Describir si ha tenido problemas al integrar plugins de terceros para Android.

En general no he tenido grandes problemas ya que, generalmente, vienen con instrucciones o una documentación fácil de seguir. Los mas complicados que he implementado o que mas problemas me han dado han sido algún SDK. En un proyecto utilice el SDK de facebook para permitir que el usuario pueda logearse a través de esa red social y en otro proyecto utilice el SDK de firebase para utilizar su base de datos. Esos pueden resultar mas complejos por que necesitan una configuración externa a unity, ya que unity necesita información que proveen a través de la web y la web a su vez necesita información sobre el proyecto de unity. Pero nunca no he podido implementar un plugin, soy muy persistente y autodidacta, por lo que termino encontrando la forma de hacerlo funcionar.

3) Describir los pasos para crear un build y subirlo a TestFlight para iOS.

Crear un build:
1) Se debe tener instalado XCode.
2) Se debe tener instalado el componente "iOS Build Support" en Unity.
3) En Build Settings se debe seleccionar como plataforma "iOS".
4) En Player Settings/Settings for iOS se pueden configurar cosas como la identificación y el dispositivo target.
5) En Build Settings se debe seleccionar "Build". Esto generara un proyecto XCode.
6) Se debe abrir el archivo .xcodeproj generado con el programa XCode.
7) En las propiedades del proyecto se debe configurar cierta información como el nombre, la firma y el Identifier.
8) Se pulsa en el boton Play y comenzara la compilación, si se tiene un celular asociado el juego se instalara allí.

Subirlo a TestFlight:
1) Entrar a App Store Connect y crear una nueva app. Es importante que tenga el mismo Bundle ID que el Bundle Identifier del proyecto de XCode. Si no aparece en la lista debe registrase pulsando en el "Developer Poral", luego ir a Identifiers/Apple IDs y crearlo alli.
2) En XCode ir a Product/Archive y seleccionar Distribute App, asegurarse de seleccionar App Store Connect/Upload. Esto subirá el proyecto a App Store Connect.
3) ir a App Store Connect y entrar en la app creada. Si todo fue bien, debería aparecer en la pestaña TestFlight.
4) En la pestaña TestFlight, si hay un warning en el nombre de la app se debe pulsar y seleccionar "Provide Export Compliance". Llenar ese formulario.
5) En la pestaña TestFlight, si hay un warning en "Test information" en el panel de la izquierda, se debe pulsar en el botón y completar esa información. Luego pulsar en Save.
6) Ya esta listo para agregar testers y mandarles invitaciones.