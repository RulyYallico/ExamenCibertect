import axios from "axios";
import { IProduct } from '../types';


export async function obtenerTodos(): Promise<IProduct[]> {
    // obtener el resultado de la solicitud en una variable
    const resultado = await axios.get(`${process.env.REACT_APP_BASE_URL}/product/ListAll`);

    // devolver la data obtenida del resultado, casteandola como un arreglo de IProduct
    return resultado.data as IProduct[];
}


export async function obtenerPorId(productId: number): Promise<IProduct> {
    const resultado = await axios.get(`${process.env.REACT_APP_BASE_URL}/product/${productId}`)
    return resultado.data as IProduct;
}

export async function insertarProduct(nuevoProducto: Partial<IProduct>): Promise<string> {
    const resultado = await axios.post(`${process.env.REACT_APP_BASE_URL}/product`, nuevoProducto);
    return resultado.data;
}

export async function deleteProduct(productId: number): Promise<number> {
    const resultado = await axios.delete(`${process.env.REACT_APP_BASE_URL}/product/${productId}`);
    return resultado.data;
}
