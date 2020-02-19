import React from 'react';

interface IProps{
    texto: string;
}

export function DescriptionCantidad(props: IProps){

    const cantidad = !props.texto ? "Sin Cantidad" : props.texto;

return <p>{cantidad}</p>;

}

