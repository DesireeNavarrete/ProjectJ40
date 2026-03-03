using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestState 
{
    REQUIREMENTS_NOT_MET,//el jugador todavia no tiene los requisitos para empezar la mision, por defecto las misiones estan asi al crearlas
    CAN_START,//cuando ya tiene los requisitos para empezar
    IN_PROGRESS,//cuando se empieza la quest
    CAN_FINISH,//steps completados de esa quest
    FINISHED//quest completada, ahora toca reclamar la experiencia
}
