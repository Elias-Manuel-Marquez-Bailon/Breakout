# Breakout

Juego tipo Breakout hecho en **Unity 6 (6000.5.10f1)** con el nuevo Input System y físicas 2D.

![Captura del juego](Capturas/gameplay.png)

## Qué hace

- La paleta se mueve con las flechas izquierda y derecha y **no se sale de la pantalla** (tiene límites definidos en código).
- La pelota **reaparece encima de la paleta** cuando se cae por abajo, para poder seguir jugando.
- Hay una **pared de 44 ladrillos** que ocupa el ancho de la pantalla.
- Cada ladrillo **desaparece al golpearlo** y suma **1 punto** (el contador vive en `GameManager`).
- La pelota sale con **dirección un poco aleatoria** cada vez que se lanza o reaparece, para que no siempre salga igual.

## Controles

| Tecla | Acción |
| --- | --- |
| ← | Mover la paleta a la izquierda |
| → | Mover la paleta a la derecha |

## Cómo abrirlo

1. Abre la carpeta del proyecto con **Unity 6000.5.10f1**.
2. Abre `Assets/Scenes/SampleScene.unity`.
3. Dale **Play**.

## Poner el puntaje en pantalla (opcional)

La escena trae un Canvas vacío llamado `TextoPuntos`. El contador ya funciona, pero para que
se vea en pantalla hay que agregarle el texto:

1. Selecciona `TextoPuntos` → `Add Component` → **`Text - TextMeshPro`**.
2. La primera vez Unity pide importar **TMP Essentials** → `Import` (son las fuentes, se hace una sola vez).
3. En el `RectTransform` pon el `Anchor Preset` en **`Top Center`**, y en el `TextMeshProUGUI`
   un `Font Size` de **`40`**.

No hay que conectar nada: `GameManager` busca el texto solo con `FindAnyObjectByType<TMP_Text>()`.

## Estructura

```
Assets/
├── Physics/Rebote.physicsMaterial2D   Material de rebote (bounciness 1)
├── Scenes/SampleScene.unity           Escena principal
├── Scripts/
│   ├── GameManager.cs                 Cuenta los puntos y actualiza el texto
│   ├── JugadorMovimiento.cs           Movimiento de la paleta y sus límites
│   ├── Ladrillo.cs                    Se destruye al ser golpeado y anota puntos
│   └── PelotaMovimiento.cs            Lanzamiento y reaparición de la pelota
└── Settings/                          Configuración de Render y Volumen
```

## Cómo funciona por dentro

**`JugadorMovimiento.cs`** — en `FixedUpdate` calcula el movimiento y luego lo recorta con
`Mathf.Clamp(posicion.x, limiteIzquierdo, limiteDerecho)`. Los límites son `±7.4`, que es
lo que mide la mitad del ancho visible de la cámara (8.89) menos la mitad de la paleta (1.5).

**`PelotaMovimiento.cs`** — en `Update` revisa si la pelota bajó de `limiteCaida` (`-5.5`). Si pasó,
la teletransporta a `paleta.position + alturaSobrePaleta` y la relanza con un ángulo un poco
aleatorio.

**`Ladrillo.cs`** — en `OnCollisionEnter2D` revisa que lo que lo golpeó sea un cuerpo **dinámico**
(así la paleta no lo destruye) y si no, llama a `GameManager.AnotarLadrillo(puntos)` y se destruye.

**`GameManager.cs`** — se suscribe a su propio evento `AlDestruirLadrillo` y va sumando en
`puntosJugador`. El texto se busca solo con `FindAnyObjectByType<TMP_Text>()`, por eso no hay
nada que conectar a mano en el Inspector.

## Detalles de la escena

- Las paredes (`LimiteIzquierdo`, `LimiteDerecho`, `LimiteSuperior`) tienen `BoxCollider2D` normal: la pelota rebota.
- Las porterías tienen el collider como **Trigger**: la pelota las atraviesa.
- La pelota usa el material `Rebote` (bounciness 1) y tiene `Freeze Rotation` activado.
- La paleta usa un `Rigidbody2D` **Kinematic** y se mueve con `MovePosition`.
