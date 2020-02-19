import React, { useState, useEffect } from 'react';
import { IPageBaseProps, IProduct } from '../types';
import { obtenerTodos, deleteProduct } from '../services/productService';
import { DescriptionCantidad } from "../components/global/DescriptionCantidad";
import { Title } from '../components/global/Title';
import loading from '../assets/loading.svg';
import { Link } from '@reach/router';
import { TablaProductos } from '../components/tablaProductos/TablaProductos';

export function ListaProductos(props: IPageBaseProps) {

    const [data, setData] = useState<IProduct[]>([]);
    const [cargando, setCargando] = useState<boolean>(true);

    async function cargarProductos() {
        var productos = await obtenerTodos();
        setData(productos);

        setCargando(false);
    }

    useEffect(() => {
        setTimeout(() => {
            cargarProductos();
        }, 500);

    }, [])

    const borrarProducto = async (productId: number) => {
        const resultadoBorrar = await deleteProduct(productId);
        if(resultadoBorrar > 0){
            cargarProductos();
        }
    }

    const descripcionCantidad = `Hay ${data.length} de productos registrados`;

    // mostrar el indicador de cargando
    if (cargando) {
        return <div className="d-flex justify-content-center">
            <img src={loading}></img>
        </div>
    }

    return <div>
        <Title texto="Lista de Productos"></Title>
        <DescriptionCantidad texto={descripcionCantidad}></DescriptionCantidad>
        <Link to="/products/insert" className="btn btn-primary btn-sm mb-3">Crear nuevo producto</Link>
        <TablaProductos data={data} onDeleteProducts={borrarProducto}></TablaProductos>
    </div>
}