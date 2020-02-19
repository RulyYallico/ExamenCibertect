import React, { useState, useEffect } from 'react';
import {ICategory, IPageBaseProps } from '../types';
import { ObtenerTodos } from '../services/categoryService';
import loading from '../assets/loading.svg';
import { Title } from '../components/global/Title';
import { DescriptionCantidad } from '../components/global/DescriptionCantidad';
import { TablaCategorias } from '../components/tablaCategorias/TablaCategorias';


export function ListaCategorias(props: IPageBaseProps){
    
    const [data, setData] = useState<ICategory[]>([]);
    const [cargando, setCargando] = useState<boolean>(true);

    useEffect( () => {
        async function cargarCategorias(){
            var categorias = await ObtenerTodos();
            setData(categorias);

            setCargando(false);
        }
        
        setTimeout(() => {
            cargarCategorias();
        }, 500);
    }, [])

    const descriptiondeCantidad = `Hay ${data.length} de categorias registradas`;

    if (cargando){
        return <div className="d-flex justify-content-center">
            <img src={loading}></img>
        </div>
    }

    return <div>
        <Title texto="Lista de Categorias"></Title>
        <DescriptionCantidad texto={descriptiondeCantidad}></DescriptionCantidad>
        <TablaCategorias data={data}></TablaCategorias>
    </div>
}
