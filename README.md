# Pirate Beer Colector

**Plataformas 3D** en Unity (URP) ambientado en una **ciudad moderna rodeada por el océano**, con peleas de piratas de fondo. Eres un **vagabundo** que vive detrás de los edificios y tu objetivo es **recolectar la mayor cantidad de cervezas** antes de que **se acabe el tiempo**. Para **finalizar la partida**, debes **entrar en uno de los basureros** repartidos por el mapa **antes** de que el cronómetro llegue a cero.

---

## Tabla de contenidos
- [Loop de juego](#loop-de-juego)
- [Características](#características)
- [Requisitos técnicos (evaluación)](#requisitos-técnicos-evaluación)
- [Controles](#controles)
- [Objetos clave en la escena](#objetos-clave-en-la-escena)
- [Requisitos y versión](#requisitos-y-versión)
- [Cómo ejecutar](#cómo-ejecutar)
- [Créditos](#créditos)

---

## Loop de juego
1. **Explora** la ciudad: plaza, edificios, pasarelas y nubes “caminables”.
2. **Plataformeá** para **buscar cervezas** por todo el mapa.
3. **Gestiona el tiempo**: el reloj corre sin piedad, **pero cada cerveza te da +5 segundos**.
4. **Finaliza la partida**: entra en un **basurero** **antes** de que el tiempo llegue a cero.
5. **Optimiza tu ruta** para encadenar cervezas, **extender el tiempo** y **mejorar tu puntaje**.

---

## Características
- **Third Person Controller** listo para URP.
- **Coleccionables** (cervezas) con animación y SFX. **Cada cerveza = +5 s de tiempo.**
- **Meta** basada en **basureros** con trigger de fin de partida.
- **UI**: contador de cervezas y temporizador en pantalla (el tiempo se **incrementa** al recoger).
- **Audio** básico (música + SFX).
- **Nivel** con verticalidad y rutas alternativas (edificios, plataformas y nubes).

---

## Requisitos técnicos (evaluación)
- Punto de **partida** del jugador.
- **Ítem coleccionable** distinto a la moneda vista en clases (cervezas).
- **Meta/Objetivo**: basurero con trigger para terminar el nivel.
- **Gestión de UI**: tiempo y cervezas en pantalla (**actualiza tiempo +5 s por cerveza**).
- **Unity**:
  - Tercera persona (ThirdPersonController).
  - **Triggers** (`OnTriggerEnter`) para coleccionar y meta.
  - **Animaciones** básicas (giro/flotación en coleccionables).
  - **Scripts** con `Start`, `Update`, `OnTriggerEnter`, métodos y parámetros públicos.
  - **Transiciones** de animación en locomoción.
  - **Audio** básico (música + SFX pickup/meta).

---

## Controles
- **Mover**: WASD / Stick izquierdo  
- **Mirar**: Mouse / Stick derecho  
- **Saltar**: Espacio / A (Cross)  
- **Correr**: Shift (si está habilitado en el TPC)


---

## Objetos clave en la escena
- **Player**: controlador en tercera persona (CharacterController).
- **Cerveza (Prefab)**  
  - **Padre**: `Capsule Collider (IsTrigger)` + script de pickup;  
  - **Hijo `Visual`**: `MeshRenderer/SkinnedMeshRenderer` + **Animator** (clip en loop de giro).  
  - **Lógica de bonus**: al recoger, sumar **+5 s** al temporizador.
- **Meta (Prefab)**  
  - Objeto con **Box/Capsule Collider (IsTrigger)** + script `MetaLlegada` para finalizar/cambiar de escena (SFX opcional).

---

## Requisitos y versión
- **Unity 6.0**: version 6000.0.5.8f2(LTS recomendado).  
- **URP** habilitado (Depth/Opaque Texture sugeridos).  
- **Color Space**: Linear.

---

## Cómo ejecutar
1. Clona el repositorio y ábrelo con la versión de Unity indicada.  
2. Abre la escena **MainMenu** o **Level1**.  
3. Verifica **Build Settings** y ejecuta **Play**.  

---

## Créditos
- Diseño y programación: **Bastián Nuñez Vazques y Sebastián Constanzo Hidalgo **  
- Arte low poly y props: 
- Audio: **música/SFX libres** o provistos por el curso (citar fuentes si corresponde)

