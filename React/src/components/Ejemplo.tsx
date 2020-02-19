import React, {useState, useEffect} from 'react';


export default function principal(){
    return <h1>Principal</h1>
}

export function Secundario(){
    return <h2>Elemento Secundario</h2>
}

interface IMostrarNombreProps{
    nombre: string;
    numeroDeVeces: number;
}

interface IMostrarNombresProps {
    nombres: string[];
}

export function MostrarNombres(props: IMostrarNombresProps){
    if (!props.nombres || props.nombres.length === 0){
        return <b>No se ha enviado nombres para mostrar</b>
    }

    return <>
        {props.nombres.map((nombre) => {
            return <p>Tu nombre es: <b>{nombre}</b></p>
        })}
    </>
}


export function MostrarNombre(props: IMostrarNombreProps){
    const arregloDeNombres = [];

    for (let index = 0; index < props.numeroDeVeces; index++){
    arregloDeNombres.push(<p>Tu nombre es: <b>{props.nombre}</b></p>);
    }

    return <>
        {arregloDeNombres}
    </>
}

// a.balbin.r@gmail.com


