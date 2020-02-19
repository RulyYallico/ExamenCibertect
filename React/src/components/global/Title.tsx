import React from 'react';

interface IProps {
    texto: string;
}

export function Title(props: IProps) {
    const textTitulo = !props.texto ? "Titulo no definido" : props.texto;
    return <h1>{textTitulo}</h1>
}
